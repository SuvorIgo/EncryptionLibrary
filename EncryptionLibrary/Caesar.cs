using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Caesar : Encryption
    {
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

        private char[] GetArrayAlphavitWithStep()
        {
            char[] result = new char[26];
           
            result[0] = (char)(arrayAlphavit[0] + Step);

            for (int i = 1; i < arrayAlphavit.Length; i++)
            {
                if (result[i-1] == 'z')
                {
                    result[i] = (char)(arrayAlphavit[^1] - 25);
                    continue;
                }
                else
                    result[i] = (char)(result[i-1] + 1);

                if ((char)result[i] == 'z')
                {
                    result[i + 1] = (char)(arrayAlphavit[^1] - 25); i += 1;
                }
            }

            return result;
        }

        private char[] GetArrayAlphavitWithStepAndSide()
        {
            char[] result = new char[26];

            switch (Side)
            {
                case "right":
                    if (Step > 1)
                        result[0] = (char)(arrayAlphavit[^1] - Step + 1);
                    else 
                        result[0] = (char)(arrayAlphavit[^1]);

                    for (int i = 1; i < arrayAlphavit.Length; i++)
                    {
                        if (result[i - 1] == 'z')
                        {
                            result[i] = (char)(arrayAlphavit[^1] - 25);
                            continue;
                        }
                        else
                            result[i] = (char)(result[i - 1] + 1);

                        if ((char)result[i] == 'z')
                        {
                            result[i + 1] = (char)(arrayAlphavit[^1] - 25); i += 1;
                        }
                    }

                    break;

                case "left":
                    result = GetArrayAlphavitWithStep();
                    break;

                default: throw new ArgumentException();
            }

            return result;
        }
        
        

        public void Display()
        {
            var result = GetArrayAlphavitWithStepAndSide();

            foreach (var item in result)
            {
                Console.Write($"{item} {(uint)item}  ");
            }
        }

        public override string Encrypt() 
        { 
            return "There is no implementation yet"; 
        }

        public override string Decrypt() { return "There is no implementation yet"; }
    }
}
