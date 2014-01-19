using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;

namespace lex4all
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the lex4all Lexicon Builder!");
            Console.WriteLine();

            Dictionary<String, String[]> wavDict = GatherData();

            //Dictionary<String, String[]> lexDict = GetLexDict(wavDict);

            //XDocument lexDoc = DictToXml(lexDict);

            Console.Write("Enter a name for the lexicon file (e.g. \"mylex.pls\"): ");
            String lexFile = Console.ReadLine();

            Console.Write("Writing lexicon to {0}... ", lexFile);
            //lexDoc.Save(lexFile);
            Console.WriteLine("Done.");

            Console.ReadKey();

        }

        //public static void BuildLexicon(Dictionary<string, string[]> wavDict, string filename)
        //{
        //    Dictionary<String, String[]> lexDict = GetLexDict(wavDict);
        //    XDocument lexDoc = DictToXml(lexDict);
        //    lexDoc.Save(filename);
        //}

        /// <summary>
        /// Gets the user input of words and audio files
        /// </summary>
        /// <returns>Dictionary with words (orthographic forms) as keys and arrays of wav file paths as values</returns>
        public static Dictionary<String, String[]> GatherData()
        {
            Dictionary<String, String[]> dataDict = new Dictionary<string,string[]>();

            String moreWords = "y";

            while (moreWords == "y")
            {
                Console.Write("Enter a word: ");
                String word = Console.ReadLine();
                List<String> wavs = new List<String>();
                String moreWavs = "y";
                while (moreWavs == "y")
                {
                    Console.Write("Enter a .wav file path: ");
                    String wav = Console.ReadLine();
                    wavs.Add(wav);
                    Console.Write("Add another .wav file? (y/n): ");
                    moreWavs = Console.ReadLine();
                }

                String[] wavsArray = wavs.ToArray();
                dataDict[word] = wavsArray;

                Console.WriteLine("");
                Console.Write("Add another word? (y/n): ");
                moreWords = Console.ReadLine();
            }
            Console.WriteLine("");
            return dataDict;
        }

        /// <summary>
        /// Writes a dictionary of word:pronunciations kvps to an XML file matching PLS
        /// </summary>
        /// <param name="vocabDict">Dictionary with words (graphemes) as keys and pronunciations (phonemes) as values</param>
        /// <returns>XML file as XDocument object</returns>
        public static XDocument DictToXml(Dictionary<String, String[]> vocabDict)
        {
            XNamespace ns = @"http://www.w3.org/2005/01/pronunciation-lexicon";
            XDocument lexDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XElement(ns + "lexicon",
                    new XAttribute("version", "1.0"),
                    new XAttribute(XNamespace.Xml + "lang", "en-US"),
                    new XAttribute("alphabet", "x-microsoft-ups"),
                    vocabDict.Keys.Where(x => vocabDict[x].Length > 0).Select(x => new XElement(ns + "lexeme",
                        new XElement(ns + "grapheme", x),
                        vocabDict[x].Select(y => new XElement(ns + "phoneme", y))))));

            return lexDoc;
        }

        /// <summary>
        /// Passes the training audio files for one word to the Algorithm module for pronunciation generation
        /// </summary>
        /// <param name="wavFiles">Array of wav file paths</param>
        /// <returns>Pronunciations (phonemes)</returns>
        public static String[] GetProns(String[] wavFiles)
        {             
                String[] wavs = wavFiles;
                String[] prons = Algorithm.GeneratePronunciations(wavs);

                return prons;
        }
    }
}
