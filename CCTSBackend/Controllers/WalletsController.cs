using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using CCTSBackend.DataAccess;
using CCTSBackend.DataTransfer;
using System.Runtime.Serialization.Json;

namespace CCTSBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Wallets")]
    public class WalletsController : Controller
    {
        // GET: api/Wallets
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Wallets/5
        [HttpGet("{id}", Name = "GetWallet")]
        public string GetById(int id)
        {


            Wallet wallet = WalletDB.GetWallet(id);

            string guh = JsonConvert.SerializeObject(wallet).ToString().Replace("\"" , "'");
            return guh;
        }
        
        // POST: api/Wallets
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Wallets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
