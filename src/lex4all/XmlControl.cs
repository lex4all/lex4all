using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using System.IO;


namespace lex4all
{
    public class XmlControl
    {
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
                    new XAttribute(XNamespace.Xml + "lang", EngineControl.Language),
                    new XAttribute("alphabet", "x-microsoft-" + GrammarControl.phoneticAlphabet),   // dynamically set the phonetic alphabet type
                    vocabDict.Keys.Where(x => vocabDict[x].Length > 0).Select(x => new XElement(ns + "lexeme",
                        new XElement(ns + "grapheme", x),
                        vocabDict[x].Select(y => new XElement(ns + "phoneme", y))))));

            return lexDoc;
        }

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
    }
}
