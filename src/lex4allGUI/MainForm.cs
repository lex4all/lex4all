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
using System.Xml;
using System.Xml.Linq;

namespace lex4allGUI
{
    public partial class MainForm : Form
    {
        public Dictionary<String, String[]> wavDict = new Dictionary<string, string[]>();
        public int numProns = 5;

        public MainForm()
        {
            InitializeComponent();
            
        }

        public void updateListView()
        {
            // listView1.Clear();
            wordsAudioGrid.Rows.Clear();
            if (wavDict.Count > 0)
            {
                startButton.Enabled = true;
            }

            foreach (string word in wavDict.Keys)
            {
                // this.listView1.Items.Add(word);
                wordsAudioGrid.Rows.Add(new string[] { word, wavDict[word].Length.ToString() });
            }

            // update row headers with row numbers
            foreach (DataGridViewRow row in wordsAudioGrid.Rows)
            {
                if (row.Index > -1)
                    row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            
        }

            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Check that all words have at least one audio file
            foreach (string[] wavs in wavDict.Values)
            {
                if (wavs.Length == 0)
                {
                    MessageBox.Show("Please choose one or more audio files for each word.", "Error: Not all words have audio!");
                    return;
                }
            }

            if (saveLexDialog.ShowDialog() == DialogResult.OK)
            {  
                

                startButton.Enabled = false;
                startButton.Text = "Working...";
                addWordButton.Enabled = false;
                wordsAudioGrid.Enabled = false;
                maxPronsLabel.Enabled = false;
                numPronsUpDn.Enabled = false;
                shortWildcardChkBx.Enabled = false;
                discrimTrainChkBx.Enabled = false;
                discrimPassesLabel.Enabled = false;
                discrimPassesUpDn.Enabled = false;
                Stopwatch watch = Stopwatch.StartNew();

                beingBuiltLabel.Show();
                progressLabel.Show();
                progressBar.Show();
                BuildLexicon(wavDict, numProns, saveLexDialog.FileName);

                watch.Stop();
                TimeSpan time = watch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);

                MessageBox.Show("Lexicon was built in " + elapsedTime + "\n" + "Saved as " + saveLexDialog.FileName, "Done");
                progressBar.Value = 0;
                progressBar.Hide();
                progressLabel.Hide();
                beingBuiltLabel.Hide();
                
                
                startButton.Text = "BUILD LEXICON";
                startButton.Enabled = true;
                addWordButton.Enabled = true;
                wordsAudioGrid.Enabled = true;
                maxPronsLabel.Enabled = true;
                numPronsUpDn.Enabled = true;
                shortWildcardChkBx.Enabled = true;
                discrimTrainChkBx.Enabled = true;
                discrimPassesLabel.Enabled = true;
                discrimPassesUpDn.Enabled = true;

                if (MessageBox.Show("Evaluate this lexicon now? (Clicking 'Yes' will quit the Lexicon Builder and open the Evaluation Tool.)", "Continue to evaluation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                    lex4allGUI.Program.eval = new EvalForm();
                    lex4allGUI.Program.eval.lexFile = saveLexDialog.FileName;
                    lex4allGUI.Program.eval.updateLexFile();
                    lex4allGUI.Program.eval.Show();

                }

                
            }
        }

        private void addWordButton_Click(object sender, EventArgs e)
        {
            lex4allGUI.Program.input = new InputForm();
            this.Hide();
            lex4allGUI.Program.input.Show();
        }

        private void wordsAudioGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            { //button column is third column
                    int row = e.RowIndex;
                    string word = wordsAudioGrid.Rows[row].Cells[0].Value.ToString();
                    lex4allGUI.Program.input = new InputForm();
                    lex4allGUI.Program.input.word1.Text = word;
                    foreach (string wav in wavDict[word])
                    {
                        lex4allGUI.Program.input.listView1.Items.Add(wav);
                    }
                    this.Hide();
                    lex4allGUI.Program.input.Show();
                
            }
            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                int row = e.RowIndex;
                string word = wordsAudioGrid.Rows[row].Cells[0].Value.ToString();
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

            // Populate recognizer (source language) list
            this.sourceLangBox.Items.AddRange(lex4all.EngineControl.getLanguageOptions());
            Debug.Write("en-US in sourceLangBox? ");
            Debug.WriteLine(this.sourceLangBox.Items.Contains("en-US"));
            this.sourceLangBox.SelectedItem = "en-US";
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

        public void BuildLexicon(Dictionary<string, string[]> wavDict, int numProns, string filename)
        {   
            Dictionary<String, String[]> lexDict = new Dictionary<string,string[]>();
            int wordProportion = 100/wavDict.Count;

            foreach (KeyValuePair<String, String[]> kvp in wavDict)
            {
                String word = kvp.Key;
                lexDict[word] = lex4all.Program.GetProns(kvp.Value).Take(numProns).ToArray();
                progressBar.Increment(wordProportion);
            }

            if (discrimTrainChkBx.Checked)
            {
                lexDict = lex4all.DiscriminativeTraining.RunTraining(lexDict, wavDict, (int)discrimPassesUpDn.Value);
            }

            XDocument lexDoc = lex4all.Program.DictToXml(lexDict);
            lexDoc.Save(filename);
            
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lex4allGUI.Program.start.Show();
        }

        private void wordsAudioGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                var cell = wordsAudioGrid.Rows[e.RowIndex].Cells[1];
                string word = wordsAudioGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                string ttText;
                if (wavDict[word].Count() > 0)
                {
                    string files = String.Join("\n", wavDict[word]);
                    ttText = "Selected audio files:\n" + files;
                }
                else ttText = "No audio files selected.";

                cell.ToolTipText = ttText;
            }
        }

        private void wordsAudioGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.PaintHeader(DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentBackground);

        }

        /// <summary>
        /// Old event handler for the "Faster training" (short grammar) option
        /// </summary>
        private void shortWildcardChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (shortWildcardChkBx.Checked == true)
            {
                lex4all.GrammarControl.wildcardFile = lex4all.Properties.Resources.en_US_wildcard1;
                lex4all.GrammarControl.prefixWildcardFile = lex4all.Properties.Resources.en_US_wildcard1;
            }
            else
            {
                lex4all.GrammarControl.wildcardFile = lex4all.Properties.Resources.en_US_wildcard123;
                lex4all.GrammarControl.prefixWildcardFile = lex4all.Properties.Resources.en_US_wildcard12;
            }
        }

        private void numPronsUpDn_ValueChanged(object sender, EventArgs e)
        {
            numProns = (int)numPronsUpDn.Value;
        }

        private void discrimTrainChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (discrimTrainChkBx.Checked == true)
            {
                discrimPassesLabel.Enabled = true;
                discrimPassesUpDn.Enabled = true;
            }
            else
            {
                discrimPassesLabel.Enabled = false;
                discrimPassesUpDn.Enabled = false;
            }
        }

        private void wordsAudioGrid_SelectionChanged(object sender, EventArgs e)
        {
            wordsAudioGrid.ClearSelection();
        }

        private void sourceLangBox_SelectedValueChanged(object sender, EventArgs e)
        {
            lex4all.EngineControl.setLanguage(sourceLangBox.SelectedItem.ToString());
            Debug.WriteLine(lex4all.EngineControl.getLanguage());
        }

        
        
    }
}
