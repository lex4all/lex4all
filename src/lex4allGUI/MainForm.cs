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
    public partial class MainForm : Form
    {
        public static Dictionary<String, String[]> wavDict = new Dictionary<string, string[]>();

        public MainForm()
        {
            InitializeComponent();
            
        }

        public void updateListView()
        {
            listView1.Clear();
            dataGridView1.Rows.Clear();
            foreach (string word in wavDict.Keys)
            {
                this.listView1.Items.Add(word);
                dataGridView1.Rows.Add(new string[] { word, wavDict[word].Length.ToString() });
            }

            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            startButton.Text = "Working...";
            lex4all.Program.BuildLexicon(wavDict, "testGUIoutput.pls");
            startButton.Text = "Done!";
        }

        private void addWordButton_Click(object sender, EventArgs e)
        {
            InputForm wordInput = new InputForm();
            this.Hide();
            wordInput.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

        
    }
}
