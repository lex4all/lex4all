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

namespace lex4allGUI
{
    public partial class MainForm : Form
    {
        public static Dictionary<String, String[]> wavDict = new Dictionary<string, string[]>();
        public static int numProns = 5;

        public MainForm()
        {
            InitializeComponent();
            
        }

        public void updateListView()
        {
            // listView1.Clear();
            dataGridView1.Rows.Clear();
            if (wavDict.Count > 0)
            {
                startButton.Enabled = true;
            }

            foreach (string word in wavDict.Keys)
            {
                // this.listView1.Items.Add(word);
                dataGridView1.Rows.Add(new string[] { word, wavDict[word].Length.ToString() });
            }

            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {  
           
                startButton.Enabled = false;
                addWordButton.Enabled = false;
                dataGridView1.Enabled = false;
                startButton.Text = "Working...";
                Stopwatch watch = Stopwatch.StartNew();

                lex4all.Program.BuildLexicon(wavDict, numProns, saveFileDialog1.FileName);

                watch.Stop();
                TimeSpan time = watch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);

                MessageBox.Show("Lexicon was built in " + elapsedTime + "\n" + "Saved as " + saveFileDialog1.FileName, "Done");
                
                startButton.Text = "BUILD LEXICON";
                startButton.Enabled = true;
                addWordButton.Enabled = true;
                dataGridView1.Enabled = true;
            }
        }

        private void addWordButton_Click(object sender, EventArgs e)
        {
            InputForm wordInput = new InputForm();
            this.Hide();
            wordInput.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            { //button column is third column
                    int row = e.RowIndex;
                    string word = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    InputForm wordInput = new InputForm();
                    wordInput.word1.Text = word;
                    foreach (string wav in wavDict[word])
                    {
                        wordInput.listView1.Items.Add(wav);
                    }
                    this.Hide();
                    wordInput.Show();
                
            }
            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                int row = e.RowIndex;
                string word = dataGridView1.Rows[row].Cells[0].Value.ToString();
                if (MessageBox.Show("Are you sure you want to delete this word and its audio files?", "Remove word",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    wavDict.Remove(word);
                    updateListView();
                }
            }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Quit the lexicon builder?", "Confirm", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
           
        }

        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            if
            (MessageBox.Show("This application supports you in building your own lexicon. For further information have a look on our wikipage. Do you want to be be redirected immediately?", "Welcome to lex4all", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {System.Diagnostics.Process.Start("http://lex4all.github.io/lex4all/");}
        }

        public void UpdateProgressBar(int amount)
        {
            //progressBar.Increment(amount);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lex4allGUI.Program.start.Show();
        }
        
    }
}
