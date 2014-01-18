using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Speech.Recognition;
using System.Diagnostics;

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
        /// </summary>
        /// <param name="words">Array of words to be included</param>
        /// <param name="lexFile">Path to lexicon file</param>
        /// <returns>Grammar object (to be loaded into engine)</returns>
        private static Grammar getEvalGram(string[] words, string lexFile)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Performs recognition and computes accuracy on the given testing files.
        /// </summary>
        /// <param name="TestDict">Keys are words, values are lists of audio file names</param>
        /// <param name="evalGram">Grammar object referencing correct lexicon</param>
        /// <returns>Dictionary of form {"report":string, "confusion":Dictionary}</returns>
        public static Dictionary<string, object> Evaluate(Dictionary<String, String[]> testDict, string lexFile)
        {
            string[] words = testDict.Keys.ToArray();

            // set up tally variables
            int total = words.Count();
            int correct = 0;
            int incorrect = 0;
            int unrec = 0;

            // set up confusion matrix
            Dictionary<string, Dictionary<string, int>> confusion = new Dictionary<string, Dictionary<string, int>>();

            // set up engine variable
            SpeechRecognitionEngine engine;

            // iterate through testDict
            foreach (string word in words)
            {
                // set up confusion matrix tallies for this word
                confusion[word] = new Dictionary<string, int>();
                foreach (string otherWord in words)
                {
                    confusion[word][otherWord] = 0;
                }
                confusion[word]["UNRECOGNIZED"] = 0;

                string actual = word;

                foreach (string wavfile in testDict[word])
                {
                    engine = lex4all.EngineControl.getEngine();
                    Grammar evalGram = getEvalGram(words, lexFile);
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

            string report = GetReport(total, correct, incorrect, unrec);

            Dictionary<string, object> evalResults = new Dictionary<string, object>();
            evalResults["report"] = report;
            evalResults["confusion"] = confusion;

            return evalResults;

        }



        /// <summary>
        /// Gets a string reporting the evaluation statistics (to be displayed/written to log).
        /// </summary>
        private static string GetReport(int total, int correct, int incorrect, int unrec)
        {
            float pctCorrect = (float)correct / (float)total;
            float pctIncorrect = (float)incorrect / (float)total;
            float pctUnrec = (float)unrec / (float)total;

            object[] stats = new object[7];
            stats[0] = total;
            stats[1] = correct;
            stats[2] = pctCorrect;
            stats[3] = incorrect;
            stats[4] = pctIncorrect;
            stats[5] = unrec;
            stats[6] = pctUnrec;

            string template = @"
Evaluation results:

Words tested:   {0}

Correct:        {1} ({2:0.00}%)
Incorrect:      {3} ({4:0.00}%)
Unrecognized:   {5} ({6:0.00}%)";

            string report = String.Format(template, stats);

            return report;
        }
    }
}
