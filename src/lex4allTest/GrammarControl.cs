using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition.SrgsGrammar;

namespace lex4all
{
    class GrammarControl
    {
        /* IS USED BY THE ALGORITHM TO CREATE THE SUPER WILDCARD GRAMMAR
           THE READPATH IS THE PATH TO THE wildcard.txt FILE WHICH CONTAINS ALL POSSIBLE PHONEME COMBINATIONS */
        public SrgsDocument getInitialGrammar (String readPath) {
            
            Console.WriteLine("Building grammar...");

            // SET UP BASIC WILDCARD RULE
            SrgsOneOf wildOneOf = new SrgsOneOf();

            // READ PHONEME WILDCARD FROM TEXT FILE. ALL COMBINATIONS ARE THEN ADDED TO THE BASIC RULE
            string[] words = System.IO.File.ReadAllLines(readPath);
            foreach (string word in words) {
                if (word.Contains("\n"))
                {
                    Console.WriteLine("Found a newline in line {0}", word);
                    break;
                }
                else
                {
                    // MAKE GRAMMAR ITEM/TOKEN FOR EACH WILDCARD "WORD"
                    string pron = word;
                    string text = word.Replace(" ",".");
                    SrgsToken thisToken = new SrgsToken(text);
                    thisToken.Pronunciation = pron;
                    SrgsItem thisItem = new SrgsItem();
                    thisItem.Add(thisToken);
                    wildOneOf.Add(thisItem);
                }
            }

            // CREATE GRAMMAR RULES
            SrgsRule wildRule = new SrgsRule("Wildcard");
            wildRule.Scope = SrgsRuleScope.Public;
            wildRule.Elements.Add(wildOneOf);
            SrgsRule superRule = new SrgsRule("SuperWildcard");
            superRule.Scope = SrgsRuleScope.Public;
            SrgsRuleRef wildRef = new SrgsRuleRef(wildRule);
            SrgsItem superItem = new SrgsItem(0, 10);
            superItem.Add(wildRef);
            superRule.Elements.Add(superItem);

            // CREATE DOCUMENT AND ADD RULES
            SrgsDocument gramDoc = new SrgsDocument();
            gramDoc.PhoneticAlphabet = SrgsPhoneticAlphabet.Ups;
            gramDoc.Culture = new System.Globalization.CultureInfo(lang);
            gramDoc.Rules.Add(new SrgsRule[] { superRule, wildRule });
            gramDoc.Root = superRule;

            // REPORT
            Console.WriteLine("Done.");

            // OUTPUT INITIAL GRAMMAR
            Console.WriteLine("");
            return gramDoc;
        }

        /* THROUGHOUT THE ALGORITHM'S PASSES THE GRAMMAR IS UPDATED WITH THE RECEIVED PREFIX PHONEMES */
        public SrgsDocument updateGrammar (String[] prefixes, SrgsDocument doc, int passNum, String preReadPath) {

            Console.WriteLine("Prefixing grammar with phonemes from pass {0}...", passNum-1);

            // READ PREFIX WILDCARD FROM TEXT FILE 
            //(this is a smaller wildcard with just 1 and 2 phonemes which, with the prefix, makes up the first word of superwildcard grammar)

            string[] words = System.IO.File.ReadAllLines(preReadPath);

            // SET UP BASIC WILDCARD ONEOF
            SrgsOneOf prefixOneOf = new SrgsOneOf();

            // MAKE GRAMMAR ITEM/TOKEN FOR PREFIX + EACH WILDCARD "WORD"
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

            // CREATE GRAMMAR RULES
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

            // UPDATE DOCUMENT BY ADDING PREFIXED RULES
            doc.Rules.Clear();
            doc.Rules.Add(new SrgsRule[] {newSuperRule, prefixRule, wildRule});
            doc.Root = newSuperRule;

            // REPORT
            Console.WriteLine("Done.");
            
            return doc;

        }

    }
}
