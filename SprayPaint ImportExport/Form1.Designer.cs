
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
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.generateImage);
            this.Controls.Add(this.previewImage);
            this.Controls.Add(this.openFile);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Spraypaint Import-Exporter";
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog fileImport;
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.Button generateImage;
        private System.Windows.Forms.SaveFileDialog fileExport;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

