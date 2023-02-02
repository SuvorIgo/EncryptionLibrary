﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionLibrary
{
    public sealed class Caesar : Encryption
    {
        public int Step { get; set; }

        public Caesar(string line, string step)
            : base(line)
        { 
            Step = 1;
        } 

        public override string Encrypt() { return "There is no implementation yet"; }
        public override string Decrypt() { return "There is no implementation yet"; }
    }
}
