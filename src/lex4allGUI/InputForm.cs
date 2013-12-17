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
    public partial class InputForm : Form
    {
        //public Dictionary<String, String[]> wavDict = new Dictionary<string, string[]>();
        

        public InputForm()
        {
            InitializeComponent();
        }



        private void chooseWav_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string wav in openFileDialog1.FileNames)
                {
                    int alreadyIn = 0;

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Text.Equals(wav))
                        {
                            alreadyIn = 1;
                        }
                    }

                    if (alreadyIn == 0)
                    {
                    listView1.Items.Add(wav);
                    }
                }
            }
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

            if (word == "")
            {
                MessageBox.Show("Please enter a word.", "Error: Word field is empty");
                return;
            }
            else if (wavs.Length == 0)
            {
                MessageBox.Show("Please choose one or more audio files.", "Error: No audio files selected");
            }
            else
            {
                lex4allGUI.MainForm.wavDict[word] = wavs;
                lex4allGUI.Program.main.updateListView();

                this.Close();
                lex4allGUI.Program.main.Show();

                //this.Controls.RemoveByKey("audioOK");
                //this.Controls.RemoveByKey("label3");
                //this.Controls.RemoveByKey("listView1");

                //chooseWav.Text = wavDict[word].Length.ToString() + " files selected";
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
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }


        
    }
}
