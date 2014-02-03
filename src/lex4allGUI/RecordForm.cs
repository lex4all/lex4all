using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lex4allRecording;

namespace lex4allGUI
{
    public partial class RecordForm : Form
    {
        public lex4allRecording.Recorder recorder;

        public RecordForm()
        {
            InitializeComponent();
            recorder = new lex4allRecording.Recorder();
            recorder.PassSampleEvent += HandlePassSampleEvent;
            
        }

        private void RecordForm_Load(object sender, EventArgs e)
        {
            
        }

        void HandlePassSampleEvent(object sender, lex4allRecording.SampleEventArgs e)
        {
            float sample = e.sample32;
            
            // update progress bar
            progressBar1.Value = (int)(sample * 100);
            System.Console.WriteLine((int)(sample * 100));
        }

        // Record and save a wave file
        private void recordButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                recorder = new lex4allRecording.Recorder();
                recorder.Record(saveFileDialog1.FileName);
            }

        }

        private void stopRecButton_Click(object sender, EventArgs e)
        {
            recorder.StopRecording();
        }
    }
}
