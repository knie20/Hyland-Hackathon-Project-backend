using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCTSBackend.DataTransfer
{
    public class Transaction
    {
        public virtual string transferHash {get; set;}
        public virtual string signedHash {get; set;}
        public virtual double amount {get; set;}
        public virtual string exchangePubKey {get; set;}
        public virtual string userPubKey {get; set;}
        public Transaction() { }
        public Transaction(string transferHash,string signedHash, double amount,string exchangePubKey, string userPubKey){
            this.transferHash = transferHash;
            this.signedHash = signedHash;
            this.amount = amount;
            this.exchangePubKey = exchangePubKey;
            this.userPubKey = userPubKey;
        }
    }
}
