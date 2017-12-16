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
        public static Wallet GetWallet(int walletID)
        {
            Wallet wallet = null;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string selectStatement = "SELECT * FROM Wallet WHERE Id = @WalletID";
            SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@WalletID", walletID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    wallet = new Wallet
                    {
                        walletID = (int)reader["Id"],
                        walletOwner = reader["owner"].ToString().Trim()
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
