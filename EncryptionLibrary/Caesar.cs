using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Caesar : Encryption
    {
        private bool IsCalledEncrypt { get; set; } = false;

        private int Step { get; set; }
        private string Side { get; set; } = "left";

        public Caesar(string line)
            : base(line)
        {
            Step = 1;
        }

        public Caesar(string line, int step)
            : base(line) 
        {
            Step = step;
        }

        public Caesar(string line, int step, string side)
            : base(line) 
        { 
            Step = step;
            Side = side;
        }

        public override string Encrypt()
        {
            var encryptionAlphavit = GetArrayAlphavitWithStepAndSide();
            var keys = GetArrayKeys(arrayAlphavit);
            var result = String.Empty;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == -1) result += " ";
                else result += encryptionAlphavit[keys[i]];
            }

            IsCalledEncrypt = true;

            return result;
        }

        public override string Decrypt()
        {
            var encryptionAlphavit = GetArrayAlphavitWithStepAndSide();

            var keys = new int[arrayAlphavit.Length];

            if (IsCalledEncrypt)
            {
                keys = GetArrayKeys(arrayAlphavit);
            }
            else
            {
                keys = GetArrayKeys(encryptionAlphavit);
            }

            var result = String.Empty;

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == -1) 
                    result += " ";
                else 
                    result += arrayAlphavit[keys[i]];    
            }

            return result;
        }

        private char[] GetArrayAlphavitWithStepAndSide()
        {
            try
            {
                char[] result = new char[26];

                switch (Side)
                {
                    case "right":
                        if (Step > 1)
                            result[0] = (char)(arrayAlphavit[^1] - Step + 1);
                        else
                            result[0] = arrayAlphavit[^1];
                        break;

                    case "left":
                        result[0] = (char)(arrayAlphavit[0] + Step);
                        break;

                    default:
                        throw new ArgumentException();
                }

                for (int i = 1; i < arrayAlphavit.Length; i++)
                {
                    if (result[i - 1] == 'z')
                    {
                        result[i] = (char)(arrayAlphavit[^1] - (arrayAlphavit.Length - 1));
                        continue;
                    }
                    else
                        result[i] = (char)(result[i - 1] + 1);

                    if (result[i] == 'z')
                    {
                        result[i + 1] = (char)(arrayAlphavit[^1] - (arrayAlphavit.Length - 1));
                        i += 1;
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
        }
    }
}
