using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Atbash : Encryption
    {
        public Atbash(string line) : base(line) { }

        public override string Encrypt()
        {
            var keys = GetArrayKeys(arrayAlphavit);

            Reverse();

            var result = String.Empty;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == -1) result += " ";
                else result += arrayAlphavit[keys[i]];
            }

            return result;
        }

        public override string Decrypt()
        {
            var keys = GetArrayKeys(arrayAlphavit);

            Reverse();

            var result = String.Empty;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == -1) result += " ";
                else result += arrayAlphavit[keys[i]];
            }

            return result;
        }

        private void Reverse() => Array.Reverse(arrayAlphavit);
    }
}
