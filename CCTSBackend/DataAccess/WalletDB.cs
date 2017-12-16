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
        public static bool addWallet(Wallet wallet)
        {
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string insertStatement =
                "INSERT Wallet" +
                "(pubKey, userID, amount)" +
                "VALUES (@pubKey, @userID, @amount)";
            SqlCommand command = new SqlCommand(insertStatement, connection);
            command.Parameters.AddWithValue("@pubKey", wallet.pubKey);
            command.Parameters.AddWithValue("userID", wallet.userID);
            command.Parameters.AddWithValue("@amount", wallet.amount);
            try
            {
                connection.Open();
                int count = command.ExecuteNonQuery();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Wallet> GetUserWallets(long userID)
        {
            List<Wallet> wallets = new List<Wallet>();
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string selectStatement = "SELECT * FROM Wallets" +
                "WHERE userID = @userID";
            SqlCommand command = new SqlCommand(selectStatement, connection);
            command.Parameters.AddWithValue("@userID", userID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    wallets.Add(new Wallet(reader["pubKey"].ToString(),
                        (long)reader["userID"],
                        (double)reader["amount"]));
                }
            }catch(SqlException e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }

            return wallets;
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

        public static bool UpdateWallet(string oldPubKey, Wallet newWallet)
        {
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string updateStatement =
                "UPDATE Wallet SET" +
                "pubKey = @pubKey," +
                "userID = @userID," +
                "amount = @amount" +
                "WHERE pubKey = @oldPubKey";
            SqlCommand command = new SqlCommand(updateStatement, connection);
            command.Parameters.AddWithValue("@pubKey", newWallet.pubKey);
            command.Parameters.AddWithValue("@userID", newWallet.userID);
            command.Parameters.AddWithValue("@amount", newWallet.amount);
            command.Parameters.AddWithValue("@oldPubKey", oldPubKey);
            try
            {
                connection.Open();
                int count = command.ExecuteNonQuery();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteWallet(long pubKey)
        {
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string deleteStatement =
                "DELETE FROM Wallet" +
                "WHERE pubKey = @pubKey";
            SqlCommand command = new SqlCommand(deleteStatement, connection);
            command.Parameters.AddWithValue("@pubKey", pubKey);
            try
            {
                connection.Open();
                int count = command.ExecuteNonQuery();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(SqlException e)
            {
                throw e;
            }
        }
         
    }
}
