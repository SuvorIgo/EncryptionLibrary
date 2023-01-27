using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public class Atbash
    {
        private string line;
        private string Line
        {
            get
            {
                return line;
            }

            set
            {
                line = value;
            }
        }

        private char[] masAlphavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                               'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                               's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public Atbash(string line) => Line = line;

        public string Encrypt()
        {
            Reverse();
            var result = String.Empty;

            for (int i = 0; i <= Line.Length; i++)
            {
                result += masAlphavit[Line[i]];
            }

            return result;
        }

        public string Decrypt()
        {
            if (masAlphavit[0] is 'z') Reverse();
            var result = String.Empty;

            for (int i = 0; i < Line.Length; i++)
            {
                result += masAlphavit[Line[i]];
            }

            return result;
        }

        private void Reverse() => Array.Reverse(masAlphavit);
    }
}
