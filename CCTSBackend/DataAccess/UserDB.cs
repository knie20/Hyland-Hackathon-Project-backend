using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CCTSBackend.DataTransfer;

namespace CCTSBackend.DataAccess
{
    public static class UserDB
    {
        public static bool AddUser(User user)
        {
            bool retVal = false;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query =
                "INSERT User" +
                "(uid, email)" +
                "VALUES (@uid, @email)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", user.uid);
            command.Parameters.AddWithValue("@emailaddress", user.email);
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

        public static User FetchUserByID(string uid)
        {
            User user = null;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "SELECT * FROM User " +
                "WHERE uid = @uid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@uid", uid);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    user = new User
                    {
                        uid =  (long) reader["uid"],
                        email = reader["email"].ToString()
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

            return user;
        }

        public static bool UpdateUser(string uid, User newUser)
        {
            bool retVal = false;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "UPDATE User SET email = @email WHERE uid = @uid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@uid", newUser.uid);
            command.Parameters.AddWithValue("@email", newUser.email);
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

        public static bool DeleteUser(string uid)
        {
            bool retVal = false;
            SqlConnection connection = new SqlConnection(DBUtils.GetConnectionString());
            string query = "DELETE FROM User WHERE uid = @uid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@uid", uid);
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
