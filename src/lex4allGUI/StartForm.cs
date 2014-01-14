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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void buildLexBtn_Click(object sender, EventArgs e)
        {
            lex4allGUI.Program.main = new MainForm();
            this.Hide();
            lex4allGUI.Program.main.Show();
        }

        private void evalBtn_Click(object sender, EventArgs e)
        {
            lex4allGUI.Program.eval = new EvalForm();
            this.Hide();
            lex4allGUI.Program.eval.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://lex4all.github.io/lex4all");
            }
            catch
            {
                MessageBox.Show("Couldn't open the link. Try copying and pasting it into your web browser.", "Sorry!");
            }
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Quit lex4all?", "Quit", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }


    }
}
