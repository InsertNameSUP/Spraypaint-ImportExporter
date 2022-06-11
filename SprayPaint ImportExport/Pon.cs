using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprayPaint_ImportExport
{
    class Pon
    {
        public static Dictionary<int, int> Decode(string decode)
        {
            decode = decode.Substring(1, decode.Length - 3);
            string[] splitValues = decode.Split(";");
            Dictionary<int, int> allValues = new Dictionary<int, int>();
            for (int x = 0; x < splitValues.Length; x += 2)
            {
                Console.WriteLine(splitValues[x]);
                allValues.Add(DecodeHex(splitValues[x]), DecodeHex(splitValues[x + 1]));

            }
            return allValues;
        }

        public static string Encode(Dictionary<int, int> pixels)
        {
            string encodedVal = "[";
            foreach(KeyValuePair<int, int> value in pixels)
            {
                encodedVal += EncodeHex(value.Key);
                encodedVal += EncodeHex(value.Value);
            }
            encodedVal += "}";
            return encodedVal;
        }
        private static int DecodeHex(string str)
        {
            str = str.Substring(1);
            int num = int.Parse(str, System.Globalization.NumberStyles.HexNumber);
            return num;
        }
        private static string EncodeHex(int num)
        {
            string parsedNum = Convert.ToString(num, 16);
            string encodedVal = "X";

            return String.Concat(encodedVal, parsedNum, ";");
        }
    }
}
