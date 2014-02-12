using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace lex4allUnitTests
{
    [TestClass]
    public class TestDiscrimTrain
    {
        
        string lexPath = @"C:\Users\Anjana\Desktop\lexicons\w1_5p_A_all.pls"; // CHANGE THIS

        [TestMethod]
        public void TestGetTrainingLexDict()
        {
            // arrange
            Dictionary<string, string[]> lexDict = lex4all.DiscriminativeTraining.XmlToDict(lexPath);

            try
            {
                // act
                Dictionary<string, string[]> trainingDict = lex4all.DiscriminativeTraining.GetTrainingLexDict(lexDict);
               
                //assert 
                Assert.AreNotEqual(lexDict, trainingDict);
            }
            catch (Exception ex)
            {
                // assert failed
                Console.WriteLine(ex.Message);
                Assert.Fail();   
            }
           
        }
    }
}
