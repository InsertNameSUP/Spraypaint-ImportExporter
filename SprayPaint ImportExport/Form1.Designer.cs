
namespace SprayPaint_ImportExport
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFile = new System.Windows.Forms.Button();
            this.fileImport = new System.Windows.Forms.OpenFileDialog();
            this.previewImage = new System.Windows.Forms.PictureBox();
            this.generateImage = new System.Windows.Forms.Button();
            this.fileExport = new System.Windows.Forms.SaveFileDialog();
            this.size256 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.size512 = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.openFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openFile.Font = new System.Drawing.Font("Unispace", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.openFile.ForeColor = System.Drawing.SystemColors.Control;
            this.openFile.Location = new System.Drawing.Point(562, 12);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(226, 69);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open File";
            this.openFile.UseVisualStyleBackColor = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // fileImport
            // 
            this.fileImport.FileName = "openFileDialog1";
            this.fileImport.Filter = "Graffiti or Image File (*.txt, *.png, *.jpg, *.jpeg)|*.txt; *.png; *.jpg;*.jpeg";
            // 
            // previewImage
            // 
            this.previewImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.previewImage.Location = new System.Drawing.Point(12, 12);
            this.previewImage.Name = "previewImage";
            this.previewImage.Size = new System.Drawing.Size(544, 392);
            this.previewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewImage.TabIndex = 1;
            this.previewImage.TabStop = false;
            this.previewImage.Click += new System.EventHandler(this.previewImage_Click);
            // 
            // generateImage
            // 
            this.generateImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.generateImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generateImage.Font = new System.Drawing.Font("Unispace", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.generateImage.ForeColor = System.Drawing.SystemColors.Control;
            this.generateImage.Location = new System.Drawing.Point(562, 335);
            this.generateImage.Name = "generateImage";
            this.generateImage.Size = new System.Drawing.Size(226, 69);
            this.generateImage.TabIndex = 6;
            this.generateImage.Text = "Generate Image";
            this.generateImage.UseVisualStyleBackColor = false;
            this.generateImage.Click += new System.EventHandler(this.generateImage_Click);
            // 
            // fileExport
            // 
            this.fileExport.Filter = "Text (*.txt)|*.txt";
            // 
            // size256
            // 
            this.size256.AutoSize = true;
            this.size256.Checked = true;
            this.size256.ForeColor = System.Drawing.Color.White;
            this.size256.Location = new System.Drawing.Point(3, 3);
            this.size256.Name = "size256";
            this.size256.Size = new System.Drawing.Size(43, 19);
            this.size256.TabIndex = 0;
            this.size256.TabStop = true;
            this.size256.Text = "256";
            this.size256.UseVisualStyleBackColor = true;
            this.size256.CheckedChanged += new System.EventHandler(this.size256_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.size512);
            this.panel1.Controls.Add(this.size256);
            this.panel1.Location = new System.Drawing.Point(571, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 8;
            // 
            // size512
            // 
            this.size512.AutoSize = true;
            this.size512.ForeColor = System.Drawing.Color.White;
            this.size512.Location = new System.Drawing.Point(3, 28);
            this.size512.Name = "size512";
            this.size512.Size = new System.Drawing.Size(43, 19);
            this.size512.TabIndex = 1;
            this.size512.Text = "512";
            this.size512.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(12, 426);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(188, 15);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "© Insert Name. All rights reserved.";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.generateImage);
            this.Controls.Add(this.previewImage);
            this.Controls.Add(this.openFile);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Spraypaint Import-Exporter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog fileImport;
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.Button generateImage;
        private System.Windows.Forms.SaveFileDialog fileExport;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton size256;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton size512;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

