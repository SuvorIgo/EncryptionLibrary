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
            {"a", "11"}, {"b", "12"}, {"c", "13"}, {"d", "14"}, {"e", "15"}, {"f", "21"},
            {"g", "22"}, {"h", "23"}, {"i", "24"}, {"j", "24"}, {"k", "25"}, {"l", "31"},
            {"m", "32"}, {"n", "33"}, {"o", "34"}, {"p", "35"}, {"q", "41"}, {"r", "42"},
            {"s", "43"}, {"t", "44"}, {"u", "45"}, {"v", "51"}, {"w", "52"}, {"x", "53"},
            {"y", "54"}, {"z", "55"}
        };

        public Polybius(string line) : base(line) { }

        public override string Encrypt()
        {
            var result = String.Empty;

            for (int i = 0; i < Line.Length; i++)
            {
                if (Line[i] == ' ')
                {
                    result += ' ';
                    continue;
                }
                else
                {
                    string symbol = Convert.ToString(Line[i]);
                    result += encryptionAlphavit[symbol];
                }
                
            }

            return result;
        }

        public override string Decrypt()
        {
            var result = String.Empty;

            for (int i = 0; i < Line.Length; i++)
            {
                if (Line[i] == ' ')
                {
                    result += ' ';
                    continue;
                }   
                else
                {
                    string symbol = Convert.ToString(Line[i]) + Convert.ToString(Line[++i]);
                    result += encryptionAlphavit.Where(p => p.Value == symbol).FirstOrDefault().Key;
                }
            }

            return result;
        }
    }
}
