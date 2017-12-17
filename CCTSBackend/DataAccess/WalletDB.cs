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
                "(address, userID, amount)" +
                "VALUES (@address, @userID, @amount)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@address", wallet.address);
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
                    wallets.Add(new Wallet(reader["address"].ToString(),
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

        public static Wallet FetchWalletByKey(string address)
        {
            Wallet wallet = null;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "SELECT * FROM Wallet " +
                "WHERE address = @address";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@address", address);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    wallet = new Wallet
                    {
                        address = reader["address"].ToString(),
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

        public static bool UpdateWallet(string address, Wallet newWallet)
        {
            bool retVal = false;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "UPDATE Wallet SET userID = @userID, amount = @amount WHERE address = @oldPubKey";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", newWallet.userID);
            command.Parameters.AddWithValue("@amount", newWallet.amount);
            command.Parameters.AddWithValue("@address", address);
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

        public static bool DeleteWallet(string address)
        {
            bool retVal = false;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "DELETE FROM Wallet WHERE address = @address";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@address", address);
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
