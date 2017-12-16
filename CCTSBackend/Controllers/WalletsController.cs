using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CCTSBackend.DataAccess;
using CCTSBackend.DataTransfer;
using CCTSBackend.Service;

namespace CCTSBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Wallets")]
    public class WalletsController : Controller
    {
        // GET: api/Wallets/5
        [HttpGet("{id}", Name = "GetWallet")]
        public string GetWalletByKey(string pubKey)
        {
            Wallet wallet = WalletDB.FetchWalletByKey(pubKey);
            
            return JSONService.SerializeToJson(wallet);
        }

        // GET: api/Wallets/user/5
        [HttpGet("user/{userID}", Name = "GetUserWallets")]
        public string GetUserWalletsByKey(long userID) => 
            JSONService.SerializeToJson(WalletDB.FetchUserWallets(userID));

        // POST: api/Wallets
        [HttpPost]
        public void Post([FromBody]string value)
        {
            WalletDB.addWallet(JSONService.DeserializeWalletFromJson(value));
        }
        
        // PUT: api/Wallets/asflasdlgjvln
        [HttpPut("{oldPubKey}")]
        public void Put(string oldPubKey, [FromBody]string value)
        {
            WalletDB.UpdateWallet(oldPubKey, JSONService.DeserializeWalletFromJson(value));
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
