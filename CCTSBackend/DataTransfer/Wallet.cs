using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCTSBackend.DataTransfer
{
    public class Wallet
    {
        public virtual long userID {get; set;}

        public virtual double amount {get; set;}
        public virtual string address {get; set;}
        public Wallet() { }

        public Wallet(string address, long userId, double amount){
            this.userID = userId;
            this.amount = amount;
            this.address = address;

        }
    }
}
