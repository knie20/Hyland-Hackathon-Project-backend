﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{address}", Name = "GetWallet")]
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
        [HttpPut("{address}")]
        public void Put(string address, [FromForm]Wallet wallet)
        {
            WalletDB.UpdateWallet(address, wallet);
        }
        
        // DELETE: api/Wallets/5
        [HttpDelete("{address}")]
        public void Delete(string address)
        {
            WalletDB.DeleteWallet(address);
        }
    }
}
