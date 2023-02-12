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
                    if (Line.Length != value.Length)
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

        public override string Encrypt() { return "There is no implementation yet"; }
        public override string Decrypt() { return "There is no implementation yet"; }

        private string[] GetArrayEncryptionXor()
        {
            GetArraysEncryptionMessageAndMessageKey(out string[] messageBin, out string[] messageKeyBin);

            var result = new string[messageBin.Length];
            var resultLine = String.Empty;

            for (int i = 0; i < messageBin.Length; i++)
            {
                var lineCharOfBin = messageBin[i];
                var lineKeyCharOfBin = messageKeyBin[i];
                
                for (int j = 0; j < lineCharOfBin.Length; j++)
                {
                    resultLine += lineCharOfBin[j] ^ lineKeyCharOfBin[j];
                }
                
                result[i] = resultLine;
                resultLine = String.Empty;
            }

            return result;
        }

        private void GetArraysEncryptionMessageAndMessageKey(out string[] messageBin, out string[] messageKeyBin) 
        {
            messageBin = new string[Line.Length];
            messageKeyBin = new string[Line.Length];

            for (int i = 0; i < Line.Length; i++)
            {
                messageBin[i] = String.Concat("0", Convert.ToString(Line[i], 2));
                messageKeyBin[i] = String.Concat("0", Convert.ToString(LineKey[i], 2)); 
            }
        }

        public void Display()
        {
            GetArraysEncryptionMessageAndMessageKey(out string[] messageBin, out string[] messageKeyBin);
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
        }
    }
}
