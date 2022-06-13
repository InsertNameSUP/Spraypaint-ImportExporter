using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Linq;
using SprayPaint_ImportExport;

public class SprayPaint
{
    public enum ExportSetting
    {
        ImageToGraffitti,
        GraffittiToImage
    }
    static readonly Color[] colors = new Color[]
{
                Color.FromArgb(0, 0, 0), // Black
                Color.FromArgb(255, 255, 255), // White
                Color.FromArgb(255, 0, 0), // Red
                Color.FromArgb(0, 255, 0), // Green
                Color.FromArgb(0, 0, 255), // Blue
                Color.FromArgb(255, 255, 0), // Yellow
                Color.FromArgb(255, 0, 255), // Purple
                Color.FromArgb(0, 255, 255), // Teal

};
    const int totalPixelCount = 65536;
    const int frameHeight = 256, frameWidth = 256;

    static Bitmap image;
    /// <summary>
    /// Imports a save file from SUP data file and converts it to a bitmap
    /// </summary>
    /// <param name="readFile">Input File Location</param>
    /// <param name="outFile"> Where to export image to after processing (if null, it will not output to file</param>
    public static Bitmap? Import(string readFile, string outFile = null)
    {
        if (image != null) image.Dispose();
        image = new Bitmap(256, 256); // Size of canvas
        Dictionary<int, int> pixels;
        try
        {
            pixels = Pon.Decode(File.ReadAllText(readFile));
        }
        catch (Exception err)
        {
            return null;
        }

        int i = 0;
        for (var x = 0; x < image.Width; x++)
        {
            for (var y = 0; y < image.Height; y++)
            {
                int value;
                if (pixels.TryGetValue(i, out value))
                {
                    int val = (int)value - 1; // Value in save file starts at index of 1
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
    public static void Export(int exportSize, string readFile, string outFile)
    {
        if (image != null) image.Dispose();
        image = new Bitmap(Image.FromFile(readFile), new Size(exportSize, 256));
        Dictionary<int, int> pixels = new Dictionary<int, int>();
        int pixelCount = 0;
        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 256; y++)
            {
                if (image.GetPixel(x, frameHeight - 1 - y) == Color.FromArgb(0, 0, 0, 0)) { pixelCount++; continue; } // image.Height - 1 to invert image to be oriented correctly (flip X axis)
                int colorIndex = FindNearestColor(colors, image.GetPixel(x, frameHeight - 1 - y));
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
                    int colorIndex = FindNearestColor(colors, image.GetPixel(x + frameWidth, frameHeight - 1 - y));
                    pixels.Add(totalPixelCount - secondImgPC, colorIndex + 1);
                    //Console.WriteLine(pixelCount);
                    secondImgPC++;
                }
            }
            if(image != null) image.Dispose();
            string secondSerializedImage = Pon.Encode(pixels);
  
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(outFile), Path.GetFileNameWithoutExtension(outFile) + "_part2.txt"), secondSerializedImage);
        }
    }
    public static Bitmap? CreatePreview(int exportSize, ExportSetting setting, string readFile)
    {
        if (setting == ExportSetting.GraffittiToImage)
        {
            return Import(readFile);
        }
        else
        {
            if (image != null) image.Dispose();
            image = new Bitmap(Image.FromFile(readFile), new Size(exportSize, 256));
            Bitmap preview = new Bitmap(exportSize, 256);
            //if (image.Width != 256 || image.Height != 256) return null;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    if (image.GetPixel(x, y) == Color.FromArgb(0, 0, 0, 0)) { continue; } // image.Height - 1 to invert image to be oriented correctly (flip X axis)
                    int colorIndex = FindNearestColor(colors, image.GetPixel(x, y));
                    preview.SetPixel(x, y, colors[colorIndex]);
                }
            }
            image.Dispose();
            return preview;
        }
    }





    // https://www.codeproject.com/Articles/1172815/Finding-Nearest-Colors-using-Euclidean-Distance
    public static int FindNearestColor(Color[] map, Color current)
    {
        int shortestDistance;
        int index;

        index = -1;
        shortestDistance = int.MaxValue;

        for (int i = 0; i < map.Length; i++)
        {
            Color match;
            int distance;

            match = map[i];
            distance = GetDistance(current, match);

            if (distance < shortestDistance)
            {
                index = i;
                shortestDistance = distance;
            }
        }

        return index;
    }

    public static int GetDistance(Color current, Color match)
    {
        int redDifference;
        int greenDifference;
        int blueDifference;
        int alphaDifference;

        alphaDifference = current.A - match.A;
        redDifference = (current.R  - match.R);
        greenDifference = (current.G - match.G);
        blueDifference = (current.B - match.B);

        return alphaDifference * alphaDifference + redDifference * redDifference +
                                 greenDifference * greenDifference + blueDifference * blueDifference;
    }
}
