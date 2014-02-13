using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using lex4allRecording;

namespace lex4allGUI
{
    public partial class RecordForm : Form
    {
        public lex4allRecording.Recorder recorder;
        string tempPathFile;
        int tempCounter;
        
        // indicates which action is being done 
        int recFlag;

        public RecordForm()
        {
            InitializeComponent();
            recorder = new lex4allRecording.Recorder();
            recorder.PassSampleEvent += HandlePassSampleEvent;
            recFlag = 0;
            tempCounter = 0;

            int volume = recorder.GetVolume();
            if (!(volume == -1))
            {
                trackBar1.Value = volume;
            }
            
        }

        private void RecordForm_Load(object sender, EventArgs e)
        {
            
        }

        void HandlePassSampleEvent(object sender, lex4allRecording.SampleEventArgs e)
        {
            float sample = e.sample32;
            
            // update progress bar
            progressBar1.Value = (int)(sample * 100);
        }

        // Record and save a wave file
        private void recordButton_Click(object sender, EventArgs e)
        {
            if (recFlag == 0)
            {
                // disable volume control
                trackBar1.Enabled = false;

                tempPathFile = System.IO.Path.GetTempFileName();
                tempCounter++;
                recorder.Record(tempPathFile);

                progressBar1.Style = ProgressBarStyle.Marquee;

                recFlag = 1;
                recordButton.Text = "Stop";
                saveButton.Enabled = false;
            }
            else if (recFlag == 1)
            {
                recorder.StopRecording();

                progressBar1.Style = ProgressBarStyle.Continuous;

                recFlag = 0;
                recordButton.Text = "Start";
                saveButton.Enabled = true;
                trackBar1.Enabled = true;
            }

        }

        private void stopRecButton_Click(object sender, EventArgs e)
        {
            recorder.StopRecording();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            recorder.SetVolume(trackBar1.Value);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(saveFileDialog1.FileName)) {
                    System.IO.File.Delete(saveFileDialog1.FileName);
                    // remove an overridden file from the list
                    foreach (ListViewItem item in listView1.Items) {
                        if (item.Text == saveFileDialog1.FileName)
                        {
                            listView1.Items.Remove(item);
                        }
                    }
                }

                saveButton.Enabled = false;
                System.IO.File.Move(tempPathFile, saveFileDialog1.FileName);
                listView1.Items.Add(saveFileDialog1.FileName);
                addButton.Enabled = true;
                
            }

        }

        private void rmCheckedBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    item.Remove();
                }
            }

            if (listView1.CheckedItems.Count > 0)
            {
                rmCheckedBtn.Enabled = true;
            }
            else
            {
                rmCheckedBtn.Enabled = false;
                addButton.Enabled = false;
            }
        }

        private void listView1_ItemChecked(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count > 0)
            {
                rmCheckedBtn.Enabled = true;
            }
            else
            {
                rmCheckedBtn.Enabled = false;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            List<String> recList = new List<string>();
            foreach (ListViewItem item in listView1.Items)
            {
                recList.Add(item.Text);
            }

            lex4allGUI.Program.input.updateFromRecorder(recList);
            this.Close();
            lex4allGUI.Program.input.Show();            

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if
            (MessageBox.Show("All changes will be discarded. Are you sure?", "Back to word", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                lex4allGUI.Program.input.Show();
            }
        }
    }
}
