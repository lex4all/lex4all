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

        /// <summary>
        /// constructs the recorder which means setting up a first input stream 
        /// that is passed to the volume control
        /// </summary>
        public Recorder()
        {
            // running recorder to determine sound level
            //int waveInDevice = 0;
            //waveIn = new NAudio.Wave.WaveIn();
            //waveIn.DeviceNumber = waveInDevice;
            int sampleRate = 8000; // 8 kHz
            int channels = 1; // mono
            //waveIn.WaveFormat = new NAudio.Wave.WaveFormat(sampleRate, channels);

            //waveIn.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(waveIn_DataAvailable);

            aggregator = new SampleAggregator();
            //waveIn.StartRecording();
        }

        /// <summary>
        /// saves a recording to a temporary file; a new input stream is used
        /// </summary>
        /// <param name="filename"></param>
        public void Record(String filename)
        {
            waveFile = new NAudio.Wave.WaveFileWriter(filename, new NAudio.Wave.WaveFormat(8000, 1));

            waveIn = new NAudio.Wave.WaveIn();
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(8000, 1);
            waveIn.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(waveIn_RecordingStopped);

            waveIn.StartRecording();
            
            
        }

        /// <summary>
        /// stops recording and triggers the corresponding event
        /// </summary>
        public void StopRecording()
        {
            waveIn.StopRecording();
            //waveFile = null;
            
        }

        /// <summary>
        /// input stream event; basically triggered the whole time
        /// TODO: split in two separate events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void waveIn_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            // data is passed over to determine sound level and visualize it
            //for (int index = 0; index < e.BytesRecorded; index += 2)
            //{
            //    // transform each sample (16 bit: 2 bytes: 2 index steps) from the byte buffer
            //    short sample = (short)((e.Buffer[index + 1] << 8) |
            //                            e.Buffer[index + 0]);
            //    float sample32 = sample / 32768f;
            //    // passing over to visualization if certain amount of samples is reached
            //    if (aggregator.passSample(sample32) == 1)
            //    {
            //        // only pass over maximum or minimum
            //        ProcessSample(Math.Max(aggregator.MaxSample, Math.Abs(aggregator.MinSample)));
            //        aggregator.MaxSample = 0;
            //        aggregator.MinSample = 0;
            //    }
            //}

            // if sound is recorded, it is written to file
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        /// <summary>
        /// when recording is stopped the current input stream and filewriter are discarded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        public void SetVolume(int percentage)
        {
            int waveInDeviceNumber = 0;
            var mixerLine = new NAudio.Mixer.MixerLine((IntPtr)waveInDeviceNumber,
                                           0, NAudio.Mixer.MixerFlags.WaveIn);
            foreach (var control in mixerLine.Controls)
            {
                if (control.ControlType == NAudio.Mixer.MixerControlType.Volume)
                {
                    NAudio.Mixer.UnsignedMixerControl volumeControl = control as NAudio.Mixer.UnsignedMixerControl;
                    volumeControl.Percent = (double) percentage;
                    break;
                }
            }
        }

        public int GetVolume()
        {
            int waveInDeviceNumber = 0;
            var mixerLine = new NAudio.Mixer.MixerLine((IntPtr)waveInDeviceNumber,
                                           0, NAudio.Mixer.MixerFlags.WaveIn);
            foreach (var control in mixerLine.Controls)
            {
                if (control.ControlType == NAudio.Mixer.MixerControlType.Volume)
                {
                    NAudio.Mixer.UnsignedMixerControl volumeControl = control as NAudio.Mixer.UnsignedMixerControl;
                    return (int)volumeControl.Percent;
                }
                
            }

            return -1;
        }

        public static void Main(string[] args)
        {

        }
    }
}
