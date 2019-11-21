namespace Sdl.Sdk.LanguagePlatform.Samples.ListProvider
{
    partial class ListProviderConfDialog
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
            this.txt_ListFile = new System.Windows.Forms.TextBox();
            this.combo_delimiter = new System.Windows.Forms.ComboBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txt_ListFile
            // 
            this.txt_ListFile.Location = new System.Drawing.Point(37, 58);
            this.txt_ListFile.Name = "txt_ListFile";
            this.txt_ListFile.Size = new System.Drawing.Size(424, 21);
            this.txt_ListFile.TabIndex = 0;
            // 
            // combo_delimiter
            // 
            this.combo_delimiter.FormattingEnabled = true;
            this.combo_delimiter.Items.AddRange(new object[] {
            ";",
            ":",
            "=",
            "\\t"});
            this.combo_delimiter.Location = new System.Drawing.Point(160, 147);
            this.combo_delimiter.Name = "combo_delimiter";
            this.combo_delimiter.Size = new System.Drawing.Size(46, 20);
            this.combo_delimiter.TabIndex = 1;
            this.combo_delimiter.Text = ";";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(351, 212);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(62, 23);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(450, 212);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(66, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(481, 58);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(47, 23);
            this.btn_Browse.TabIndex = 4;
            this.btn_Browse.Text = "...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Delimiter character";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Delimited text file";
            // 
            // dlg_OpenFile
            // 
            this.dlg_OpenFile.FileName = "openFileDialog1";
            // 
            // ListProviderConfDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.combo_delimiter);
            this.Controls.Add(this.txt_ListFile);
            this.Name = "ListProviderConfDialog";
            this.Text = "Delimited List Provider options";
            this.Load += new System.EventHandler(this.ListProviderConfDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ListFile;
        private System.Windows.Forms.ComboBox combo_delimiter;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog dlg_OpenFile;
    }
}