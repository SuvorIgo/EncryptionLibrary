using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public class Atbash
    {
        private char[] masAlphavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                               'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                               's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        public Atbash() { }

        private void Reverse() => Array.Reverse(masAlphavit);
    }
}
