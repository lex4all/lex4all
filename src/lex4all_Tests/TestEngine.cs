using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Speech.Recognition;
using lex4all.EngineControl;

namespace lex4allUnitTests
{
    [TestClass]
    class TestEngine
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
                testEngine.SetInputToWaveFile("01_ookan_A_1.wav");
                RecognitionResult thisResult = testEngine.Recognize();
            }

            catch (Exception e)
            {
                // assert false case
                Assert.IsTrue(false);
            }

            // assert true case
            Assert.IsTrue(true);
        }
    }

}
