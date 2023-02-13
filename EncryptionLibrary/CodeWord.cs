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
                    if (value.Contains(" "))
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

        public override string Encrypt() => "There is no implementation yet";
        public override string Decrypt() => "There is no implementation yet";

        private char[] GetArrayLineKeyWithoutRepeat()
        {
            Regex regex = new Regex(@"\s");

            var result = new char[LineKey.Length];

            for (int i = 0; i < LineKey.Length; i++)
            {
                if (result.Contains(LineKey[i]) || regex.IsMatch(Convert.ToString(result[i])))
                {
                    Array.Resize(ref result, result.Length -1);
                    continue;
                }

                result[i] = LineKey[i];
            }

            return result;
        }

        public void Display()
        {
            var result = GetArrayLineKeyWithoutRepeat();

            foreach (var item in result)
            {
                Console.Write($"{Array.IndexOf(result, item)}{item} ");
            }
        }
    }
}
