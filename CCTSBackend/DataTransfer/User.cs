using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCTSBackend.DataTransfer
{
    public class User
    {
        public virtual long uid {get; set;}
        public virtual string email {get; set;}
        public User() { }
        public User(long userId, string email){
            this.uid = userId;
            this.email = email;
        }
    }
}
