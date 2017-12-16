using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCTSBackend.DataTransfer
{
    public class Wallet
    {
        public Wallet() { }
        public virtual int walletID { get; set; }
        public virtual string walletOwner { get; set; }
    }
}
