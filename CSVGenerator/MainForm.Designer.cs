namespace CSVGenerator
{
    partial class FormMain
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
            this.m_textBoxDirectory = new System.Windows.Forms.TextBox();
            this.m_buttonSelectDirectory = new System.Windows.Forms.Button();
            this.m_buttonGenerateCSV = new System.Windows.Forms.Button();
            this.m_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // m_textBoxDirectory
            // 
            this.m_textBoxDirectory.Enabled = false;
            this.m_textBoxDirectory.Location = new System.Drawing.Point(12, 12);
            this.m_textBoxDirectory.Name = "m_textBoxDirectory";
            this.m_textBoxDirectory.Size = new System.Drawing.Size(270, 20);
            this.m_textBoxDirectory.TabIndex = 0;
            this.m_textBoxDirectory.Text = "Select the destionation directory";
            // 
            // m_buttonSelectDirectory
            // 
            this.m_buttonSelectDirectory.Location = new System.Drawing.Point(288, 10);
            this.m_buttonSelectDirectory.Name = "m_buttonSelectDirectory";
            this.m_buttonSelectDirectory.Size = new System.Drawing.Size(40, 24);
            this.m_buttonSelectDirectory.TabIndex = 1;
            this.m_buttonSelectDirectory.Text = "...";
            this.m_buttonSelectDirectory.UseVisualStyleBackColor = true;
            this.m_buttonSelectDirectory.Click += new System.EventHandler(this.m_buttonSelectDirectory_Click);
            // 
            // m_buttonGenerateCSV
            // 
            this.m_buttonGenerateCSV.Enabled = false;
            this.m_buttonGenerateCSV.Location = new System.Drawing.Point(108, 41);
            this.m_buttonGenerateCSV.Name = "m_buttonGenerateCSV";
            this.m_buttonGenerateCSV.Size = new System.Drawing.Size(138, 23);
            this.m_buttonGenerateCSV.TabIndex = 2;
            this.m_buttonGenerateCSV.Text = "Generate CSV";
            this.m_buttonGenerateCSV.UseVisualStyleBackColor = true;
            this.m_buttonGenerateCSV.Click += new System.EventHandler(this.m_buttonGenerateCSV_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 76);
            this.Controls.Add(this.m_buttonGenerateCSV);
            this.Controls.Add(this.m_buttonSelectDirectory);
            this.Controls.Add(this.m_textBoxDirectory);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_textBoxDirectory;
        private System.Windows.Forms.Button m_buttonSelectDirectory;
        private System.Windows.Forms.Button m_buttonGenerateCSV;
        private System.Windows.Forms.FolderBrowserDialog m_folderBrowserDialog;
    }
}

