using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Vernam : Encryption
    {
        private static bool IsCalledEncrypt { get; set; } = false;

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

            IsCalledEncrypt = true;

            return result;
        }

        public override string Decrypt() 
        {
            if (IsCalledEncrypt)
            {
                var messageArrayAfterCallEncrypt = Encrypt().Trim().Split(' ');
                byte[] arrayAfterCallEncrypt = new byte[messageArrayAfterCallEncrypt.Length];

                for (int i = 0; i < messageArrayAfterCallEncrypt.Length; i++)
                {
                    arrayAfterCallEncrypt[i] = Convert.ToByte(messageArrayAfterCallEncrypt[i]);
                }

                var byteMassiveResult = GetArrayEncryptionXor(arrayAfterCallEncrypt);

                var result = String.Empty;

                for (int i = 0; i < byteMassiveResult.Length; i++)
                {
                    result += Convert.ToChar(byteMassiveResult[i]);
                }

                return result;
            }
            else
            {
                var byteMassiveResult = GetArrayEncryptionXor();
                var result = String.Empty;

                for (int i = 0; i < byteMassiveResult.Length; i++)
                {
                    result += String.Concat(byteMassiveResult[i], " ");
                }

                return result;
            }
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

        private byte[] GetArrayEncryptionXor(byte[] arrayBin)
        {
            GetArraysEncryptionMessageAndMessageKey(arrayBin, out byte[] messageBin, out byte[] messageKeyBin);
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

        private void GetArraysEncryptionMessageAndMessageKey(byte[] arrayBin, out byte[] messageBin, out byte[] messageKeyBin)
        { 
            messageBin = Encoding.Default.GetBytes(LineKey);
            messageKeyBin = arrayBin.Select(p => p).ToArray();
        }

        /*public void Display()
        {
            GetArraysEncryptionMessageAndMessageKey(out byte[] messageBin, out byte[] messageKeyBin);
            GetArraysEncryptionMessageAndMessageKey(new byte[] { 31, 22, 29, 16, 10, 3 }, out byte[] message, out byte[] messageKey);
            
            foreach (var item in messageBin)
            {
                Console.Write($"{item} ");
            }
            Console.Write(" - message\n");
            foreach (var item in messageKeyBin)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(" - messageKey");
            Console.WriteLine("_________________________");
            foreach (var item in message)
            {
                Console.Write($"{item} ");
            }
            Console.Write(" - messageKet\n");
            foreach (var item in messageKey)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine(" - result");
        }*/
    }
}
