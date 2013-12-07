using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lex4all;

namespace lex4allGUI
{
    public partial class lex4allForm : Form
    {
        public Dictionary<String, String[]> wavDict = new Dictionary<string, string[]>();
        

        public lex4allForm()
        {
            InitializeComponent();
        }



        private void chooseWav_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string wav in openFileDialog1.FileNames)
                {
                    listView1.Items.Add(wav);
                }

            }
        }

        private void addWord_Click(object sender, EventArgs e)
        {

        }

        private void audioOK_Click(object sender, EventArgs e)
        {
            string word = word1.Text;
            List<String> wavList = new List<string>();
            foreach (ListViewItem item in listView1.Items)
            {
                wavList.Add(item.Text);
            }

            String[] wavs = wavList.ToArray();
            wavDict[word] = wavs;

            this.Controls.RemoveByKey("audioOK");
            this.Controls.RemoveByKey("label3");
            this.Controls.RemoveByKey("listView1");

            chooseWav.Text = wavDict[word].Length.ToString() + " files selected";
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            startButton.Text = "Working...";
            lex4all.Program.BuildLexicon(wavDict, "testGUIoutput.pls");
            startButton.Text = "Done!";
        }
    }
}
