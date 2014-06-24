using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Speech.Recognition;

namespace lex4allUnitTests
{
    [TestClass]
    public class TestProgram
    {
        //[TestMethod]
        //public void TestGetLexDict()
        //{
        //    //arrange
        //    Dictionary<String, String[]> ogorunDict = new Dictionary<string, string[]>();
        //    ogorunDict.Add("ogorun", new String[] { "../../../../data/audio/yor/14_ogorun_B_4.wav" });
            
        //    //act
        //    var lexDict = lex4all.Program.GetLexDict(ogorunDict);

        //    //assert
        //    Assert.IsInstanceOfType(lexDict, typeof(Dictionary<String, String[]>));
        //    Assert.AreEqual(lexDict.Keys.Count, 1);
        //    Assert.IsTrue(lexDict.ContainsKey("ogorun"));
        //}

        [TestMethod]
        public void TestDictToXml()
        {
            //arrange
            Dictionary<String, String[]> lexDict = new Dictionary<string, string[]>();
            lexDict.Add("testword", new String[] { "testpron1", "testpron2" });
            XNamespace ns = @"http://www.w3.org/2005/01/pronunciation-lexicon";

            //act
            XDocument xDoc = lex4all.XmlControl.DictToXml(lexDict);
            string rootName = xDoc.Root.Name.ToString();

            //assert
            Assert.AreEqual(ns + "lexicon", rootName);
            Assert.IsTrue(xDoc.Root.HasAttributes);
            Assert.IsTrue(xDoc.Root.HasElements);
        }
    }
}
