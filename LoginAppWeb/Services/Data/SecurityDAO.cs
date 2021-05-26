using LoginAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginAppWeb.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserModel user)
        {
            // return (user.Username == "Admin" && user.Password == "secret");

            bool success = false;
            string queryString = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @Password";

            // create and open the connection to the database inside a using block
            //this ensures that all resourses are closed properly when the query is done
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(queryString,connection);
                sqlCommand.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = user.Username;
                sqlCommand.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            return success;
        }
    }
}