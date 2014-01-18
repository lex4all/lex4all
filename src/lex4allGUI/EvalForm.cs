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
        public static string lexFile;
        public static string[] wordsInLex;
        public static Dictionary<String, String[]> evalDict = new Dictionary<string, string[]>();

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
                lexFileLabel.Text = openLexDialog.SafeFileName;
                updateLexFile();
            }
        }

        /// <summary>
        /// Display the currently selected lexicon file.
        /// </summary>
        private void updateLexFile()
        {
            wordsInLex = lex4all.Evaluation.ReadLexicon(lexFile);
            Debug.WriteLine(String.Format("wordsInLex.Count() = {0}", wordsInLex.Count()));
            foreach (string word in wordsInLex)
                evalDict.Add(word, new string[0]);

            updateGridView();
        }


        /// <summary>
        /// Update dataGridView1 to reflect the current words/files in evalDict.
        /// </summary>
        public void updateGridView()
        {
            dataGridView1.Rows.Clear();
            addwordComboBox.Items.Clear();

            foreach (string word in evalDict.Keys)
            {
                Debug.WriteLine(word + ": " + String.Join(",", evalDict[word]));
                dataGridView1.Rows.Add(new string[] { word, evalDict[word].Length.ToString() });
            }

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

            if (evalDict.Count > 0)
            {
                startButton.Enabled = true;
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
            string statsMsg;
            Dictionary<string, Dictionary<string, int>> confusMatrix = lex4all.Evaluation.Evaluate(evalDict, lexFile, out statsMsg);
            MessageBox.Show(statsMsg);
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



    }
}
