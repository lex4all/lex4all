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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the lex4all Lexicon Builder!");
            Console.WriteLine();

            Dictionary<String, String[]> wavDict = GatherData();

            Console.Write("Enter a name for the lexicon file (e.g. \"mylex.pls\"): ");
            String lexFile = Console.ReadLine();


            WriteLexicon(wavDict, lexFile);

            Console.ReadKey();

        }

        static Dictionary<String, String[]> GatherData()
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

        static void WriteLexicon(Dictionary<String, String[]> vocabDict, String filename)
        {
            Console.Write("Writing lexicon to {0}... ", filename);
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

            lexDoc.Save(filename);
            Console.WriteLine("Done.");
        }
    }
}
