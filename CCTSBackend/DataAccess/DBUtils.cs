using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CCTSBackend.DataAccess
{
    public class DBUtils
    {
        public static string GetConnectionString()
        {
            return "Server=tcp:ccts-hylandhackathon2017.database.windows.net,1433;" +
                "Initial Catalog=ccts;Persist Security Info=False;" +
                "User ID=devAdmin;" +
                "Password=Hylandhackathon2017;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;";
        }
    }
}
