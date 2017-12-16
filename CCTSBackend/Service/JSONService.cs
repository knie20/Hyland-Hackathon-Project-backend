using System;
using System.Collections.Generic;
using CCTSBackend.DataTransfer;
using Newtonsoft.Json;

namespace CCTSBackend.Service
{
    public class JSONService
    {
        public static string SerializeToJson(Wallet wallet)
        {
            return JsonConvert.SerializeObject(wallet);
        }

        public static Wallet DeserializeWalletFromJson(string jsonWallet)
        {
            return JsonConvert.DeserializeObject<Wallet>(jsonWallet);
        }

        public static string SerializeToJson(Transaction tx)
        {
            return JsonConvert.SerializeObject(tx);
        }

        public static Transaction DeserializeTxFromJson(string jsonTx)
        {
            return JsonConvert.DeserializeObject<Transaction>(jsonTx);
        }

        public static string SerializeToJson(User user)
        {
            return JsonConvert.SerializeObject(user);
        }

         public static User DeserializeUserFromJson(string jsonUser)
        {
            return JsonConvert.DeserializeObject<User>(jsonUser);
        }

        internal static string SerializeToJson(List<Wallet> list)
        {
            throw new NotImplementedException();
        }

        public static string SerializeToJson(List<Object> list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
