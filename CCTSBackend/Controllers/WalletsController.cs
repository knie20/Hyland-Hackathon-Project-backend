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
        [HttpGet("{pubKey}", Name = "GetWallet")]
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
        [HttpPost("")]
        public void Post([FromForm]Wallet wallet)
        {
            WalletDB.AddWallet(wallet);
        }
        
        // PUT: api/Wallets/asflasdlgjvln
        [HttpPut("{oldPubKey}")]
        public void Put(string oldPubKey, [FromForm]Wallet wallet)
        {
            WalletDB.UpdateWallet(oldPubKey, wallet);
        }
        
        // DELETE: api/delete/5
        [HttpDelete("{pubKey}")]
        public void Delete(string pubKey)
        {
            WalletDB.DeleteWallet(pubKey);
        }
    }
}
