using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public class Atbash : Encryption
    {
        private readonly char[] masAlphavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                                                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public Atbash(string line) => Line = line;

        public override string Encrypt()
        {
            var keys = GetMassiveKeys();
            Reverse();

            var result = String.Empty;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == -1) result += " ";
                else result += masAlphavit[keys[i]];
            }

            return result;
        }

        public override string Decrypt()
        {
            var keys = GetMassiveKeys();

            Reverse();

            var result = String.Empty;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == -1) result += " ";
                else result += masAlphavit[keys[i]];
            }

            return result;
        }

        private int[] GetMassiveKeys()
        {
            int[] massive = new int[Line.Length];

            for (int i = 0; i < Line.Length; i++)
            {
                if (Convert.ToString(Line[i]) == String.Empty) massive[i] = -1;
                else massive[i] = Array.BinarySearch(masAlphavit, Line[i]);
            }

            return massive;
        }

        private void Reverse() => Array.Reverse(masAlphavit);
    }
}
