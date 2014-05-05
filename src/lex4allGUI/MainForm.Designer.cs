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
            this.wordsAudioGrid = new System.Windows.Forms.DataGridView();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Audio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.beingBuiltLabel = new System.Windows.Forms.Label();
            this.wordsLabel = new System.Windows.Forms.Label();
            this.optionsBox = new System.Windows.Forms.GroupBox();
            this.optionsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.discrimTrainChkBx = new System.Windows.Forms.CheckBox();
            this.numPronsUpDn = new System.Windows.Forms.NumericUpDown();
            this.shortWildcardChkBx = new System.Windows.Forms.CheckBox();
            this.maxPronsLabel = new System.Windows.Forms.Label();
            this.discrimPassesUpDn = new System.Windows.Forms.NumericUpDown();
            this.discrimPassesLabel = new System.Windows.Forms.Label();
            this.sourceLangBox = new System.Windows.Forms.ComboBox();
            this.sourceLangLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.saveLexDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wordsAudioGrid)).BeginInit();
            this.mainLayoutPanel.SuspendLayout();
            this.optionsBox.SuspendLayout();
            this.optionsLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPronsUpDn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discrimPassesUpDn)).BeginInit();
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
            this.startButton.TabIndex = 4;
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
            this.addWordButton.TabIndex = 1;
            this.addWordButton.Text = "Add word";
            this.addWordButton.UseVisualStyleBackColor = true;
            this.addWordButton.Click += new System.EventHandler(this.addWordButton_Click);
            // 
            // wordsAudioGrid
            // 
            this.wordsAudioGrid.AllowUserToAddRows = false;
            this.wordsAudioGrid.AllowUserToDeleteRows = false;
            this.wordsAudioGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.wordsAudioGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.wordsAudioGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wordsAudioGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.wordsAudioGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordsAudioGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Word,
            this.Audio,
            this.buttonColumn,
            this.Delete});
            this.mainLayoutPanel.SetColumnSpan(this.wordsAudioGrid, 3);
            this.wordsAudioGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wordsAudioGrid.Location = new System.Drawing.Point(3, 36);
            this.wordsAudioGrid.MinimumSize = new System.Drawing.Size(0, 10);
            this.wordsAudioGrid.MultiSelect = false;
            this.wordsAudioGrid.Name = "wordsAudioGrid";
            this.wordsAudioGrid.ReadOnly = true;
            this.wordsAudioGrid.RowHeadersWidth = 50;
            this.wordsAudioGrid.Size = new System.Drawing.Size(528, 347);
            this.wordsAudioGrid.StandardTab = true;
            this.wordsAudioGrid.TabIndex = 2;
            this.wordsAudioGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.wordsAudioGrid_CellClick);
            this.wordsAudioGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.wordsAudioGrid_CellFormatting);
            this.wordsAudioGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.wordsAudioGrid_RowPostPaint);
            this.wordsAudioGrid.SelectionChanged += new System.EventHandler(this.wordsAudioGrid_SelectionChanged);
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
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 3;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.19101F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.498127F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.49813F));
            this.mainLayoutPanel.Controls.Add(this.beingBuiltLabel, 2, 2);
            this.mainLayoutPanel.Controls.Add(this.wordsAudioGrid, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.startButton, 2, 4);
            this.mainLayoutPanel.Controls.Add(this.addWordButton, 2, 0);
            this.mainLayoutPanel.Controls.Add(this.wordsLabel, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.optionsBox, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.flowLayoutPanel1, 2, 3);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 5;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.5045F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.06306F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.509664F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayoutPanel.Size = new System.Drawing.Size(534, 511);
            this.mainLayoutPanel.TabIndex = 14;
            // 
            // beingBuiltLabel
            // 
            this.beingBuiltLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.beingBuiltLabel.AutoSize = true;
            this.beingBuiltLabel.Location = new System.Drawing.Point(262, 408);
            this.beingBuiltLabel.Name = "beingBuiltLabel";
            this.beingBuiltLabel.Size = new System.Drawing.Size(269, 13);
            this.beingBuiltLabel.TabIndex = 18;
            this.beingBuiltLabel.Text = "Your lexicon is being built. This may take a few minutes.";
            this.beingBuiltLabel.Visible = false;
            // 
            // wordsLabel
            // 
            this.wordsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.wordsLabel.AutoSize = true;
            this.wordsLabel.Location = new System.Drawing.Point(3, 10);
            this.wordsLabel.Name = "wordsLabel";
            this.wordsLabel.Size = new System.Drawing.Size(179, 13);
            this.wordsLabel.TabIndex = 0;
            this.wordsLabel.Text = "Words and audio for lexicon training:";
            // 
            // optionsBox
            // 
            this.optionsBox.Controls.Add(this.optionsLayoutPanel);
            this.optionsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsBox.Location = new System.Drawing.Point(3, 389);
            this.optionsBox.Name = "optionsBox";
            this.mainLayoutPanel.SetRowSpan(this.optionsBox, 3);
            this.optionsBox.Size = new System.Drawing.Size(245, 119);
            this.optionsBox.TabIndex = 3;
            this.optionsBox.TabStop = false;
            this.optionsBox.Text = "Options";
            this.mainToolTip.SetToolTip(this.optionsBox, "These options give you greater control over the lexicon-building process. If you\'" +
        "re not sure what settings to use, just leave them at the default values.");
            // 
            // optionsLayoutPanel
            // 
            this.optionsLayoutPanel.ColumnCount = 3;
            this.optionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.32217F));
            this.optionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.08368F));
            this.optionsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.17573F));
            this.optionsLayoutPanel.Controls.Add(this.discrimTrainChkBx, 0, 3);
            this.optionsLayoutPanel.Controls.Add(this.numPronsUpDn, 2, 1);
            this.optionsLayoutPanel.Controls.Add(this.shortWildcardChkBx, 0, 2);
            this.optionsLayoutPanel.Controls.Add(this.maxPronsLabel, 0, 1);
            this.optionsLayoutPanel.Controls.Add(this.discrimPassesUpDn, 2, 3);
            this.optionsLayoutPanel.Controls.Add(this.discrimPassesLabel, 1, 3);
            this.optionsLayoutPanel.Controls.Add(this.sourceLangBox, 1, 0);
            this.optionsLayoutPanel.Controls.Add(this.sourceLangLabel, 0, 0);
            this.optionsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.optionsLayoutPanel.Name = "optionsLayoutPanel";
            this.optionsLayoutPanel.RowCount = 4;
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.optionsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.optionsLayoutPanel.Size = new System.Drawing.Size(239, 100);
            this.optionsLayoutPanel.TabIndex = 6;
            // 
            // discrimTrainChkBx
            // 
            this.discrimTrainChkBx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.discrimTrainChkBx.AutoSize = true;
            this.discrimTrainChkBx.Checked = true;
            this.discrimTrainChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.discrimTrainChkBx.Location = new System.Drawing.Point(3, 79);
            this.discrimTrainChkBx.Name = "discrimTrainChkBx";
            this.discrimTrainChkBx.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.discrimTrainChkBx.Size = new System.Drawing.Size(131, 17);
            this.discrimTrainChkBx.TabIndex = 3;
            this.discrimTrainChkBx.Text = "Discriminative training";
            this.mainToolTip.SetToolTip(this.discrimTrainChkBx, "If checked, any pronunciations that might cause confusion between words in the le" +
        "xicon will be removed. Improves accuracy, but slightly increases training time.");
            this.discrimTrainChkBx.UseVisualStyleBackColor = true;
            this.discrimTrainChkBx.CheckedChanged += new System.EventHandler(this.discrimTrainChkBx_CheckedChanged);
            // 
            // numPronsUpDn
            // 
            this.numPronsUpDn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numPronsUpDn.Location = new System.Drawing.Point(189, 28);
            this.numPronsUpDn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPronsUpDn.Name = "numPronsUpDn";
            this.numPronsUpDn.Size = new System.Drawing.Size(47, 20);
            this.numPronsUpDn.TabIndex = 1;
            this.numPronsUpDn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mainToolTip.SetToolTip(this.numPronsUpDn, "The maximum number of alternative pronunciations that will be included in the lex" +
        "icon. Generally (but not always), more pronunciations enable higher recognition " +
        "accuracy.");
            this.numPronsUpDn.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPronsUpDn.ValueChanged += new System.EventHandler(this.numPronsUpDn_ValueChanged);
            // 
            // shortWildcardChkBx
            // 
            this.shortWildcardChkBx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.shortWildcardChkBx.AutoSize = true;
            this.shortWildcardChkBx.Checked = true;
            this.shortWildcardChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optionsLayoutPanel.SetColumnSpan(this.shortWildcardChkBx, 3);
            this.shortWildcardChkBx.Location = new System.Drawing.Point(3, 54);
            this.shortWildcardChkBx.Name = "shortWildcardChkBx";
            this.shortWildcardChkBx.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.shortWildcardChkBx.Size = new System.Drawing.Size(95, 17);
            this.shortWildcardChkBx.TabIndex = 2;
            this.shortWildcardChkBx.Text = "Faster training";
            this.mainToolTip.SetToolTip(this.shortWildcardChkBx, resources.GetString("shortWildcardChkBx.ToolTip"));
            this.shortWildcardChkBx.UseVisualStyleBackColor = true;
            this.shortWildcardChkBx.CheckedChanged += new System.EventHandler(this.shortWildcardChkBx_CheckedChanged);
            // 
            // maxPronsLabel
            // 
            this.maxPronsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maxPronsLabel.AutoSize = true;
            this.optionsLayoutPanel.SetColumnSpan(this.maxPronsLabel, 2);
            this.maxPronsLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxPronsLabel.Location = new System.Drawing.Point(3, 31);
            this.maxPronsLabel.Name = "maxPronsLabel";
            this.maxPronsLabel.Size = new System.Drawing.Size(170, 13);
            this.maxPronsLabel.TabIndex = 0;
            this.maxPronsLabel.Text = "Maximum pronunciations per word:";
            this.mainToolTip.SetToolTip(this.maxPronsLabel, "The maximum number of alternative pronunciations that will be included in the lex" +
        "icon. Generally (but not always), more pronunciations enable higher recognition " +
        "accuracy.");
            // 
            // discrimPassesUpDn
            // 
            this.discrimPassesUpDn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.discrimPassesUpDn.Location = new System.Drawing.Point(189, 78);
            this.discrimPassesUpDn.Name = "discrimPassesUpDn";
            this.discrimPassesUpDn.Size = new System.Drawing.Size(47, 20);
            this.discrimPassesUpDn.TabIndex = 5;
            this.discrimPassesUpDn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.discrimPassesUpDn.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // discrimPassesLabel
            // 
            this.discrimPassesLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.discrimPassesLabel.AutoSize = true;
            this.discrimPassesLabel.Location = new System.Drawing.Point(141, 81);
            this.discrimPassesLabel.Margin = new System.Windows.Forms.Padding(0);
            this.discrimPassesLabel.Name = "discrimPassesLabel";
            this.discrimPassesLabel.Size = new System.Drawing.Size(44, 13);
            this.discrimPassesLabel.TabIndex = 4;
            this.discrimPassesLabel.Text = "Passes:";
            this.discrimPassesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mainToolTip.SetToolTip(this.discrimPassesLabel, "Number of times the Discriminative Training process will be run (i.e. the lexicon" +
        " will be evaluated and \"confusing\" pronunciations will be removed).");
            // 
            // sourceLangBox
            // 
            this.sourceLangBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.optionsLayoutPanel.SetColumnSpan(this.sourceLangBox, 2);
            this.sourceLangBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceLangBox.FormattingEnabled = true;
            this.sourceLangBox.Items.AddRange(new object[] {
            "en-US"});
            this.sourceLangBox.Location = new System.Drawing.Point(140, 3);
            this.sourceLangBox.Name = "sourceLangBox";
            this.sourceLangBox.Size = new System.Drawing.Size(96, 21);
            this.sourceLangBox.TabIndex = 6;
            this.mainToolTip.SetToolTip(this.sourceLangBox, "The language of the recognition engine that will be used, and the language of the" +
        " created lexicon.");
            // 
            // sourceLangLabel
            // 
            this.sourceLangLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sourceLangLabel.AutoSize = true;
            this.sourceLangLabel.Location = new System.Drawing.Point(3, 6);
            this.sourceLangLabel.Name = "sourceLangLabel";
            this.sourceLangLabel.Size = new System.Drawing.Size(91, 13);
            this.sourceLangLabel.TabIndex = 7;
            this.sourceLangLabel.Text = "Source language:";
            this.mainToolTip.SetToolTip(this.sourceLangLabel, "The language of the recognition engine that will be used, and the language of the" +
        " created lexicon.");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.progressLabel);
            this.flowLayoutPanel1.Controls.Add(this.progressBar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(261, 447);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(270, 27);
            this.flowLayoutPanel1.TabIndex = 16;
            this.mainToolTip.SetToolTip(this.flowLayoutPanel1, "The maximum number of alternative pronunciations that will be included in the lex" +
        "icon. Generally (but not always), more pronunciations enable higher recognition " +
        "accuracy.");
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(3, 4);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(51, 13);
            this.progressLabel.TabIndex = 19;
            this.progressLabel.Text = "Progress:";
            this.progressLabel.Visible = false;
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
            // saveLexDialog
            // 
            this.saveLexDialog.DefaultExt = "pls";
            this.saveLexDialog.FileName = "lexicon";
            this.saveLexDialog.Filter = "Pronunciation Lexicon (*.pls) | *.pls|XML file (*.xml)|*.xml";
            // 
            // mainToolTip
            // 
            this.mainToolTip.AutoPopDelay = 20000;
            this.mainToolTip.InitialDelay = 500;
            this.mainToolTip.ReshowDelay = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.mainLayoutPanel);
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
            ((System.ComponentModel.ISupportInitialize)(this.wordsAudioGrid)).EndInit();
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.optionsBox.ResumeLayout(false);
            this.optionsLayoutPanel.ResumeLayout(false);
            this.optionsLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPronsUpDn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discrimPassesUpDn)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button addWordButton;
        private System.Windows.Forms.DataGridView wordsAudioGrid;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.SaveFileDialog saveLexDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.DataGridViewTextBoxColumn Audio;
        private System.Windows.Forms.DataGridViewButtonColumn buttonColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label wordsLabel;
        private System.Windows.Forms.CheckBox discrimTrainChkBx;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label maxPronsLabel;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.NumericUpDown numPronsUpDn;
        private System.Windows.Forms.GroupBox optionsBox;
        private System.Windows.Forms.Label beingBuiltLabel;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label discrimPassesLabel;
        private System.Windows.Forms.NumericUpDown discrimPassesUpDn;
        private System.Windows.Forms.CheckBox shortWildcardChkBx;
        private System.Windows.Forms.TableLayoutPanel optionsLayoutPanel;
        private System.Windows.Forms.ComboBox sourceLangBox;
        private System.Windows.Forms.Label sourceLangLabel;



    }
}