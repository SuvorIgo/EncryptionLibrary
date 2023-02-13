using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Polybius : Encryption
    {
        Dictionary<string, string> encryptionAlphavit = new Dictionary<string, string>()
        {
            {"A", "11"}, {"B", "12"}, {"C", "13"}, {"D", "14"}, {"E", "15"}, {"F", "21"},
            {"G", "22"}, {"H", "23"}, {"I", "24"}, {"J", "24"}, {"K", "25"}, {"L", "31"},
            {"M", "32"}, {"N", "33"}, {"O", "34"}, {"P", "35"}, {"Q", "41"}, {"R", "42"},
            {"S", "43"}, {"T", "44"}, {"U", "45"}, {"V", "51"}, {"W", "52"}, {"X", "53"},
            {"Y", "54"}, {"Z", "55"}
        };

        public Polybius(string line) : base(line) { }

        public override string Encrypt()
        {
            var result = String.Empty;

            for (int i = 0; i < Line.Length; i++)
            {
                string symbol = Convert.ToString(Line[i]);
                result += encryptionAlphavit[symbol];
            }

            return result;
        }

        public override string Decrypt() => "There is no implementation yet";
    }
}
