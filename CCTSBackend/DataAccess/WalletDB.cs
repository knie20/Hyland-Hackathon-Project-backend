using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CCTSBackend.DataTransfer;

namespace CCTSBackend.DataAccess
{
    public static class WalletDB
    {
        public static bool AddWallet(Wallet wallet)
        {
            bool retVal = false;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query =
                "INSERT Wallet" +
                "(pubKey, userID, amount)" +
                "VALUES (@pubKey, @userID, @amount)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@pubKey", wallet.pubKey);
            command.Parameters.AddWithValue("@userID", wallet.userID);
            command.Parameters.AddWithValue("@amount", wallet.amount);
            try
            {
                connection.Open();
                int count = command.ExecuteNonQuery();
                if(count > 0)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }
            catch (SqlException e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
            }

            return retVal;
        }

        public static List<Wallet> FetchUserWallets(long userID)
        {
            List<Wallet> wallets = new List<Wallet>();
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "SELECT * FROM Wallets" +
                "WHERE userID = @userID";
            SqlCommand command = new SqlCommand(query, connection);
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
                Console.Write(e);
            }
            finally
            {
                connection.Close();
            }

            return wallets;
        }

        public static Wallet FetchWalletByKey(string pubKey)
        {
            Wallet wallet = null;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "SELECT * FROM Wallet " +
                "WHERE pubKey = @pubKey";
            SqlCommand command = new SqlCommand(query, connection);
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
            bool retVal = false;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "UPDATE Wallet SET userID = @userID, amount = @amount WHERE pubKey = @oldPubKey";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", newWallet.userID);
            command.Parameters.AddWithValue("@amount", newWallet.amount);
            command.Parameters.AddWithValue("@oldPubKey", oldPubKey);
            try
            {
                connection.Open();
                int count = command.ExecuteNonQuery();
                if(count > 0)
                {
                     retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }
            catch(SqlException e)
            {
                Console.Write(e);
            }
            finally
            {
                connection.Close();
            }

            return retVal;
        }

        public static bool DeleteWallet(string pubKey)
        {
            bool retVal = false;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "DELETE FROM Wallet WHERE pubKey = @pubKey";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@pubKey", pubKey);
            try
            {
                connection.Open();
                int count = command.ExecuteNonQuery();
                if(count > 0)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }catch(SqlException e)
            {
                Console.Write(e);
            }

            return retVal;
        }
         
    }
}
