using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lex4all
{
    class EngineControl
    {
        // CREATES ENGINE AND SETS PROPERTIES
        public SpeechRecognitionEngine getEngine (String lang) {

            Console.WriteLine("Building recognition engine for: {0}", lang);

            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            
            // SET CONFIDENCE THRESHOLD(S)
            sre.UpdateRecognizerSetting("CFGConfidenceRejectionThreshold", 0);

            // ADD EVENT HANDLERS
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

            Console.WriteLine("Done.");
            return sre; 
        }

        // HANDLE THE SPEECH RECOGNIZED EVENT
        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized text: " + e.Result.Text);
        }

    }
}
