using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lex4allGUI
{
    public partial class EvalForm : Form
    {
        public string lexFile;
        public string[] wordsInLex;
        public Dictionary<String, String[]> evalDict = new Dictionary<string, string[]>();

        public EvalForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Uses OpenFileDialog to select a lexicon file.
        /// </summary>
        private void selectLexBtn_Click(object sender, EventArgs e)
        {
            if (openLexDialog.ShowDialog() == DialogResult.OK)
            {
                lexFile = openLexDialog.FileName;
                //lexFileLabel.Text = openLexDialog.SafeFileName;
                updateLexFile();
            }
        }

        /// <summary>
        /// Display the currently selected lexicon file.
        /// </summary>
        public void updateLexFile()
        {
            lexFileLabel.Text = System.IO.Path.GetFileName(lexFile);
            wordsInLex = lex4all.Evaluation.ReadLexicon(lexFile);
            Debug.WriteLine(String.Format("wordsInLex.Count() = {0}", wordsInLex.Count()));

            if (evalDict.Keys.Count > 0)
            {
                // Check if new lexicon has same words as old one; if so, give user option to keep selected audio
                List<string> notInNewLex = new List<string>();
                foreach (string word in evalDict.Keys)
                {
                    if (wordsInLex.Contains(word) == false)
                    {
                        notInNewLex.Add(word);
                    }
                }
                if (notInNewLex.Count < evalDict.Keys.Count)
                {
                    DialogResult keepData = MessageBox.Show(@"The lexicon you selected has some of the same words as the last lexicon you used. Would you like to keep the currently selected audio files?", "Keep current files?", MessageBoxButtons.YesNo);
                    if (keepData == DialogResult.Yes)
                    {
                        foreach (string word in notInNewLex)
                        {
                            evalDict.Remove(word); //Only keep the words in evalDict that are also in the new lexicon
                        }
                    }
                    else
                    {
                        evalDict.Clear();
                    }
                }
                else
                {
                    evalDict.Clear();
                }
            }
            
            foreach (string word in wordsInLex)
            {
                if (evalDict.ContainsKey(word) == false)
                    evalDict.Add(word, new string[0]);
            }

            updateGridView();
        }


        /// <summary>
        /// Update dataGridView1 to reflect the current words/files in evalDict.
        /// </summary>
        public void updateGridView()
        {
            // clear data
            dataGridView1.Rows.Clear();
            addwordComboBox.Items.Clear();

            // read in data from evalDict
            foreach (string word in evalDict.Keys)
            {
                Debug.WriteLine(word + ": " + String.Join(",", evalDict[word]));
                dataGridView1.Rows.Add(new string[] { word, evalDict[word].Length.ToString() });
            }

            // if there are words left out, add them to the ComboBox
            if (wordsInLex.Count() > evalDict.Keys.Count)
            {
                string[] leftOut = (from w in wordsInLex
                                    where evalDict.ContainsKey(w) == false
                                    select w).ToArray();
                Debug.WriteLine("leftOut: " + String.Join(",", leftOut));
                addwordComboBox.Items.AddRange(leftOut);
                addwordComboBox.Enabled = true;
                addWordButton.Enabled = true;
            }
            else
            {
                addwordComboBox.Enabled = false;
                addWordButton.Enabled = false;
            }

            // enable startButton if evalDict isn't empty
            if (evalDict.Count > 0)
            {
                startButton.Enabled = true;
            }

            // update row headers with row numbers
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index > -1)
                    row.HeaderCell.Value = String.Format("{0}", row.Index + 1);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;

            if (row > -1)
            {
                string word = dataGridView1.Rows[row].Cells[0].Value.ToString();
                switch (column)
                {
                    case 1:
                        //diplay audio files
                        string files = String.Join("\n", evalDict[word]);
                        MessageBox.Show("Selected audio files:\n" + files);
                        break;

                    case 2:
                        //add or edit audio
                        if (addAudioDialog.ShowDialog() == DialogResult.OK)
                        {
                            evalDict[word] = addAudioDialog.FileNames;
                            updateGridView();
                        }
                        break;

                    case 3:
                        //remove word
                        if (MessageBox.Show("Delete this word from evaluation set?", "Confirm", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            evalDict.Remove(word);
                            updateGridView();
                        }
                        break;

                }
            }

        }

        private void addWordButton_Click(object sender, EventArgs e)
        {
            var selectedWord = addwordComboBox.SelectedItem;
            if (selectedWord == null)
            {
                MessageBox.Show("Please select a word to add from the drop-down box.");
            }
            else
            {
                evalDict[selectedWord.ToString()] = new string[0];
                updateGridView();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string[]> kvp in evalDict)
            {
                if (kvp.Value.Count() == 0)
                {
                    MessageBox.Show("Please select at least one audio file for each word.", "Audio file(s) missing");
                    return;
                }
            }

            startButton.Enabled = false;
            startButton.Text = "Working...";
            selectLexBtn.Enabled = false;
            addwordComboBox.Enabled = false;
            addWordButton.Enabled = false;
            dataGridView1.Enabled = false;


            string statsMsg;
            Dictionary<string, Dictionary<string, int>> confusMatrix = lex4all.Evaluation.Evaluate(evalDict, lexFile, out statsMsg);

            string header = String.Format("EVALUATION RESULTS\n\nLexicon file: {0}", lexFile);
            string saveOrNot = "\n\nSave the evaluation results and confusion matrix to file?";

            DialogResult writeEvalLog = MessageBox.Show(header + statsMsg + saveOrNot, "Evaluation complete", MessageBoxButtons.YesNo);
            if (writeEvalLog == DialogResult.Yes)
            {
                if (saveLogDialog.ShowDialog() == DialogResult.OK)
                {
                    List<string> evalLogLines = new List<string>();
                    evalLogLines.Add("EVALUATION RESULTS");
                    evalLogLines.Add(String.Format("Lexicon file: {0}", lexFile));
                    evalLogLines.Add("");
                    evalLogLines.Add(statsMsg.Replace(':',','));
                    evalLogLines.Add("");
                    evalLogLines.Add("actual//recognized," + String.Join(",", confusMatrix.Keys.ToArray()) + ",UNRECOGNIZED");

                    foreach (string actual in confusMatrix.Keys)
                    {
                        string line = actual;
                        foreach (string recognizedAs in confusMatrix[actual].Keys)
                        {
                            line += String.Format(",{0}", confusMatrix[actual][recognizedAs]);
                        }
                        evalLogLines.Add(line);
                    }
                    
                    System.IO.File.WriteAllLines(saveLogDialog.FileName, evalLogLines);
                }
            }

            startButton.Text = "START EVALUATION";
            startButton.Enabled = true;
            selectLexBtn.Enabled = true;
            dataGridView1.Enabled = true;
            updateGridView();
        }



        // Form event handlers

        private void EvalForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void EvalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Quit the evaluation tool?", "Confirm", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void EvalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lex4allGUI.Program.start.Show();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[1];
                string word = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string ttText;
                if (evalDict[word].Count() > 0)
                {
                    string files = String.Join("\n", evalDict[word]);
                    ttText = "Selected audio files:\n" + files;
                }
                else ttText = "No audio files selected.";
                
                cell.ToolTipText = ttText;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.PaintHeader(DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentBackground);
        }

        private void EvalForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            string helpMsg = @"
This tool enables you to evaluate the word recognition accuracy of an existing lexicon. To use the tool:
- Click ""Select lexicon"" and choose the lexicon file you want to evaluate.
- The words (graphemes) in the lexicon will be automatically added. 
- Remove or add words using the ""Remove word"" and ""Add word"" buttons (only words in the lexicon may be included).
- For each word, click ""Select audio"" and choose at least one audio file to be evaluated.
- Click ""Start Evaluation"".
- The program will attempt to recognize each audio file against the provided lexicon. After a few seconds, the accuracy results will be displayed.";
            MessageBox.Show(helpMsg, "lex4all Evaluation Tool");
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }



    }
}
