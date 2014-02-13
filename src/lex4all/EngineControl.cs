using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lex4all
{
    public static class EngineControl
    {
        /// <summary>
        /// creates engine and sets properties
        /// </summary>
        /// <returns>
        /// the engine used for recognition
        /// </returns>
        public static SpeechRecognitionEngine getEngine () {

            Console.WriteLine("Building recognition engine");

            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            
            // set confidence threshold(s)
            sre.UpdateRecognizerSetting("CFGConfidenceRejectionThreshold", 0);

            // add event handlers
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(sre_SpeechRecognitionRejected);

            Console.WriteLine("Done.");
            return sre; 
        }

        /// <summary>
        /// handles the speech recognized event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.Write("Recognized text: " + e.Result.Text);
            Console.WriteLine("\tPronunciation: " + e.Result.Words[0].Pronunciation);
            
        }

        static void sre_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Console.WriteLine("Recognition rejected.");
        }

        static void sre_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            Console.WriteLine("Hypothesized: " + e.Result.Text + "\t" + e.Result.Words[0].Pronunciation + "\t" + e.Result.Confidence.ToString());
        }


    }
}
