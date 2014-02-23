namespace lex4allGUI
{
    partial class EvalForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectLexBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Audio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.startButton = new System.Windows.Forms.Button();
            this.addWordButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addwordComboBox = new System.Windows.Forms.ComboBox();
            this.lexFileLabel = new System.Windows.Forms.Label();
            this.openLexDialog = new System.Windows.Forms.OpenFileDialog();
            this.addAudioDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveLogDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.71717F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.59446F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.74307F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.selectLexBtn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.startButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.addWordButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addwordComboBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lexFileLabel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 511);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // selectLexBtn
            // 
            this.selectLexBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.selectLexBtn.Location = new System.Drawing.Point(440, 5);
            this.selectLexBtn.Margin = new System.Windows.Forms.Padding(5);
            this.selectLexBtn.Name = "selectLexBtn";
            this.selectLexBtn.Size = new System.Drawing.Size(89, 23);
            this.selectLexBtn.TabIndex = 2;
            this.selectLexBtn.Text = "Select lexicon";
            this.selectLexBtn.UseVisualStyleBackColor = true;
            this.selectLexBtn.Click += new System.EventHandler(this.selectLexBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Word,
            this.Audio,
            this.buttonColumn,
            this.Delete});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 4);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 36);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(0, 10);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(528, 439);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Word
            // 
            this.Word.HeaderText = "Word";
            this.Word.Name = "Word";
            this.Word.ReadOnly = true;
            // 
            // Audio
            // 
            this.Audio.HeaderText = "Audio Files";
            this.Audio.Name = "Audio";
            this.Audio.ReadOnly = true;
            // 
            // buttonColumn
            // 
            this.buttonColumn.HeaderText = "";
            this.buttonColumn.Name = "buttonColumn";
            this.buttonColumn.ReadOnly = true;
            this.buttonColumn.Text = "Select audio";
            this.buttonColumn.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Remove word";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(403, 483);
            this.startButton.Margin = new System.Windows.Forms.Padding(5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(126, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "START EVALUATION";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // addWordButton
            // 
            this.addWordButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addWordButton.Enabled = false;
            this.addWordButton.Location = new System.Drawing.Point(141, 483);
            this.addWordButton.Margin = new System.Windows.Forms.Padding(5);
            this.addWordButton.Name = "addWordButton";
            this.addWordButton.Size = new System.Drawing.Size(98, 23);
            this.addWordButton.TabIndex = 5;
            this.addWordButton.Text = "Add word";
            this.addWordButton.UseVisualStyleBackColor = true;
            this.addWordButton.Click += new System.EventHandler(this.addWordButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lexicon file:";
            // 
            // addwordComboBox
            // 
            this.addwordComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.addwordComboBox, 2);
            this.addwordComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addwordComboBox.Enabled = false;
            this.addwordComboBox.FormattingEnabled = true;
            this.addwordComboBox.Location = new System.Drawing.Point(5, 484);
            this.addwordComboBox.Margin = new System.Windows.Forms.Padding(5);
            this.addwordComboBox.MaxDropDownItems = 30;
            this.addwordComboBox.Name = "addwordComboBox";
            this.addwordComboBox.Size = new System.Drawing.Size(125, 21);
            this.addwordComboBox.TabIndex = 4;
            // 
            // lexFileLabel
            // 
            this.lexFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lexFileLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lexFileLabel, 2);
            this.lexFileLabel.Location = new System.Drawing.Point(89, 10);
            this.lexFileLabel.Name = "lexFileLabel";
            this.lexFileLabel.Size = new System.Drawing.Size(80, 13);
            this.lexFileLabel.TabIndex = 1;
            this.lexFileLabel.Text = "(none selected)";
            // 
            // openLexDialog
            // 
            this.openLexDialog.DefaultExt = "pls";
            this.openLexDialog.Filter = "XML lexicon files (*.pls, *.xml)|*.pls;*.xml";
            // 
            // addAudioDialog
            // 
            this.addAudioDialog.DefaultExt = "wav";
            this.addAudioDialog.Filter = "WAV files (*.wav)|*.wav";
            this.addAudioDialog.Multiselect = true;
            // 
            // saveLogDialog
            // 
            this.saveLogDialog.DefaultExt = "csv";
            this.saveLogDialog.Filter = "Comma-Separated Values|*.csv|Text files|*.txt";
            // 
            // EvalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EvalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "lex4all Evaluation Tool";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.EvalForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EvalForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EvalForm_FormClosed);
            this.Load += new System.EventHandler(this.EvalForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lexFileLabel;
        private System.Windows.Forms.Button selectLexBtn;
        private System.Windows.Forms.OpenFileDialog openLexDialog;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addWordButton;
        private System.Windows.Forms.OpenFileDialog addAudioDialog;
        private System.Windows.Forms.ComboBox addwordComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Audio;
        private System.Windows.Forms.DataGridViewButtonColumn buttonColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.SaveFileDialog saveLogDialog;
    }
}