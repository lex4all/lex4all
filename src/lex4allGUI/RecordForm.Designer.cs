namespace lex4allGUI
{
    partial class RecordForm
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
            this.recordButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveButton = new System.Windows.Forms.Button();
            this.rmCheckedBtn = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(83, 3);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(75, 28);
            this.recordButton.TabIndex = 0;
            this.recordButton.Text = "Start";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "wav";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.23596F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.33708F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.36457F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.recordButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.saveButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rmCheckedBtn, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.backButton, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.079376F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.0326F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.901489F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.35223F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.05732F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.15287F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(712, 628);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.tableLayoutPanel1.SetColumnSpan(this.listView1, 2);
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(87, 281);
            this.listView1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(618, 225);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.trackBar1, 2);
            this.trackBar1.Location = new System.Drawing.Point(192, 205);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(407, 56);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar1, 2);
            this.progressBar1.Location = new System.Drawing.Point(191, 156);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(410, 16);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(83, 53);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(123, 28);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save record";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // rmCheckedBtn
            // 
            this.rmCheckedBtn.Enabled = false;
            this.rmCheckedBtn.Location = new System.Drawing.Point(83, 515);
            this.rmCheckedBtn.Name = "rmCheckedBtn";
            this.rmCheckedBtn.Size = new System.Drawing.Size(181, 28);
            this.rmCheckedBtn.TabIndex = 7;
            this.rmCheckedBtn.Text = "Remove checked files";
            this.rmCheckedBtn.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(477, 515);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(122, 28);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add to word";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(477, 53);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 28);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 629);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recording";
            this.Load += new System.EventHandler(this.RecordForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button rmCheckedBtn;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button backButton;
    }
}