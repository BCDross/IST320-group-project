using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BurnBuilder.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BurnBuilder.DAL
{
    // <summary>
    /// These are all the methods that work with the User Table in the database. 
    /// They perform the CRUD operations. 
    /// </summary>
    public class DALUser
    {
        private IConfiguration _configuration { get; }

        public DALUser(IConfiguration config)
        {
            _configuration = config;
        }

        internal int InsertUser(User user)
        {
            string connStr = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "INSERT INTO [dbo].[User]([EmailAddress],[Password],[FirstName],[LastName],[Created])" + " VALUES (@EmailAddress,@Password,@FirstName,@LastName,@Created) select SCOPE_IDENTITY() as id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Created", user.Created);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int userID = Convert.ToInt32(reader[0].ToString());

            reader.Close();

            conn.Close();
            
            return userID;
        }

        internal User GetUserById(int userId)
        {
            string connStr = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "SELECT [EmailAddress], [Password], [FirstName], [LastName], [Created] FROM [dbo].[User] WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@UserID", userId);
            
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            string emailAddress = reader["EmailAddress"].ToString();
            string password = reader["Password"].ToString();
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            DateTime created = Convert.ToDateTime(reader["Created"].ToString());

            reader.Close();

            conn.Close();

            User u = new User();
            u.EmailAddress = emailAddress;
            u.Password = password;
            u.FirstName = firstName;
            u.LastName = lastName;
            u.Created = created;

            return u;
        }

        internal User UpdateUser(User user)
        {
            string connStr = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "UPDATE [dbo].[User] SET [EmailAddress] = @EmailAddress, [Password] = @Password, [FirstName] = @FirstName, [LastName] = @LastName, [Created] = @Created WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Created", user.Created);
            cmd.Parameters.AddWithValue("@UserID", user.UserId);

            cmd.ExecuteNonQuery();

            conn.Close();

            User u = new User();
            
            return u;
        }

        internal void DeleteUser(int userId)
        {
            string connStr = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "DELETE [dbo].[User] WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@UserID", userId);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        // May implement a loginCredentials Model for this as it is simple and more secure.
        internal User IsValidUser(User user)
        {
            string connStr = _configuration.GetConnectionString("DefaultConnection");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            string query = "SELECT UserID, FirstName FROM [User] WHERE EmailAddress = @EmailAddress AND Password = @Password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            SqlDataReader reader = cmd.ExecuteReader();
            User u = new User();

            if (reader.Read())
            {
                u.FirstName = reader["FirstName"].ToString();
                u.UserId = Convert.ToInt32(reader["UserID"]);
            }
            else
            {
                // Need to figure out to return something if they are not valid users. Maybe in version 1.1.
            }

            reader.Close();

            conn.Close();
            
            return u;
        }
    }
}
