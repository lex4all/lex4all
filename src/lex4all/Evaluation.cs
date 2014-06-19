using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System.Diagnostics;
using System.IO;

namespace lex4all
{
    public static class Evaluation
    {
        /// <summary>
        /// Get the set of words (graphemes) in the given lexicon file.
        /// Lexicon file must use the namespace below.
        /// </summary>
        /// <param name="lexFileName">Path to lexicon file</param>
        /// <returns>Array of words</returns>
        public static string[] ReadLexicon(string lexFileName)
        {
            //Debug.WriteLine("Starting to read lexicon");
            XDocument lexDoc = XDocument.Load(lexFileName);
            //Debug.WriteLine("lexdoc created");

            XNamespace ns = "http://www.w3.org/2005/01/pronunciation-lexicon";

            IEnumerable<XElement> childList =
                from el in lexDoc.Root.Elements(ns + "lexeme")
                select el.Element(ns + "grapheme");
            foreach (XElement e in childList)
            {
                //Debug.WriteLine(e.Value);
            }
            string[] words =
                (from lexeme in lexDoc.Root.Elements(ns+"lexeme")
                select lexeme.Element(ns+"grapheme").Value).ToArray();

            //Debug.WriteLine(String.Join(",", words));

            return words;    
        }

        /// <summary>
        /// Gets an evaluation grammar with the proper lexicon reference and word choices.
        /// For some reason (bug in Microsoft.Speech), the grammar has to be written to file
        /// for this to work. Not sure it makes sense to let the user choose save path.
        /// </summary>
        /// <param name="words">Array of words to be included</param>
        /// <param name="lexFile">Path to lexicon file</param>
        /// <returns>Grammar object (to be loaded into engine)</returns>
        public static string getEvalGram(string[] words, string lexFile)
        {
            //string[] words = ReadLexicon(lexFile);

            // write evaluation grammar to file
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 
            string path = Path.GetTempPath();
            //string gramFilePath = Path.GetTempFileName(); //old: 
            string gramFilePath = Path.Combine(path, "lex4allEvalGrammar.xml");

            XNamespace ns = @"http://www.w3.org/2001/06/grammar";
            XDocument gramDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XElement(ns + "grammar",
                    new XAttribute("version", "1.0"),
                    new XAttribute(XNamespace.Xml + "lang", EngineControl.Language),
                    new XAttribute(XNamespace.Xmlns + "sapi", @"http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions"),
                    new XAttribute("root", "Main"),
                    new XElement(ns + "lexicon",
                        new XAttribute("uri", lexFile)),
                    new XElement(ns + "rule",
                        new XAttribute("id", "Main"),
                        new XElement(ns + "one-of",
                            words.Select(x => new XElement(ns + "item", x))))));

            gramDoc.Save(gramFilePath);
            return gramFilePath;

        }

        public static void deleteTempFile(string tmpFilePath)
        {
            try {
                if (File.Exists(tmpFilePath)) {
                    File.Delete(tmpFilePath);
                 Debug.WriteLine("Temporary file deleted.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(String.Format("Error deleting temporary file {0} : ", tmpFilePath) + ex.Message);
            }
        }

        /// <summary>
        /// Gets an evaluation grammar with the proper lexicon reference and word choices.
        /// </summary>
        /// <param name="words">Array of words to be included</param>
        /// <param name="lexFile">Path to lexicon file</param>
        /// <returns>Grammar object (to be loaded into engine)</returns>
        //public static Grammar getEvalGram(string[] words, string lexFile)
        //{
        //    // one-of object with all words
        //    SrgsOneOf oneOf = new SrgsOneOf();
        //    foreach (string word in words)
        //    {
        //        SrgsItem wordItem = new SrgsItem(word);
        //        oneOf.Add(wordItem);
        //    }

        //    // main rule containing the one-of
        //    SrgsRule mainRule = new SrgsRule("Main");
        //    mainRule.Elements.Add(oneOf);

        //    // create document, add relevant properties & main rule
        //    SrgsDocument evalDoc = new SrgsDocument();
        //    evalDoc.PhoneticAlphabet = SrgsPhoneticAlphabet.Ups;
        //    evalDoc.Culture = new System.Globalization.CultureInfo("en-US");
        //    evalDoc.AddLexicon(new Uri(lexFile));
        //    evalDoc.Rules.Add(mainRule);
        //    evalDoc.Root = mainRule;

        //    // print for debugging
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    XmlWriterSettings settings = new XmlWriterSettings();
        //    settings.Indent = true;
        //    string srgsDocumentFile = Path.Combine(path, "debugEvalGram.xml");
        //    XmlWriter writer = XmlWriter.Create(srgsDocumentFile, settings);
        //    evalDoc.WriteSrgs(writer);
        //    writer.Close();

        //    // get Grammar object from SrgsDocument
        //    Grammar evalGram = new Grammar(srgsDocumentFile);
        //    return evalGram;

        //}


        /// <summary>
        /// Performs evaluation on given words/audio using the provided lexicon.
        /// Uses getEvalGram() to make an evaluation grammar with the given words/lexicon.
        /// </summary>
        /// <param name="testDict">Words/audio</param>
        /// <param name="lexFile">Path to lexicon</param>
        /// <param name="report">OUTPUT parameter to also return message with eval stats</param>
        /// <returns>Confusion matrix as dictionary</returns>
        public static Dictionary<string, Dictionary<string, int>> Evaluate(Dictionary<String, String[]> testDict, string lexFile, out string report)
        {
            string[] realWords = testDict.Keys.ToArray();
            string[] expectedWords = ReadLexicon(lexFile); //will be the same as realWords except during Discriminative Training

            // set up tally variables
            int total = 0;
            int correct = 0;
            int incorrect = 0;
            int unrec = 0;

            // set up confusion matrix
            Dictionary<string, Dictionary<string, int>> confusion = new Dictionary<string, Dictionary<string, int>>();

            // set up engine variable & get grammar
            SpeechRecognitionEngine engine;
            string evalGramFile = getEvalGram(expectedWords, lexFile);
            Grammar evalGram;

            // iterate through testDict
            foreach (string word in realWords)
            {
                // set up confusion matrix tallies for this word
                confusion[word] = new Dictionary<string, int>();
                foreach (string otherWord in expectedWords)
                {
                    confusion[word][otherWord] = 0;
                }
                confusion[word]["UNRECOGNIZED"] = 0;

                string actual = word;

                // recognize audio & tally results
                foreach (string wavfile in testDict[word])
                {
                    total++;

                    engine = lex4all.EngineControl.getEngine();
                    evalGram = new Grammar(evalGramFile);
                    engine.LoadGrammar(evalGram);
                    engine.SetInputToWaveFile(wavfile);

                    Debug.Write(actual + " ");
                    RecognitionResult result = engine.Recognize();

                    if (result == null)
                    {
                        Debug.WriteLine("unrecognized");
                        unrec++;
                        confusion[actual]["UNRECOGNIZED"]++;

                    }
                    else
                    {
                        string recognizedAs = result.Text;
                        Debug.WriteLine(recognizedAs + " " + result.Confidence);
                        confusion[actual][recognizedAs]++;
                        if (recognizedAs == actual) { correct++; }
                        else { incorrect++; }
                       
                    }
                }
            }


            report = GetReport(total, correct, incorrect, unrec);

            //Dictionary<string, object> evalResults = new Dictionary<string, object>();
            //evalResults["stats"] = report;
            //evalResults["confusion"] = confusion;

            Debug.WriteLine("evalGramFile: " + evalGramFile);
            //deleteTempFile(evalGramFile);

            return confusion;

        }



        /// <summary>
        /// Gets a string reporting the evaluation statistics (to be displayed/written to log).
        /// </summary>
        private static string GetReport(int total, int correct, int incorrect, int unrec)
        {
             

            float pctCorrect = ((float)correct / (float)total) * 100f;
            float pctIncorrect = ((float)incorrect / (float)total) * 100f;
            float pctUnrec = ((float)unrec / (float)total) * 100f;

            object[] stats = new object[7];
            stats[0] = total;
            stats[1] = correct;
            stats[2] = pctCorrect;
            stats[3] = incorrect;
            stats[4] = pctIncorrect;
            stats[5] = unrec;
            stats[6] = pctUnrec;

            string template = @"

Audio files tested:   {0}

Correct:        {1} ({2:0.00}%)
Incorrect:      {3} ({4:0.00}%)
Unrecognized:   {5} ({6:0.00}%)";

            string report = String.Format(template, stats);

            return report;
        }
    }
}
