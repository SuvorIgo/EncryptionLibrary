using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Vernam : Encryption
    {

        public Vernam(string line) : base(line) { }

        public override string Encrypt() { return "There is no implementation yet"; }
        public override string Decrypt() { return "There is no implementation yet"; }
    }
}
