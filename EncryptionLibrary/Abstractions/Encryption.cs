using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionLibrary.Interfaces;

namespace EncryptionLibrary.Abstractions
{
    public abstract class Encryption : IEncryption
    {
        protected string? Line { get; set; }

        public abstract string Encrypt();
        public abstract string Decrypt();
    }
}
