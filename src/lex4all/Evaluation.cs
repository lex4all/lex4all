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
        /// Performs recognition and computes accuracy on the given testing files.
        /// </summary>
        /// <param name="TestDict">Keys are words, values are lists of audio file names</param>
        /// <param name="evalGram">Grammar object referencing correct lexicon</param>
        public static Dictionary<string, object> Evaluate(Dictionary<String, String[]> testDict, Grammar evalGram)
        {
            SpeechRecognitionEngine engine;
            int total = testDict.Keys.Count;
            int correct = 0;
            int incorrect = 0;
            int unrec = 0;
            Dictionary<string, Dictionary<string, int>> confusion = new Dictionary<string, Dictionary<string, int>>();

            foreach (string word in testDict.Keys)
            {
                string actual = word;
                foreach (string wavfile in testDict[word])
                {
                    engine = lex4all.EngineControl.getEngine();
                    //Grammar evalGram = new Grammar(evalGramFilename);
                    engine.LoadGrammar(evalGram);
                    engine.SetInputToWaveFile(wavfile);

                    Debug.Write(actual + " ");
                    RecognitionResult result = engine.Recognize();

                    if (result == null)
                    {
                        Debug.WriteLine("unrecognized");
                        unrec++;
                    }
                    else
                    {
                        Debug.WriteLine(result.Text + " " + result.Confidence);
                        if (result.Text == actual)
                        {
                            correct++;

                        }
                        else
                        {
                            incorrect++;
                        }
                    }

                }
            }

            string report = GetReport(total, correct, incorrect, unrec);

            Dictionary<string, object> evalResults = new Dictionary<string, object>();
            evalResults["report"] = report;
            evalResults["confusion"] = confusion;

            return evalResults;

        }

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
