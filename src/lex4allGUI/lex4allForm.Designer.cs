namespace lex4allGUI
{
    partial class lex4allForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.audioOK = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "WAV files|*.wav";
            this.openFileDialog1.Multiselect = true;
            // 
            // chooseWav
            // 
            this.chooseWav.Location = new System.Drawing.Point(363, 58);
            this.chooseWav.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chooseWav.Name = "chooseWav";
            this.chooseWav.Size = new System.Drawing.Size(195, 28);
            this.chooseWav.TabIndex = 0;
            this.chooseWav.Text = "Choose .wav file(s)";
            this.chooseWav.UseVisualStyleBackColor = true;
            this.chooseWav.Click += new System.EventHandler(this.chooseWav_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(57, 111);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(499, 93);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter a word and chose .wav file(s)";
            // 
            // word1
            // 
            this.word1.Location = new System.Drawing.Point(57, 60);
            this.word1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.word1.Name = "word1";
            this.word1.Size = new System.Drawing.Size(132, 22);
            this.word1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "1.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Audio files:";
            // 
            // audioOK
            // 
            this.audioOK.Location = new System.Drawing.Point(363, 213);
            this.audioOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.audioOK.Name = "audioOK";
            this.audioOK.Size = new System.Drawing.Size(193, 28);
            this.audioOK.TabIndex = 9;
            this.audioOK.Text = "Use these audio files";
            this.audioOK.UseVisualStyleBackColor = true;
            this.audioOK.Click += new System.EventHandler(this.audioOK_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(464, 351);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(213, 28);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "BUILD LEXICON";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // lex4allForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 394);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.audioOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.word1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.chooseWav);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "lex4allForm";
            this.Text = "lex4all Lexicon Builder";
            this.Load += new System.EventHandler(this.lex4allForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button chooseWav;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox word1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button audioOK;
        private System.Windows.Forms.Button startButton;


    }
}

