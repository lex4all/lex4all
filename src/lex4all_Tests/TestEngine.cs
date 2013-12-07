using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.AudioFormat;

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
                testEngine.SetInputToAudioStream(lex4all.Properties.Resources.sampleAudio, 
                    new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));
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
