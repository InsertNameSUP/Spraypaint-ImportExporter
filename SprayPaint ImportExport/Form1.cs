using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SprayPaint_ImportExport
{
    public partial class Form1 : Form
    {
        static readonly string[] exportFilters = new string[]
        {
            "Graffitti File (*.txt)|*.txt",
            "PNG (*.png)|*.png",
        };
        static SprayPaint.ExportSetting exportSetting = SprayPaint.ExportSetting.ImageToGraffitti;
        public Form1()
        {
            InitializeComponent();
        }
        void CreatePreview()
        {
            previewImage.Image = SprayPaint.CreatePreview(exportSetting, fileImport.FileName);
        }
        private void openFile_Click(object sender, EventArgs e)
        {
            if(fileImport.ShowDialog() == DialogResult.OK)
            {
                string? fileType = Path.GetExtension(fileImport.FileName);
                exportSetting = fileType == ".txt" ? SprayPaint.ExportSetting.GraffittiToImage : SprayPaint.ExportSetting.ImageToGraffitti;


                if(exportSetting == SprayPaint.ExportSetting.ImageToGraffitti)
                {
                    fileExport.Filter = exportFilters[0];
                } else
                {
                    fileExport.Filter = exportFilters[1];
                }
                CreatePreview();
            }
        }

        private void generateImage_Click(object sender, EventArgs e)
        {
            if (fileExport.ShowDialog() == DialogResult.OK)
            {
                if (fileImport.FileName != null && fileExport.FileName != null)
                {
                    if(exportSetting == SprayPaint.ExportSetting.ImageToGraffitti)
                    {
                        SprayPaint.Export(fileImport.FileName, fileExport.FileName);
                    } else
                    {
                        SprayPaint.Import(fileImport.FileName, fileExport.FileName);
                    }
                    
                }
            }
        }
    }
}
