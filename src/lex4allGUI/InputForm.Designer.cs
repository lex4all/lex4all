﻿namespace lex4allGUI
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chooseWav = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.word1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.audioOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rmCheckedBtn = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "wav";
            this.openFileDialog1.Filter = "WAV files (*.wav)|*.wav";
            this.openFileDialog1.Multiselect = true;
            // 
            // chooseWav
            // 
            this.chooseWav.Dock = System.Windows.Forms.DockStyle.Top;
            this.chooseWav.Location = new System.Drawing.Point(68, 426);
            this.chooseWav.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.chooseWav.Name = "chooseWav";
            this.chooseWav.Size = new System.Drawing.Size(114, 23);
            this.chooseWav.TabIndex = 3;
            this.chooseWav.Text = "Add .wav file(s)";
            this.chooseWav.UseVisualStyleBackColor = true;
            this.chooseWav.Click += new System.EventHandler(this.chooseWav_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.tableLayoutPanel1.SetColumnSpan(this.listView1, 2);
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(68, 91);
            this.listView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(461, 325);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter a word and chose .wav file(s)";
            // 
            // word1
            // 
            this.word1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.word1, 2);
            this.word1.Location = new System.Drawing.Point(67, 48);
            this.word1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.word1.Name = "word1";
            this.word1.Size = new System.Drawing.Size(256, 20);
            this.word1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Audio files:";
            // 
            // audioOK
            // 
            this.audioOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.audioOK.Location = new System.Drawing.Point(387, 482);
            this.audioOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.audioOK.Name = "audioOK";
            this.audioOK.Size = new System.Drawing.Size(143, 23);
            this.audioOK.TabIndex = 6;
            this.audioOK.Text = "Save and go back";
            this.audioOK.UseVisualStyleBackColor = true;
            this.audioOK.Click += new System.EventHandler(this.audioOK_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Word:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.36364F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.63636F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.word1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rmCheckedBtn, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.backButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.chooseWav, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.audioOK, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.recordButton, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 511);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // rmCheckedBtn
            // 
            this.rmCheckedBtn.Enabled = false;
            this.rmCheckedBtn.Location = new System.Drawing.Point(192, 426);
            this.rmCheckedBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rmCheckedBtn.Name = "rmCheckedBtn";
            this.rmCheckedBtn.Size = new System.Drawing.Size(132, 23);
            this.rmCheckedBtn.TabIndex = 4;
            this.rmCheckedBtn.Text = "Remove checked files";
            this.rmCheckedBtn.UseVisualStyleBackColor = true;
            this.rmCheckedBtn.Click += new System.EventHandler(this.rmCheckedBtn_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.backButton.Location = new System.Drawing.Point(455, 4);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.recordButton.Location = new System.Drawing.Point(68, 481);
            this.recordButton.Margin = new System.Windows.Forms.Padding(5);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(114, 23);
            this.recordButton.TabIndex = 5;
            this.recordButton.Text = "Record audio";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "lex4all Lexicon Builder";
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button chooseWav;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox word1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button audioOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button rmCheckedBtn;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;


    }
}

