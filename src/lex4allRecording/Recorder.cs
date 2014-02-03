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
        private NAudio.Wave.WaveFileWriter waveFile;
        private NAudio.Wave.WaveIn waveIn;
        private SampleAggregator aggregator;

        public Recorder()
        {
            // running recorder to determine sound level
            int waveInDevice = 0;
            waveIn = new NAudio.Wave.WaveIn();
            waveIn.DeviceNumber = waveInDevice;
            int sampleRate = 8000; // 8 kHz
            int channels = 1; // mono
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(sampleRate, channels);

            waveIn.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(waveIn_DataAvailable);

            aggregator = new SampleAggregator();
            waveIn.StartRecording();
        }


        public void Record(String filename)
        {           
   
            waveFile = new NAudio.Wave.WaveFileWriter(filename, new NAudio.Wave.WaveFormat(8000, 1));

            waveIn.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(waveIn_RecordingStopped);

            //waveIn.StartRecording();
            
            
        }

        public void StopRecording()
        {
            waveIn.StopRecording();
            
        }

        // recording event
        void waveIn_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            // data is passed over to determine sound level and visualize it
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                // transform each sample (16 bit: 2 bytes: 2 index steps) fro the byte buffer
                short sample = (short)((e.Buffer[index + 1] << 8) |
                                        e.Buffer[index + 0]);
                float sample32 = sample / 32768f;
                // passing over to visualization if certain amount of samples is reached
                if (aggregator.passSample(sample32) == 1)
                {
                    // only pass over maximum or minimum
                    ProcessSample(Math.Max(aggregator.MaxSample, Math.Abs(aggregator.MinSample)));
                }
            }

            // if sound is recorded, it is written to file
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

        public event EventHandler<SampleEventArgs> PassSampleEvent;

        // when a sample is passed an event is triggered which is subscribed by the GUI (progress bar)
        public void ProcessSample(float sample32)
        {
            EventHandler<SampleEventArgs> handler = PassSampleEvent;
            if (handler != null)
            {
                handler(this, new SampleEventArgs(sample32));

            }
        }

        public static void Main(string[] args)
        {

        }
    }
}
