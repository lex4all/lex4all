using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System.IO;
using System.Diagnostics;

namespace lex4all
{
    public static class GrammarControl
    {

        /// <summary>
        /// Stores the currently appropriate phonetic alphabet used for the selected source language.
        /// </summary>

        public static string phoneticAlphabet = "ups";

        /// <summary>
        /// Stores the currently selected wildcard for building the initial training grammar.
        /// </summary>
        private static string wildcardFile = lex4all.Properties.Resources.en_US_wildcard1;

        /// <summary>
        /// Stores the currently selected wildcard for updating the grammar with prefixes.
        /// </summary>
        private static string prefixWildcardFile = lex4all.Properties.Resources.en_US_wildcard1;

        /// <summary>
        /// Dictionary of the wildcard resource files organized by language.
        /// Keys are culture codes as strings (e.g. "en-US") of each supported language.
        /// Values are Dictionaries with three key-value pairs: 
        ///     "1" - single-phoneme wildcard file (for faster implementation), 
        ///     "12" - two-phoneme wildcard (for prefix grammars in original implementation),
        ///     "123" - three-phoneme wildcard (for initial grammar in original implementation).
        /// </summary>
        public static Dictionary<string, Dictionary<string, string>> AvailableWildcards = new Dictionary<string, Dictionary<string, string>>()
        {
            {"en-US", 
                new Dictionary<string, string>()
                {
                    {"1", lex4all.Properties.Resources.en_US_wildcard1},
                    {"12", lex4all.Properties.Resources.en_US_wildcard12},
                    {"123", lex4all.Properties.Resources.en_US_wildcard123}
                }
            },
            {"fr-FR", 
                new Dictionary<string, string>()
                {
                    {"1", lex4all.Properties.Resources.fr_FR_wildcard1},
                    {"12", lex4all.Properties.Resources.fr_FR_wildcard12},
                    {"123", lex4all.Properties.Resources.fr_FR_wildcard123}
                }
            },

             {"de-DE",
                new Dictionary<string, string>()
                {
                    {"1", lex4all.Properties.Resources.de_DE_wildcard1},
                    {"12", lex4all.Properties.Resources.de_DE_wildcard12},
                    {"123", lex4all.Properties.Resources.de_DE_wildcard123}
                }
            },

             {"ja-JP",
                new Dictionary<string, string>()
                {
                    {"1", lex4all.Properties.Resources.ja_JP_wildcard1},
                    {"12", lex4all.Properties.Resources.ja_JP_wildcard12},
                    {"123", lex4all.Properties.Resources.ja_JP_wildcard123}
                }
            },

             {"zh-CN",
                new Dictionary<string, string>()
                {
                    {"1", lex4all.Properties.Resources.zh_CN_wildcard1},
                    {"12", lex4all.Properties.Resources.zh_CN_wildcard12}
                   
                }
            }
        };

        ///// <summary>
        ///// Enumeration to hold training options.
        ///// Short = faster implementation, Long = original implementation
        ///// </summary>
        //public enum Wildcards { Short, Long };

        /// <summary>
        /// Stores the currently selected training option ("short" or "long")
        /// </summary>
        private static string wildcardLength = "short";

        /// <summary>
        /// Accesses the currently selected training option ("short" or "long")
        /// </summary>
        public static string WildcardLength 
        { 
            get { return wildcardLength; } 
            set 
            {
                if (new string[] { "short", "long" }.Contains(value) == false)
                {
                    throw new ArgumentException("value must be \"short\" or \"long\"");
                }
                wildcardLength = value; 
            } 
        }

        /// <summary>
        /// Sets the grammar to use the correct wildcard file(s) for training.
        /// Uses the currently selected recognizer language (EngineControl.Language)
        /// </summary>
        public static void setWildcards()
        {
            if (wildcardLength == "long")
            {
                wildcardFile = AvailableWildcards[EngineControl.Language]["123"];
                prefixWildcardFile = AvailableWildcards[EngineControl.Language]["12"];
            }
            else if (wildcardLength == "short")
            {
                wildcardFile = AvailableWildcards[EngineControl.Language]["1"];
                prefixWildcardFile = AvailableWildcards[EngineControl.Language]["1"];
            }
        }

        /// <summary>
        /// is used by the algorithm to build the super wildcard grammar
        /// </summary>
        /// <param name="readPath">
        /// location of the wildcard.txt file which contains all possible phoneme combinations
        /// </param>
        /// <returns>
        /// a document object representing the grammar
        /// </returns>
        public static SrgsDocument getInitialGrammar() {
            
            Console.WriteLine("Building initial grammar...");

            // set up basic wildcard rule
            SrgsOneOf wildOneOf = new SrgsOneOf();

            // read phoneme wildcard from text file. all combinations are then added to the basic rule
            // string[] sfdasf = System.IO.File.ReadAllLines(readPath);
            // StreamReader rd = new StreamReader(readPath);
            // string allWords = rd.ReadToEnd();
            //string wildcardFile = lex4all.Properties.Resources.en_US_wildcard;
            
            //string[] words = wildcardFile.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            string[] words = wildcardFile.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            Debug.WriteLine(String.Format("After split, words has length {0}", words.Length));
            foreach (string word in words) {
                if (word.Contains("\n"))
                {
                    Debug.WriteLine(String.Format("Found a newline in line {0}", word));
                    break;
                }
                else
                {
                    // make grammar item/token for each wildcard "word"
                    string pron = word;
                    string text = word.Replace(" ",".");
                    SrgsToken thisToken = new SrgsToken(text);
                    thisToken.Pronunciation = pron;
                    SrgsItem thisItem = new SrgsItem();
                    thisItem.Add(thisToken);
                    wildOneOf.Add(thisItem);
                    Debug.WriteLine(String.Format("Wrote {0} to wildOneOf", word));
                }
            }

            // create grammar rules
            SrgsRule wildRule = new SrgsRule("Wildcard");
            wildRule.Scope = SrgsRuleScope.Public;
            wildRule.Elements.Add(wildOneOf);
            SrgsRule superRule = new SrgsRule("SuperWildcard");
            superRule.Scope = SrgsRuleScope.Public;
            SrgsRuleRef wildRef = new SrgsRuleRef(wildRule);
            SrgsItem superItem = new SrgsItem(0, 10);
            superItem.Add(wildRef);
            superRule.Elements.Add(superItem);

            // create document and add rules
            SrgsDocument gramDoc = new SrgsDocument();

            //Dynamically allocate the  correct phonetic alphabet depending on the language of choice
            if (EngineControl.Language.Equals("zh-CN") || EngineControl.Language.Equals("de-DE"))
            {
                gramDoc.PhoneticAlphabet = SrgsPhoneticAlphabet.Sapi;
                phoneticAlphabet = "sapi";

            }
            else if (EngineControl.Language.Equals("ja-JP"))
            {
                gramDoc.PhoneticAlphabet = SrgsPhoneticAlphabet.Ipa;
                phoneticAlphabet = "ipa";
            }
            else

            {
                gramDoc.PhoneticAlphabet = SrgsPhoneticAlphabet.Ups; // This is the default phonetic alphabet setting
                phoneticAlphabet = "ups";
            }


            gramDoc.Culture = new System.Globalization.CultureInfo(EngineControl.Language);
            gramDoc.Rules.Add(new SrgsRule[] { superRule, wildRule });
            gramDoc.Root = superRule;

            // report
            Console.WriteLine(String.Format("Done. Grammar language is {0}", gramDoc.Culture));

            // output initial grammar
            Console.WriteLine("");
            return gramDoc;
        }

        /// <summary>
        /// throughout the algorithm's passes the grammar is updated with the received prefix phonemes
        /// </summary>
        /// <param name="prefixes">phonemes to be added to the front</param>
        /// <param name="doc">the previous grammar</param>
        /// <param name="passNum">the current pass number</param>
        /// <param name="preReadPath">location of an additional grammar file which is smaller to improve computation time</param>
        /// <returns>
        /// an updated grammar
        /// </returns>
        public static SrgsDocument updateGrammar (List<String> prefixes, SrgsDocument doc, int passNum) {

            Console.WriteLine("Prefixing grammar with phonemes from pass {0}...", passNum-1);
            Debug.WriteLine(String.Format("Grammar language is {0}", doc.Culture));

            // read prefix wildcard from text file 
            //(this is a smaller wildcard with just 1 and 2 phonemes which, with the prefix, makes up the first word of superwildcard grammar)

            //string prefixWildcardFile = lex4all.Properties.Resources.en_US_prefixwildcard;
            //string[] words = prefixWildcardFile.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] words = prefixWildcardFile.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            Debug.WriteLine(String.Format("After split, words has length {0}", words.Length));

            // set up basic wildcard oneof
            SrgsOneOf prefixOneOf = new SrgsOneOf();

            // make grammar item/token for prefix + each wildcard "word"
            foreach (string prefix in prefixes)
            {
                SrgsToken prefixToken = new SrgsToken(prefix.Replace(" ", "."));
                prefixToken.Pronunciation = prefix;
                SrgsItem prefixItem = new SrgsItem();
                prefixItem.Add(prefixToken);
                prefixOneOf.Add(prefixItem);
                foreach (string word in words)
                {
                    if (word.Contains("\n"))
                    {
                        Console.WriteLine("Found a newline in line {0}", word);
                        break;
                    }
                    string pron = prefix + " " + word;
                    string text = pron.Replace(" ", ".");
                    SrgsToken thisToken = new SrgsToken(text);
                    thisToken.Pronunciation = pron;
                    SrgsItem thisItem = new SrgsItem();
                    thisItem.Add(thisToken);
                    prefixOneOf.Add(thisItem);
                    
                }
            }

            // create grammar rules
            SrgsRule prefixRule = new SrgsRule("Prefixes" + (passNum-1).ToString());
            prefixRule.Scope = SrgsRuleScope.Public;
            SrgsItem prefItem = new SrgsItem(prefixOneOf);
            prefixRule.Elements.Add(prefItem);
            SrgsRuleRef prefRef = new SrgsRuleRef(prefixRule);

            SrgsRule wildRule = doc.Rules["Wildcard"];
            SrgsRuleRef wildRef = new SrgsRuleRef(wildRule);

            SrgsRule newSuperRule = new SrgsRule("SuperWildcard"+(passNum-1).ToString());
            newSuperRule.Scope = SrgsRuleScope.Public;
            newSuperRule.Elements.Add(new SrgsItem(prefRef));
            SrgsItem newSuperItem = new SrgsItem(0, 9);
            newSuperItem.Add(wildRef);
            newSuperRule.Elements.Add(newSuperItem);

            // update document by adding prefixed rules
            doc.Rules.Clear();
            doc.Rules.Add(new SrgsRule[] {newSuperRule, prefixRule, wildRule});
            doc.Root = newSuperRule;

            // report
            Console.WriteLine("Done.");
            
            return doc;

        }

    }
}
