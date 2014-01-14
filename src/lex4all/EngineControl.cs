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
            //Console.WriteLine("Recognized text: " + e.Result.Text);
            
        }

    }
}
