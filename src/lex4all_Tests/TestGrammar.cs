using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Speech.Recognition;
using lex4all;
using Microsoft.Speech.Recognition.SrgsGrammar;

namespace lex4allUnitTests
{
    [TestClass]
    public class TestGrammar
    {
        // tests getIntitialGrammar
        [TestMethod]
        public void TestGetInitialGrammar()
        {
            // arrange
            SrgsDocument initGrammar = lex4all.GrammarControl.getInitialGrammar();
            
            // assert
            Assert.AreEqual(2,initGrammar.Rules.Count);

        }

        // tests updateGrammar
        [TestMethod]
        public void TestUpdateGrammar()
        {
        }
    
    }
}
