using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System.Collections.Generic;


namespace lex4allUnitTests
{
    [TestClass]
    public class TestGrammar
    {
        // tests getIntitialGrammar
        [TestMethod]
        public void TestGetInitialGrammar()
        {
            try
            {
                // arrange + act
                SrgsDocument initGrammar = lex4all.GrammarControl.getInitialGrammar();
            }
            catch (Exception e)
            {
                // assert false case
                Console.WriteLine(e.Message);
                Assert.IsTrue(false);
            }
            
            // assert true case
            Assert.IsTrue(true);

        }

        // tests updateGrammar
        [TestMethod]
        public void TestUpdateGrammar()
        {
            try
            {
                // arrange + act
                SrgsDocument initGrammar = lex4all.GrammarControl.getInitialGrammar();
                List<String> prefixes = new List<String>();
                prefixes.Add("A");
                prefixes.Add("B");
                prefixes.Add("C");
                SrgsDocument updatedGrammar = lex4all.GrammarControl.updateGrammar(prefixes, initGrammar, 1);
            }
            catch (Exception e)
            {
                // assert false case
                Console.WriteLine(e.Message);
                Assert.IsTrue(false);
            }

            // assert true case
            Assert.IsTrue(true);
        }
    
    }
}
