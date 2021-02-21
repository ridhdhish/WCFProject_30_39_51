using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace CarRentalApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {
        bool IUserService.Signin(string email, string password)
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from Users where email=@email AND password=@password";
                SqlParameter sqlParameter = new SqlParameter("@email", email);
                SqlParameter sqlParameter2 = new SqlParameter("@password", password);
                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter2);

                sqlConnection.Open();
                SqlDataReader i = sqlCommand.ExecuteReader();
                if (i.Read())
                {
                    sqlConnection.Close();
                    return true;
                }
                else
                {
                    sqlConnection.Close();
                    return false;
                }
            }            
        }

        bool IUserService.Signup(string email, string password)
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using(sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "insert into Users(email, password) values(@email, @password)";
                SqlParameter sqlParameter = new SqlParameter("@email", email);
                SqlParameter sqlParameter2 = new SqlParameter("@password", password);
                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter2);

                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                if(i > 0)
                {
                    sqlConnection.Close();
                    return true;
                } else
                {
                    sqlConnection.Close();
                    return false;
                }
            }
        }
    }
}
