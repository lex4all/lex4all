using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;

namespace lex4all
{
    class Algorithm
    {
        /// <summary>
        /// Get best pronunciations for one word represented by one or more audio samples
        /// </summary>
        /// <param name="wavFiles">Array of paths to each .wav audio sample</param>
        /// <param name="lang">Culture code for desired source language (e.g. "en-US")</param>
        /// <returns>Array of pronunciations (phoneme sequences)</returns>
        public static String[] GeneratePronunciations (String[] wavFiles) {
           
            // initialize recognition engine 
            SpeechRecognitionEngine engine;

            // initialize grammar & prefix list
            SrgsDocument gramDoc = GrammarControl.getInitialGrammar();
            Grammar gram;
            List<string> prefixList;

            // initialize pass counter
            int passNumber = 0;
            int bestPass = 0;

            // initialize results-by-pass dictionary (or other collection type)
            List<Tuple<string, int, float>> passResults;
            Dictionary<int, List<Tuple<string, int, float>>> resultsByPass = new Dictionary<int, List<Tuple<string, int, float>>>();
            resultsByPass[0] = new List<Tuple<string, int, float>>();

            // initialize stopping condition(s)
            Tuple<string, int, float> best = new Tuple<string, int, float>("", 0, 0.0f);
            Tuple<string, int, float> thisBest;
            float confGain;
            bool sameAsLastSeq;
            int sameBest = 0;
            //int timeouts = 0;

            // iterate
            while (true)
            {
                // increment pass counter
                passNumber += 1; 

                // get new engine and/or unload all grammars
                engine = EngineControl.getEngine();
                engine.UnloadAllGrammars();

                // get & load grammar (report time elapsed)
                gram = new Grammar(gramDoc);
                Console.WriteLine("Loading grammar into Engine...");
                DateTime startTime = DateTime.Now;
                engine.LoadGrammar(gram);
                DateTime stopTime = DateTime.Now;
                TimeSpan elapsed = stopTime - startTime;
                Console.WriteLine("Done after {0} min {1} sec.", elapsed.Minutes, elapsed.Seconds);

                // get pass results & update results-by-pass
                passResults = MakePass(engine, wavFiles);
                resultsByPass[passNumber] = passResults;

                // check stopping condition 1: no samples recognized
                if (passResults.Count == 0)
                {
                    Console.WriteLine("Stopping: None of the samples could be recognized.");
                    bestPass = passNumber - 1;
                    break;
                }

                // check stopping condition 2: no confidence gain (min 3 iterations)
                thisBest = passResults[0];
                confGain = thisBest.Item3 - best.Item3;
                sameAsLastSeq = thisBest.Item1 == best.Item1;

                if (confGain <= 0 && passNumber > 3)
                {
                    bestPass = passNumber - 1;
                    Console.WriteLine("Stopping: No gain in confidence");
                    break;
                }
                else { best = thisBest; }

                // check stopping condition 3: same best sequence for 3 iterations
                if (sameAsLastSeq) { sameBest += 1; } else { best = thisBest; sameBest = 0; }
                if (sameBest >= 2)
                {
                    bestPass = passNumber;
                    Console.WriteLine("Stopping condition met: Same best sequence for 3 iterations");
                    break;
                }

                // extract prefixes
                prefixList = GetPrefixes(passResults, passNumber);

                // update grammar 
                gramDoc = GrammarControl.updateGrammar(prefixList, gramDoc, passNumber);

            }
            
            // return array of pronunciation sequences 
            List<Tuple<string, int, float>> bestResultList = resultsByPass[bestPass];
            String[] prons = (from result in bestResultList select result.Item1.Replace('.',' ')).ToArray();
            return prons;
        }

        /// <summary>
        /// Recognize a single audio sample against the grammar
        /// </summary>
        /// <param name="engine">Recognition engine with loaded grammar</param>
        /// <param name="wavFile">Path to .wav audio sample</param>
        /// <returns>RecognitionResult from the recognizer</returns>
        public static RecognitionResult ProcessSample (SpeechRecognitionEngine engine, String wavFile) {
            
            Console.Write("Recognizing audio file \"{0}\"...", wavFile);
            engine.SetInputToWaveFile(wavFile);
            RecognitionResult thisResult = engine.Recognize();

            if (thisResult == null) {
                Console.WriteLine("NOT recognized.");
            } else {
                Console.WriteLine("Recognized with {0} matches.", thisResult.Alternates.Count);
            }

            return thisResult;
        }

        /// <summary>
        /// Combines the results from processSample for all samples of a given word
        /// </summary>
        /// <param name="engine">Recognition engine with loaded grammar</param>
        /// <param name="wavFiles">Array of paths to each .wav audio sample</param>
        /// <returns>Sorted list of (pronunciation, #samples, totalconfidence) tuples</returns>
        public static List<Tuple<string, int, float>> MakePass (SpeechRecognitionEngine engine, String[] wavFiles) {
           
            List<Tuple<string, int, float>> passResults = new List<Tuple<string, int, float>>();
            foreach (string wav in wavFiles) {
                RecognitionResult sampleResult = ProcessSample(engine, wav);
                if (sampleResult != null) {
                    foreach (RecognizedPhrase phrase in sampleResult.Alternates) {
                        //string seq = phrase.Text.Replace(".", " ");
                        string seq = phrase.Text;
                        var alreadyIn = passResults.FirstOrDefault(x => x.Item1 == seq);
                        if (alreadyIn != null) {
                            Tuple<string, int, float> addUp = new Tuple<string, int, float>(seq, alreadyIn.Item2 + 1, alreadyIn.Item3 + phrase.Confidence);
                            passResults.Remove(alreadyIn);
                            passResults.Add(addUp);
                        } else {
                            passResults.Add(new Tuple<string, int, float>(seq, 1, phrase.Confidence));
                        }
                    }

                }
            }

            // Sorts pronunciations first by confidence and then by # of wavs that generated
            // TODO try this out the other way around
            passResults.Sort((x, y) => {
                int result = y.Item3.CompareTo(x.Item3);
                return result == 0 ? y.Item2.CompareTo(x.Item2) : result;
            });

            return passResults;
        }

        /// <summary>
        /// Extracts set of first i phonemes from each pronunciation recognized in pass i. 
        /// </summary>
        /// <param name="passResults">List of (pronunciation, #samples, totalconfidence) tuples</param>
        /// <param name="passNumber">Number of current pass (length of prefixes)</param>
        /// <returns>List of prefixes to be appended to the grammar</returns>
        public static List<string> GetPrefixes(List<Tuple<string, int, float>> passResults, int passNumber)
        {
            List<string> prefixes = new List<string>();
            foreach (Tuple<string, int, float> result in passResults)
            {
                string[] phonArray = result.Item1.Split(new string[] { " ", "." }, StringSplitOptions.RemoveEmptyEntries);
                string prefix = String.Join(" ", phonArray.Take(passNumber));
                if (!prefixes.Contains(prefix))
                {
                    prefixes.Add(prefix);
                }
            }
            return prefixes;
        }
    
    }
}
