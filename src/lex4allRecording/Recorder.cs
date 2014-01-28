using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;

namespace lex4allRecording
{
    public class Recorder
    {
        public static NAudio.Wave.WaveFileWriter waveFile;
        public static NAudio.Wave.WaveIn waveIn;

        public void Record(String filename)
        {
            // default device
            int waveInDevice = 0;
            waveIn = new NAudio.Wave.WaveIn();
            waveIn.DeviceNumber = waveInDevice;
            int sampleRate = 8000; // 8 kHz
            int channels = 1; // mono
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(sampleRate, channels);
            waveFile = new NAudio.Wave.WaveFileWriter
            (filename, new NAudio.Wave.WaveFormat(8000, 1));

            waveIn.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(waveIn_RecordingStopped);

            waveIn.StartRecording();
            
            
        }

        public void StopRecording()
        {
            waveIn.StopRecording();
            
        }

        // recording event
        void waveIn_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        // recording stopped event
        void waveIn_RecordingStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            if (waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

        }

        public void checkLevel()
        {

        }

        public static void Main(string[] args)
        {

        }
    }
}
