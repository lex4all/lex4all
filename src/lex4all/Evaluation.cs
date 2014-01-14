using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;

namespace lex4all
{
    public static class Evaluation
    {

        /// <summary>
        /// Performs recognition and computes accuracy on the given testing files.
        /// </summary>
        /// <param name="TestDict">Keys are words, values are lists of audio file names</param>
        public static void Test(Dictionary<String, String[]> testDict, string evalGramFilename)
        {
            SpeechRecognitionEngine engine;
            int total = testDict.Keys.Count;
            int correct = 0;
            int incorrect = 0;
            int unrec = 0;
            Dictionary<string, Dictionary<string, int>> confusion = new Dictionary<string, Dictionary<string, int>>();

            foreach (string word in testDict.Keys)
            {
                string actual = word;
                foreach (string wavfile in testDict[word])
                {
                    engine = lex4all.EngineControl.getEngine();
                    Grammar evalGram = new Grammar(evalGramFilename);
                    engine.LoadGrammar(evalGram);
                    engine.SetInputToWaveFile(wavfile);

                    Console.Write(actual + " ");
                    RecognitionResult result = engine.Recognize();

                    if (result == null)
                    {
                        Console.WriteLine("unrecognized");
                        unrec++;
                    }
                    else
                    {
                        Console.WriteLine(result.Text + " " + result.Confidence);
                        if (result.Text == actual)
                        {
                            correct++;

                        }
                        else
                        {
                            incorrect++;
                        }
                    }

                }
            }

            throw new NotImplementedException();

        }
    }
}
