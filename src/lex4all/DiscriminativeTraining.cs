using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using System.IO;

namespace lex4all
{
    public class DiscriminativeTraining
    {
        /// <summary>
        /// Reads in a lexicon XML file and converts it to a Dictionary for training
        /// (useful for testing, and potentially for perform discriminative training on
        /// a lexicon that's already been written, instead of one that's being written)
        /// </summary>
        /// <param name="lexFileName">Path to lexicon file</param>
        /// <returns>Dictionary with graphemes as keys and arrays of phonemes as values</returns>
        public static Dictionary<string, string[]> XmlToDict(string lexFileName)
        {
            Dictionary<string, string[]> trainingLexDict = new Dictionary<string, string[]>();

            Debug.WriteLine("Starting to read lexicon");
            try
            {
                XDocument realLexDoc = XDocument.Load(lexFileName);
                Debug.WriteLine("lexdoc created");

                XNamespace ns = "http://www.w3.org/2005/01/pronunciation-lexicon";

                foreach (XElement lexeme in realLexDoc.Root.Elements(ns + "lexeme"))
                {
                    string word = lexeme.Element(ns + "grapheme").Value;
                    List<string> pronList = new List<string>();
                    foreach (XElement phoneme in lexeme.Elements(ns + "phoneme"))
                    {
                        string pron = phoneme.Value;
                        pronList.Add(pron);
                        Debug.WriteLine(String.Format("word: {0}  pron: {1}", word, pron));
                    }

                    string[] prons = pronList.ToArray();
                    trainingLexDict[word] = prons;
               
                }

            }

            catch (Exception ex)
            {
                Debug.WriteLine("Error loading XML file. " + ex.Message);
            }

            return trainingLexDict;

        }

        /// <summary>
        /// Rewrites the lexicon to have a different "word" for each pronunciation 
        /// (allows the recognizer to distinguish individual pronunciations more easily)
        /// </summary>
        /// <param name="fullLexDict">Lexicon in Dictionary form (multiple pronunications per word)</param>
        /// <returns>Training Dictionary with only one pronunciation per "word"</returns>
        public static Dictionary<string, string[]> GetTrainingLexDict(Dictionary<string, string[]> fullLexDict)
        {
            Dictionary<string, string[]> traininglexDict = new Dictionary<string, string[]>();

            foreach (KeyValuePair<string, string[]> kvp in fullLexDict)
            {
                string word = kvp.Key;
                foreach (string pron in kvp.Value)
                {
                    string fakeWord = String.Format("{0}-{1}", word, pron);
                    traininglexDict[fakeWord] = new string[] {pron};
                    Debug.WriteLine(String.Format("Added to trainingLexDict: {0}, {1} prons: {2}", fakeWord, traininglexDict[fakeWord].Length, traininglexDict[fakeWord][0]));

                }
            }

            return traininglexDict;
        }

        /// <summary>
        /// Removes the given pronunciations from the dictionary
        /// </summary>
        /// <param name="lexDict">Dictionary to be pruned</param>
        /// <param name="badProns">Pronunciations to remove</param>
        /// <returns>Dictionary with bad pronunciations removed</returns>
        private static Dictionary<string, string[]> PruneDictionary(Dictionary<string, string[]> lexDict, List<string> badProns)
        {
            Dictionary<string, string[]> pruned = new Dictionary<string, string[]>();

            foreach (KeyValuePair<string, string[]> kvp in lexDict)
            {
                string word = kvp.Key;
                List<string> oldProns = new List<string>(kvp.Value);
                List<string> goodProns = new List<string>(oldProns.Except(badProns));
                pruned[word] = goodProns.ToArray();
            }

            return pruned;
        }

        /// <summary>
        /// One iteration step in Discriminative Training: finds the eager-error pronunciations in the dictionary and uses
        /// PruneDictionary() to remove them
        /// </summary>
        /// <param name="fullLexDict">Lexicon in Dictionary form</param>
        /// <param name="wavDict">Audio files for (discriminative) training</param>
        /// <returns>Dictionary with bad pronunciations removed</returns>
        public static Dictionary<string, string[]> RunTrainingPass(Dictionary<string, string[]> fullLexDict, Dictionary<string, string[]> wavDict)
        {
            // Get "words"for training grammar
            Dictionary<string, string[]> trainingLexDict = GetTrainingLexDict(fullLexDict);
            string[] fakeWords = trainingLexDict.Keys.ToArray();

            // Write training lexicon
            XDocument trainingLexDoc = Program.DictToXml(trainingLexDict);
            string tmpLexFile = Path.GetTempFileName();
            trainingLexDoc.Save(tmpLexFile);

            // set up list to track "flagged" pronunciations
            List<string> flagged = new List<string>();

            // "Evaluate" the training lexicon with the training audio
            string statsMsg;
            Dictionary<string, Dictionary<string, int>> confusMatrix = lex4all.Evaluation.Evaluate(wavDict, tmpLexFile, out statsMsg);
            Debug.WriteLine(statsMsg);

            // Go through the confusion matrix and flag confusing prons
            foreach (string realWord in confusMatrix.Keys)
            {
                foreach (KeyValuePair<string, int> kvp in confusMatrix[realWord])
                {
                    string fakeWord = kvp.Key;
                    string[] wordParts = fakeWord.Split('-');
                    string foundWord = wordParts[0];
                    string foundPron = wordParts[1];

                    bool same = (fakeWord == foundWord);

                    Debug.WriteLine(String.Format("actual: {0}\t\t recognized: {1}\t\t same: {2}", realWord, foundWord, same));

                    if (same == false)
                    {
                        flagged.Add(foundPron);
                        Debug.WriteLine(String.Format("Flagging this pronunciation: {0}", foundPron));
                    }
                }
            }

            Dictionary<string, string[]> prunedDict = PruneDictionary(fullLexDict, flagged);

            return prunedDict;

        }

        /// <summary>
        /// Iteratively executes RunTrainingPass() for a pre-determined number of iterations
        /// </summary>
        /// <param name="fullLexDict">Lexicon to be improved, in dictionary form</param>
        /// <param name="wavDict">Audio for (discriminative) training</param>
        /// <param name="numPasses">Desired number of iterations</param>
        /// <returns>Lexicon dictionary with bad pronunciations removed</returns>
        public static Dictionary<string, string[]> RunTraining(Dictionary<string, string[]> fullLexDict, Dictionary<string, string[]> wavDict, int numPasses)
        {
            int pass = 1;
            Debug.WriteLine(String.Format("pass #{0}", pass));
            Dictionary<string, string[]> newLexDict = RunTrainingPass(fullLexDict, wavDict);

            while (pass <= numPasses)
            {
                Debug.WriteLine(String.Format("pass #{0}", pass));
                newLexDict = RunTrainingPass(fullLexDict, wavDict);
            }

            return newLexDict;
            
        }


    }
}
