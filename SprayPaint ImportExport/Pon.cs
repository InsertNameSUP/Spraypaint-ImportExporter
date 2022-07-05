using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SprayPaint_ImportExport
{
    class Pon
    {
        private readonly static object padlock = new object();
        static UInt16[] allValues = new UInt16[65536];



        public static UInt16[] Decode(string decode)
        {
            decode = decode.Substring(1, decode.Length - 3);
            string[] splitValues = decode.Split(";");
            for (int x = 0; x < splitValues.Length; x += 2)
            {
                allValues[DecodeHex(splitValues[x]) - 1] =  (ushort)DecodeHex(splitValues[x + 1]);
    
            }
            return allValues;
        }

        public static string Encode(Dictionary<int, int> pixels)
        {
            
            StringBuilder encodedVal = new StringBuilder("[", 585456); // String builder is important for memory allocation. Using a regular string would cause Garbage Collection to
                                                                       // freeze the program as it tries to keep up with the appending. (585456 was used from the character count of a full grafitti frame.)
                                                                       // Also String Builder Append method is syncronised and therefore assists in performance during multi-threading.
           pixels.AsParallel().ForAll(entry =>
            {
                string appendMe = EncodeHex(entry.Key) + EncodeHex(entry.Value);
                lock (padlock) // Avoid string being written over twice by the different threads.
                {
                    encodedVal.Append(appendMe);
                }
                //encodedPixels.Add(EncodeHex(entry.Key) + EncodeHex(entry.Value));
            });
            encodedVal.Append("}");
            return encodedVal.ToString();
        }
        private static int DecodeHex(string str)
        {
            str = str.Substring(1);
            int num = int.Parse(str, System.Globalization.NumberStyles.HexNumber);
            return num;
        }
        public static string EncodeHex(int num)
        {
            string parsedNum = Convert.ToString(num, 16);
            string encodedVal = "X";

            return String.Concat(encodedVal, parsedNum, ";");
        }
    }
}

