using Microsoft.AspNetCore.Mvc;
using CCTSBackend.DataAccess;
using CCTSBackend.DataTransfer;
using CCTSBackend.Service;

namespace CCTSBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        // GET: api/Users/5
        [HttpGet("{uid}", Name = "GetUser")]
        public string GetUserByID(string uid)
        {
            User user = UserDB.FetchUserByID(uid);
            
            return JSONService.SerializeToJson(user);
        }

        // POST: api/Users
        [HttpPost("")]
        public void Post([FromForm]User user)
        {
            UserDB.AddUser(user);
        }

        //POST: api/test/hello
        [HttpPost("test/{str}")]
        public string Post(string str, [FromForm]string msg)
        {
            return "You have said" + str + " and " + msg + "!";
        }

        // PUT: api/Users/6543626542...
        [HttpPut("{uid}")]
        public void Put(string uid, [FromForm]User user)
        {
            UserDB.UpdateUser(uid, user);
        }
        
        // DELETE: api/Users/65426542...
        [HttpDelete("{uid}")]
        public void Delete(string uid)
        {
            UserDB.DeleteUser(uid);
        }
    }
}
