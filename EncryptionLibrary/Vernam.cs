using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Vernam : Encryption
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
                    if (Line.Length != value.Length || Line.Contains(" ") || value.Contains(" "))
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

        public Vernam(string line, string lineKey) 
            : base(line) 
        { 
            LineKey = lineKey;
        }

        public override string Encrypt() 
        {
            var byteMassiveResult = GetArrayEncryptionXor();
            var result = String.Empty;

            for (int i = 0; i < byteMassiveResult.Length; i++)
            {
                result += String.Concat(byteMassiveResult[i], " ");
            }

            return result;
        }

        public override string Decrypt() 
        { 
            return "There is no implementation yet"; 
        }

        private byte[] GetArrayEncryptionXor()
        {
            GetArraysEncryptionMessageAndMessageKey(out byte[] messageBin, out byte[] messageKeyBin);
            var result = new byte[messageKeyBin.Length];

            for (int i = 0; i < messageBin.Length; i++)
            {
                result[i] = (byte)(messageBin[i] ^ messageKeyBin[i]);
            }

            return result;
        }

        private void GetArraysEncryptionMessageAndMessageKey(out byte[] messageBin, out byte[] messageKeyBin)
        {
            messageBin = Encoding.Default.GetBytes(Line);
            messageKeyBin = Encoding.Default.GetBytes(LineKey);
        }

        private int[] GetArrayKeys(char[] alphavit)
        {
            int[] massive = new int[Line.Length];

            for (int i = 0; i < Line.Length; i++)
            {
                if (Convert.ToString(Line[i]) == String.Empty) massive[i] = -1;
                else massive[i] = Array.IndexOf(alphavit, Line[i]);
            }

            return massive;
        }

        public void Display()
        {
            GetArraysEncryptionMessageAndMessageKey(out byte[] messageBin, out byte[] messageKeyBin);
            var result = GetArrayEncryptionXor();

            foreach (var item in messageBin)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            foreach (var item in messageKeyBin)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\n{Encrypt()}");
        }
    }
}
