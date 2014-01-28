using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lex4allGUI
{
    public partial class RecordForm : Form
    {
        public static lex4allRecording.Recorder recorder;

        public RecordForm()
        {
            InitializeComponent();
        }

        private void RecordForm_Load(object sender, EventArgs e)
        {

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
