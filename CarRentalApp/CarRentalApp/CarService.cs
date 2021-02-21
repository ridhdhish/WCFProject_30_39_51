using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace CarRentalApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarService" in both code and config file together.
    public class CarService : ICarService
    {
        public void DoWork()
        {
        }

        bool ICarService.AddCar(string name)
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "insert into Cars(name) values(@name)";
                SqlParameter sqlParameter = new SqlParameter("@name", name);                
                sqlCommand.Parameters.Add(sqlParameter);                

                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
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

        bool ICarService.AssignCar(string email, string name)
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "update Cars set email=@email where name=@name";                
                SqlParameter sqlParameter = new SqlParameter("@email", email);
                SqlParameter sqlParameter2 = new SqlParameter("@name", name);
                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter2);

                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
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

        bool ICarService.DeleteCar(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "delete from Cars where Id=@id";                
                SqlParameter sqlParameter = new SqlParameter("@id", id);
                sqlCommand.Parameters.Add(sqlParameter);                

                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
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

        List<string> ICarService.GetCarNames()
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                List<string> cars = new List<string>();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select name from Cars where email=@email";
                SqlParameter sqlParameter = new SqlParameter("@email", "Not Rented");
                sqlCommand.Parameters.Add(sqlParameter);

                sqlConnection.Open();
                SqlDataReader rd = sqlCommand.ExecuteReader();
                while(rd.Read())
                {
                    cars.Add(rd.GetString(0));
                }
                return cars;
            }
        }

        DataSet ICarService.GetCars()
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select Id, name, email as Rented_by from Cars";                                

                sqlConnection.Open();
                SqlDataAdapter i = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                i.Fill(ds);

                return ds;
            }
        }

        DataSet ICarService.GetUserCar(string email)
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from Cars where email=@email";
                SqlParameter sqlParameter = new SqlParameter("@email", email);
                sqlCommand.Parameters.Add(sqlParameter);

                sqlConnection.Open();
                SqlDataAdapter i = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                i.Fill(ds);

                return ds;
            }
        }

        DataSet ICarService.GetUserCarNames(string email)
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select name from Cars where email=@email";
                SqlParameter sqlParameter = new SqlParameter("@email", email);
                sqlCommand.Parameters.Add(sqlParameter);

                sqlConnection.Open();
                SqlDataAdapter i = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                i.Fill(ds);

                return ds;
            }
        }

        bool ICarService.ReturnCar(string email, string name)
        {
            string conn = ConfigurationManager.ConnectionStrings["CR"].ToString();

            SqlConnection sqlConnection;

            using (sqlConnection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "update Cars set email=@value where email=@email AND name=@name";
                SqlParameter sqlParameter = new SqlParameter("@value", "Not Rented");
                SqlParameter sqlParameter2 = new SqlParameter("@email", email);
                SqlParameter sqlParameter3 = new SqlParameter("@name", name);
                sqlCommand.Parameters.Add(sqlParameter);
                sqlCommand.Parameters.Add(sqlParameter2);
                sqlCommand.Parameters.Add(sqlParameter3);

                sqlConnection.Open();
                int i = sqlCommand.ExecuteNonQuery();
                if (i > 0)
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
    }
}
