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

        private void GetArraysEncryptionMessageAndMessageKey(out string[] messageBin, out string[] messageKeyBin) 
        {
            messageBin = new string[Line.Length];
            messageKeyBin = new string[Line.Length];

            for (int i = 0; i < Line.Length; i++)
            {
                messageBin[i] = Convert.ToString(Line[i], 2);
                messageKeyBin[i] = Convert.ToString(LineKey[i], 2); 
            }
        }

        /*public void Display()
        {
            GetArraysEncryptionMessageAndMessageKey(out string[] messageBin, out string[] messageKeyBin);

            foreach (var item in messageBin)
            {
                Console.Write($"0{item} ");
            }
            Console.WriteLine("");
            foreach (var item in messageKeyBin)
            {
                Console.Write($"0{item} ");
            }
        }*/
    }
}
