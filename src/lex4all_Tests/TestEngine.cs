using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Speech.Recognition;
using lex4all;

namespace lex4allUnitTests
{
    [TestClass]
    public class TestEngine
    {
        // tests for exceptions in getEngine()
        [TestMethod]
        public void TestGetEngine()
        {
            // arrange
            SpeechRecognitionEngine testEngine = lex4all.EngineControl.getEngine();

            try
            {
                // act
                testEngine.SetInputToWaveFile("../../../../data/audio/yor/14_ogorun_B_4.wav");
                RecognitionResult thisResult = testEngine.Recognize();
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
