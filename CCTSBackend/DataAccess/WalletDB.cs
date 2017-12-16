using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using CCTSBackend.DataTransfer;
using System.Threading.Tasks;

namespace CCTSBackend.DataAccess
{
    public static class WalletDB
    {
        public static List<Wallet> GetUserWallets(long userId)
        {
            List<Wallet> wallets = new List<Wallet>();
            string selectStatement = "SELECT DISTINCT";
        }

        public static Wallet GetWallet(string pubKey)
        {
            Wallet wallet = null;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string selectStatement = "SELECT * FROM Wallet WHERE Id = @pubKey";
            SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@pubKey", pubKey);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    wallet = new Wallet
                    {
                        pubKey = reader["pubKey"].ToString(),
                        amount = (double) reader["amount"],
                        userID = (long) reader["userID"]
                    };
                }
            }catch(SqlException e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
            }

            return wallet;
        }

    }
}
