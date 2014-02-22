namespace lex4allGUI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.startButton = new System.Windows.Forms.Button();
            this.addWordButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Audio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.discrimPassesUpDn = new System.Windows.Forms.NumericUpDown();
            this.numPronsUpDn = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.discrimTrainChkBx = new System.Windows.Forms.CheckBox();
            this.discrimPassesLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.shortWildcardChkBx = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrimPassesUpDn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPronsUpDn)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(377, 483);
            this.startButton.Margin = new System.Windows.Forms.Padding(5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(152, 23);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "BUILD LEXICON";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // addWordButton
            // 
            this.addWordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addWordButton.Location = new System.Drawing.Point(454, 5);
            this.addWordButton.Margin = new System.Windows.Forms.Padding(5);
            this.addWordButton.Name = "addWordButton";
            this.addWordButton.Size = new System.Drawing.Size(75, 23);
            this.addWordButton.TabIndex = 12;
            this.addWordButton.Text = "Add word";
            this.addWordButton.UseVisualStyleBackColor = true;
            this.addWordButton.Click += new System.EventHandler(this.addWordButton_Click);
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
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 3);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 36);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(0, 10);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.Size = new System.Drawing.Size(528, 378);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 13;
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
            this.buttonColumn.Text = "Edit";
            this.buttonColumn.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.44195F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.685393F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.87266F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.startButton, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.addWordButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.3096F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.180739F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.509664F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 511);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Your lexicon is being built. This may take a few minutes.";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Words and audio for lexicon training:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shortWildcardChkBx);
            this.groupBox1.Controls.Add(this.discrimPassesUpDn);
            this.groupBox1.Controls.Add(this.numPronsUpDn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.discrimTrainChkBx);
            this.groupBox1.Controls.Add(this.discrimPassesLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 420);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 3);
            this.groupBox1.Size = new System.Drawing.Size(242, 88);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            this.toolTip1.SetToolTip(this.groupBox1, "These options give you greater control over the lexicon-building process. If you\'" +
        "re not sure what settings to use, just leave them at the default values.");
            // 
            // discrimPassesUpDn
            // 
            this.discrimPassesUpDn.Location = new System.Drawing.Point(185, 66);
            this.discrimPassesUpDn.Name = "discrimPassesUpDn";
            this.discrimPassesUpDn.Size = new System.Drawing.Size(47, 20);
            this.discrimPassesUpDn.TabIndex = 16;
            this.discrimPassesUpDn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.discrimPassesUpDn.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numPronsUpDn
            // 
            this.numPronsUpDn.Location = new System.Drawing.Point(185, 18);
            this.numPronsUpDn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPronsUpDn.Name = "numPronsUpDn";
            this.numPronsUpDn.Size = new System.Drawing.Size(47, 20);
            this.numPronsUpDn.TabIndex = 1;
            this.numPronsUpDn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.numPronsUpDn, "The maximum number of alternative pronunciations that will be included in the lex" +
        "icon. Generally (but not always), more pronunciations enable higher recognition " +
        "accuracy.");
            this.numPronsUpDn.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPronsUpDn.ValueChanged += new System.EventHandler(this.numPronsUpDn_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(9, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Maximum pronunciations per word:";
            this.toolTip1.SetToolTip(this.label2, "The maximum number of alternative pronunciations that will be included in the lex" +
        "icon. Generally (but not always), more pronunciations enable higher recognition " +
        "accuracy.");
            // 
            // discrimTrainChkBx
            // 
            this.discrimTrainChkBx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.discrimTrainChkBx.AutoSize = true;
            this.discrimTrainChkBx.Checked = true;
            this.discrimTrainChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.discrimTrainChkBx.Location = new System.Drawing.Point(12, 67);
            this.discrimTrainChkBx.Name = "discrimTrainChkBx";
            this.discrimTrainChkBx.Size = new System.Drawing.Size(128, 17);
            this.discrimTrainChkBx.TabIndex = 15;
            this.discrimTrainChkBx.Text = "Discriminative training";
            this.toolTip1.SetToolTip(this.discrimTrainChkBx, "If checked, any pronunciations that might cause confusion between words in the le" +
        "xicon will be removed. Improves accuracy, but slightly increases training time.");
            this.discrimTrainChkBx.UseVisualStyleBackColor = true;
            this.discrimTrainChkBx.CheckedChanged += new System.EventHandler(this.discrimTrainChkBx_CheckedChanged);
            // 
            // discrimPassesLabel
            // 
            this.discrimPassesLabel.AutoSize = true;
            this.discrimPassesLabel.Location = new System.Drawing.Point(145, 68);
            this.discrimPassesLabel.Name = "discrimPassesLabel";
            this.discrimPassesLabel.Size = new System.Drawing.Size(44, 13);
            this.discrimPassesLabel.TabIndex = 17;
            this.discrimPassesLabel.Text = "Passes:";
            this.toolTip1.SetToolTip(this.discrimPassesLabel, "Number of times the Discriminative Training process will be run (i.e. the lexicon" +
        " will be evaluated and \"confusing\" pronunciations will be removed).");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.progressBar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(259, 447);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(272, 27);
            this.flowLayoutPanel1.TabIndex = 16;
            this.toolTip1.SetToolTip(this.flowLayoutPanel1, "The maximum number of alternative pronunciations that will be included in the lex" +
        "icon. Generally (but not always), more pronunciations enable higher recognition " +
        "accuracy.");
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Progress:";
            this.label4.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.progressBar.Location = new System.Drawing.Point(59, 2);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(207, 18);
            this.progressBar.TabIndex = 14;
            this.progressBar.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pls";
            this.saveFileDialog1.FileName = "lexicon";
            this.saveFileDialog1.Filter = "Pronunciation Lexicon (*.pls) | *.pls|XML file (*.xml)|*.xml";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // shortWildcardChkBx
            // 
            this.shortWildcardChkBx.AutoSize = true;
            this.shortWildcardChkBx.Checked = true;
            this.shortWildcardChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shortWildcardChkBx.Location = new System.Drawing.Point(12, 42);
            this.shortWildcardChkBx.Name = "shortWildcardChkBx";
            this.shortWildcardChkBx.Size = new System.Drawing.Size(92, 17);
            this.shortWildcardChkBx.TabIndex = 18;
            this.shortWildcardChkBx.Text = "Faster training";
            this.toolTip1.SetToolTip(this.shortWildcardChkBx, resources.GetString("shortWildcardChkBx.ToolTip"));
            this.shortWildcardChkBx.UseVisualStyleBackColor = true;
            this.shortWildcardChkBx.CheckedChanged += new System.EventHandler(this.shortWildcardChkBx_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "lex4all Lexicon Builder";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discrimPassesUpDn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPronsUpDn)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button addWordButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Audio;
        private System.Windows.Forms.DataGridViewButtonColumn buttonColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox discrimTrainChkBx;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numPronsUpDn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label discrimPassesLabel;
        private System.Windows.Forms.NumericUpDown discrimPassesUpDn;
        private System.Windows.Forms.CheckBox shortWildcardChkBx;



    }
}