using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace lex4allUnitTests
{
    [TestClass]
    public class TestDiscrimTrain
    {
        
        public string lexPath = @"C:\Users\Anjana\Desktop\lexicons\w1_5p_A_all.pls"; // CHANGE THIS


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

        [TestMethod]
        public void TestRunTraining()
        {
            //arrange
            Dictionary<string, string[]> wavDict = new Dictionary<string, string[]>();
            wavDict.Add("ookan", new string[] {@"C:\Users\Anjana\Desktop\audio\01_ookan_B_1.wav",
                @"C:\Users\Anjana\Desktop\audio\01_ookan_B_2.wav",
                @"C:\Users\Anjana\Desktop\audio\14_ogorun_B_3.wav", 
                @"C:\Users\Anjana\Desktop\audio\14_ogorun_B_4.wav", 
                @"C:\Users\Anjana\Desktop\audio\14_ogorun_B_5.wav", });
            wavDict.Add("ogorun", new string[] {@"C:\Users\Anjana\Desktop\audio\14_ogorun_A_1.wav",
                @"C:\Users\Anjana\Desktop\audio\14_ogorun_A_2.wav",
                @"C:\Users\Anjana\Desktop\audio\14_ogorun_A_3.wav", 
                @"C:\Users\Anjana\Desktop\audio\14_ogorun_A_4.wav", 
                @"C:\Users\Anjana\Desktop\audio\14_ogorun_A_5.wav", });

            Dictionary<string, string[]> lexDict = lex4all.DiscriminativeTraining.XmlToDict(@"C:\Users\Anjana\Desktop\discrim.pls");


            try
            {
                //act
                //string report;
                //lex4all.Evaluation.Evaluate(wavDict, @"C:\Users\Anjana\Desktop\discrim.pls", out report);
                Dictionary<string, string[]> newLexDict = lex4all.DiscriminativeTraining.RunTrainingPass(lexDict, wavDict);
                //assert
                foreach (string word in lexDict.Keys)
                {

                    Console.WriteLine(word + "\tin newLexDict: " + newLexDict.ContainsKey(word).ToString());
                    Console.WriteLine("lexDict[word]: " + String.Join(",", lexDict[word]));
                    Console.WriteLine("newLexDict[word]: " + String.Join(",", newLexDict[word]));
                }
                Assert.AreNotEqual(lexDict, newLexDict);

                
            }
            catch (Exception ex)
            {
                //assert failed
                Console.WriteLine("Error: " + ex.Message);
                Assert.Fail();
            }

        }

    }
}
