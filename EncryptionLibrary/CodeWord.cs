using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class CodeWord : Encryption
    {
        private string lineKey;
        private string LineKey 
        {
            get
            {
                return lineKey;        
            }
            set
            {
                try
                {
                    if (value.Contains(' '))
                        throw new ArgumentException();
                    else
                        lineKey = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public CodeWord(string line, string lineKey) 
            : base(line) 
        {
            LineKey = lineKey;
        }

        public override string Encrypt()
        {
            var encryptionAlphavit = GetArrayEncryptionAlphavit();
            var keys = GetArrayKeys(arrayAlphavit);
            var result = String.Empty;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == -1) result += " ";
                else result += encryptionAlphavit[keys[i]];
            }

            return result;
        }

        public override string Decrypt()
        {
            var encryptionAlphavit = GetArrayEncryptionAlphavit();
            var keys = GetArrayKeys(encryptionAlphavit);
            var result = String.Empty;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == -1) result += " ";
                else result += arrayAlphavit[keys[i]];
            }

            return result;
        }

        private char[] GetArrayEncryptionAlphavit()
        {
            var arrayLineKey = GetArrayLineKeyWithoutRepeat();
            var result = arrayLineKey.Concat(arrayAlphavit).Distinct().ToArray();

            return result;
        }

        private char[] GetArrayLineKeyWithoutRepeat()
        {
            var result = new char[LineKey.Length];

            for (int i = 0; i < LineKey.Length; i++)
            {
                result[i] = LineKey[i];
            }

            return result.Distinct().ToArray();
        }
    }
}
