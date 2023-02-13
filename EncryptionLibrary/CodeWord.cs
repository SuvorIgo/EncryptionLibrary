using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class CodeWord : Encryption
    {
        CodeWord(string line) : base(line) { }

        public override string Encrypt() => "There is no implementation yet";
        public override string Decrypt() => "There is no implementation yet";

    }
}
