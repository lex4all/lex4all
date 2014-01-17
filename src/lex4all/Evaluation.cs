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
       

            Debug.WriteLine("Starting to read lexicon");
            XDocument lexDoc = XDocument.Load(lexFileName);
            Debug.WriteLine("lexdoc created");

            XNamespace ns = "http://www.w3.org/2005/01/pronunciation-lexicon";

            IEnumerable<XElement> childList =
                from el in lexDoc.Root.Elements(ns + "lexeme")
                select el.Element(ns + "grapheme");
            foreach (XElement e in childList)
                Debug.WriteLine(e.Value);
            
            string[] words =
                (from lexeme in lexDoc.Root.Elements(ns+"lexeme")
                select lexeme.Element(ns+"grapheme").Value).ToArray();

            Debug.WriteLine(String.Join(",", words));

            return words;

            
        }

        /// <summary>
        /// Performs recognition and computes accuracy on the given testing files.
        /// </summary>
        /// <param name="TestDict">Keys are words, values are lists of audio file names</param>
        public static void Evaluate(Dictionary<String, String[]> testDict, string evalGramFilename)
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
                    Grammar evalGram = new Grammar(evalGramFilename);
                    engine.LoadGrammar(evalGram);
                    engine.SetInputToWaveFile(wavfile);

                    Console.Write(actual + " ");
                    RecognitionResult result = engine.Recognize();

                    if (result == null)
                    {
                        Console.WriteLine("unrecognized");
                        unrec++;
                    }
                    else
                    {
                        Console.WriteLine(result.Text + " " + result.Confidence);
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

            throw new NotImplementedException();

        }
    }
}
