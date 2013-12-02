using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System.IO;

namespace lex4all
{
    public class GrammarControl
    {  
        /// <summary>
        /// is used by the algorithm to build the super wildcard grammar
        /// </summary>
        /// <param name="readPath">
        /// location of the wildcard.txt file which contains all possible phoneme combinations
        /// </param>
        /// <returns>
        /// a document object representing the grammar
        /// </returns>
        public static SrgsDocument getInitialGrammar (String readPath) {
            
            Console.WriteLine("Building grammar...");

            // set up basic wildcard rule
            SrgsOneOf wildOneOf = new SrgsOneOf();

            // read phoneme wildcard from text file. all combinations are then added to the basic rule
            // string[] sfdasf = System.IO.File.ReadAllLines(readPath);
            StreamReader rd = new StreamReader(readPath);
            string allWords = rd.ReadToEnd();
            string[] words = allWords.Split(new string[] {" ","\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words) {
                if (word.Contains("\n"))
                {
                    Console.WriteLine("Found a newline in line {0}", word);
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
            gramDoc.PhoneticAlphabet = SrgsPhoneticAlphabet.Ups;
            gramDoc.Culture = new System.Globalization.CultureInfo("en-US");
            gramDoc.Rules.Add(new SrgsRule[] { superRule, wildRule });
            gramDoc.Root = superRule;

            // report
            Console.WriteLine("Done.");

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
        public static SrgsDocument updateGrammar (List<String> prefixes, SrgsDocument doc, int passNum, String preReadPath) {

            Console.WriteLine("Prefixing grammar with phonemes from pass {0}...", passNum-1);

            // read prefix wildcard from text file 
            //(this is a smaller wildcard with just 1 and 2 phonemes which, with the prefix, makes up the first word of superwildcard grammar)

            string[] words = System.IO.File.ReadAllLines(preReadPath);

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
