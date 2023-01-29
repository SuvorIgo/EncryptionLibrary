using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary.Interfaces
{
    interface IEncryption
    {
        public string Encrypt();
        public string Decrypt();
    }
}
