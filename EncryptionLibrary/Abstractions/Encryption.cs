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

        protected readonly char[] arrayAlphavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                                'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                                                's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public abstract string Encrypt();
        public abstract string Decrypt();
    }
}
