using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CCTSBackend.DataTransfer;
using CCTSBackend.Http;
using CCTSBackend.Service;
using Newtonsoft.Json.Linq;

namespace CCTSBackend.Http
{
    public class BlockCypherApiCaller
    {
        private static string ADDRESS_ENDPOINT_PATH = "https://api.blockcypher.com/v1/btc/main/addrs/";
        


        public static async void GetWallet(string address)
        { 
            string walletStr = await HttpService.GetHttpJson(ADDRESS_ENDPOINT_PATH + address);
            JObject jObj = JObject.Parse(walletStr);
            Wallet wallet = new Wallet();
            wallet.address = (string)jObj.SelectToken("address");
            wallet.amount = (double)jObj.SelectToken("balance");
        }
       
        
    }
}
