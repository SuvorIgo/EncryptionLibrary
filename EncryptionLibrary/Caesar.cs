using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Caesar : Encryption
    {
        public Caesar(string line) => Line = line;

        public override string Encrypt() { return "There is no implementation yet"; }
        public override string Decrypt() { return "There is no implementation yet"; }
    }
}
