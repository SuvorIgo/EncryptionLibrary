using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Caesar : Encryption
    {
        public int Step { get; set; }

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

        private char[] GetArrayAlphavitWithStep()
        {
            for (int i = 0; i < arrayAlphavit.Length; i++)
            {
                arrayAlphavit[i] = (char)(arrayAlphavit[i] >> 1);
            }

            return arrayAlphavit;
        }

        public void Display()
        {
            GetArrayAlphavitWithStep();

            foreach (var item in arrayAlphavit)
            {
                Console.Write($"{item} ");
            }
        }

        public override string Encrypt() { return "There is no implementation yet"; }
        public override string Decrypt() { return "There is no implementation yet"; }
    }
}
