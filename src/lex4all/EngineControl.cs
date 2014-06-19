using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lex4all
{
    public static class EngineControl
    {
        /// <summary>
        /// Stores the user's language selection; default is English (US).
        /// </summary>
        private static string language = "en-US";

        /// <summary>
        /// Gets or sets recognizer language
        /// </summary>
        public static string Language { get { return language; } set { language = value; } } 


        /// <summary>
        /// Gets the available source languages, i.e. languages for which a recognizer is installed on the user's system
        /// </summary>
        /// <returns>Array of Culture codes as strings</returns>
        public static string[] getLanguageOptions() 
        {
            string[] options = (
                from info in SpeechRecognitionEngine.InstalledRecognizers() 
                //where info.Culture.Equals(System.Globalization.CultureInfo.InvariantCulture) == false
                where GrammarControl.AvailableWildcards.ContainsKey(info.Culture.ToString())
                select info.Culture.Name).ToArray();
            foreach (string option in options) 
            { 
                Debug.Write(option); 
                Debug.WriteLine(" found - available? " + GrammarControl.AvailableWildcards.ContainsKey(option).ToString());
            }
            return options;
        }


        /// <summary>
        /// creates engine and sets properties
        /// </summary>
        /// <returns>
        /// the engine used for recognition
        /// </returns>
        public static SpeechRecognitionEngine getEngine () {

            Console.WriteLine(String.Format("Building recognition engine for {0}", language));

            //SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo(language));
            
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
