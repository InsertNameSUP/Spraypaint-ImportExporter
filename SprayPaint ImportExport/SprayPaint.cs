using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Linq;
using SprayPaint_ImportExport;
using AForge;
public class SprayPaint
{
    public enum ExportSetting
    {
        ImageToGraffitti,
        GraffittiToImage
    }
    /*
    rp.cfg.GraffitiColors={
                           Color(0,0,0)
                           Color(255,255,255),
                            Color(255,0,0),
                            Color(0,255,0),
                            Color(0,0,255),
                            Color(255,255,0),
                            Color(255,0,255),
                            Color(0,255,255),
                            Color(255,200,0),
                            Color(255,150,0),
                            Color(255,80,0),
                            Color(150,0,150),
                            Color(100,0,200),
                            Color(80,0,255),
                            Color(155,255,0)
    } 
     */
    static readonly Color[] colors = new Color[]
{
                Color.FromArgb(0, 0, 0), // Black
                Color.FromArgb(255, 255, 255), // White
                Color.FromArgb(255, 0, 0), // Yellow
                Color.FromArgb(0, 255, 0), // Yellow
                Color.FromArgb(0, 0, 255), // Yellow
                Color.FromArgb(255, 255, 0), // Yellow
                Color.FromArgb(255, 0, 255), // Red
                Color.FromArgb(0, 255, 255), // Pink
                Color.FromArgb(255, 200, 0), // Pink
                Color.FromArgb(255, 150, 0), // Pink
                Color.FromArgb(255, 80, 0), // Pink
                Color.FromArgb(150, 0, 150), // Blue
                Color.FromArgb(100, 0, 200), // Teal
                Color.FromArgb(80, 0, 255), // Green
                Color.FromArgb(155, 255, 0), // Green
};
    const int totalPixelCount = 65536;
    const int frameHeight = 256, frameWidth = 256;

    static Bitmap image;
    /// <summary>
    /// Imports a save file from SUP data file and converts it to a bitmap
    /// </summary>
    /// <param name="readFile">Input File Location</param>
    /// <param name="outFile"> Where to export image to after processing (if null, it will not output to file</param>
    public static Bitmap? Graffiti2Img(string readFile, string outFile = null)
    {
        if (image != null) image.Dispose();
        image = new Bitmap(256, 256); // Size of canvas
        UInt16[] pixels;
        pixels = readFile.EndsWith(".txt") ? Pon.Decode(File.ReadAllText(readFile)) : Binary.UnBinarify(readFile);

        int i = 0;
        for (var x = 0; x < image.Width; x++)
        {
            for (var y = 0; y < image.Height; y++)
            {
                if (pixels[i] != 0)
                {
                    int val = pixels[i] - 1; // Value in save file starts at index of 1
                                              // Flip X value because otherwise it looks flipped on the Y Axis
                    image.SetPixel(image.Width - 1 - x, y, colors[val]);
                }
                else
                {
                    image.SetPixel(image.Width - 1 - x, y, Color.Transparent);
                }
                i++;
            }
        }
        if (outFile != null)
        {
            image.Save(outFile);
            image.Dispose();
        }
        return image;
    }
    /// <summary>
    /// Converts an image file to a SUP data file suitable for graffitti
    /// </summary>
    /// <param name="readFile">An image file</param>
    /// <param name="outFile">Output file where the data file will be saved</param>
    public static void Img2Graffiti(int exportSize, string readFile, string outFile)
    {
        if (image != null) image.Dispose();
        image = new Bitmap(Image.FromFile(readFile), new Size(exportSize, 256));
        AForge.Imaging.ColorReduction.FloydSteinbergColorDithering dithering = new AForge.Imaging.ColorReduction.FloydSteinbergColorDithering();
        dithering.ColorTable = colors;
        image = dithering.Apply(image);
        Dictionary<int, int> pixels = new Dictionary<int, int>();
        int pixelCount = 0;
        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 256; y++)
            {
                if (image.GetPixel(x, frameHeight - 1 - y).A == 0) { pixelCount++; continue; } // image.Height - 1 to invert image to be oriented correctly (flip X axis)
                int colorIndex = GetColor(image.GetPixel(x, frameHeight - 1 - y));
                pixels.Add(totalPixelCount - pixelCount, colorIndex + 1);
                //Console.WriteLine(pixelCount);
                pixelCount++;
            }
        }
        string serializedImage = Pon.Encode(pixels);
        File.WriteAllText(outFile, serializedImage);
        pixels.Clear();
        if (exportSize == 512)
        {
            int secondImgPC = 0;
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    if (image.GetPixel(x + frameWidth, frameHeight - 1 - y) == Color.FromArgb(0, 0, 0, 0)) { secondImgPC++; continue; } // image.Height - 1 to invert image to be oriented correctly (flip X axis)
                    int colorIndex = GetColor(image.GetPixel(x + frameWidth, frameHeight - 1 - y));
                    pixels.Add(totalPixelCount - secondImgPC, colorIndex + 1);
                    //Console.WriteLine(pixelCount);
                    secondImgPC++;
                }
            }
            if (image != null) image.Dispose();
            string secondSerializedImage = Pon.Encode(pixels);

            File.WriteAllText(Path.Combine(Path.GetDirectoryName(outFile), Path.GetFileNameWithoutExtension(outFile) + "_part2.txt"), secondSerializedImage);
        }
        pixels.Clear();
    }
    public static Bitmap? CreatePreview(int exportSize, ExportSetting setting, string readFile)
    {
        if (setting == ExportSetting.GraffittiToImage)
        {
            return Graffiti2Img(readFile);
        }
        if (image != null) image.Dispose();
        image = new Bitmap(Image.FromFile(readFile), new Size(exportSize, 256));
        AForge.Imaging.ColorReduction.FloydSteinbergColorDithering dithering = new AForge.Imaging.ColorReduction.FloydSteinbergColorDithering();
        dithering.ColorTable = colors;
        return dithering.Apply(image);
    }


    static int GetColor(Color col)
    {

        for(int x = 0; x < colors.Length; x++)
        {
            if (colors[x].Equals(col)) return x;
        }
        return 0; // Return black if error
    }
    class Binary
    {
        public static UInt16[] UnBinarify(string filePath) // https://www.dotnetperls.com/binaryreader with a few additions to better suit spraypaint
        {
            UInt16[] decoded = new UInt16[65536];
            // 1.
            using (BinaryReader b = new BinaryReader(
                File.Open(filePath, FileMode.Open)))
            {
                // 2.
                // Position and length variables.
                int pos = 0;
                // 2A.
                // Use BaseStream.
                int length = (int)b.BaseStream.Length;
                while (pos < length)
                {
                    // 3.
                    // Read integer.
                    ushort v = (ushort)(b.ReadUInt16() >> 8);
                    decoded[pos] = v;
                    // 4.
                    // Advance our position variable.
                    pos += sizeof(ushort);
                }
                b.Close();
                b.Dispose();
                return decoded;
            }
        }

        public static void ReBinarify(int[] pixels, string filePath)
        {
            using(BinaryWriter b = new BinaryWriter(File.Open(filePath, FileMode.Open)))
            {
                int pos = 0;

                for(int x = 0; x > pixels.Length; x++)
                {
                    b.Write(pixels[x]);
                }
                b.Close();
                b.Dispose();
            }
        }
    }
    
}
