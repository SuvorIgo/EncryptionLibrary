using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionLibrary.Interfaces;

namespace EncryptionLibrary.Abstractions
{
    abstract class Encryption : IEncryption
    {
        private string Line { get; set; }

        public Encryption(string line) => Line = line;

        public abstract string Encrypt();
        public abstract string Decrypt();
    }
}
