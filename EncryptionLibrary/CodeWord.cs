using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
