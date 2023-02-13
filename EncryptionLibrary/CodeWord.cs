using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//TODO: Реализовать методы Encrypt() и Decrypt();
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

        public override string Encrypt() => "There is no implementation yet";
        public override string Decrypt() => "There is no implementation yet";

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

        public void Display()
        {
            var result = GetArrayLineKeyWithoutRepeat();
            var resultTwo = GetArrayEncryptionAlphavit();

            foreach (var item in result)
            {
                Console.Write($"{Array.IndexOf(result, item)}{item} ");
            }
            Console.WriteLine("\n____");
            foreach (var item in resultTwo)
            {
                Console.Write($"{Array.IndexOf(resultTwo, item)}{item} ");
            }
        }
    }
}
