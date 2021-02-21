using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CarRentalApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarService" in both code and config file together.
    [ServiceContract]
    public interface ICarService
    {
        [OperationContract]
        bool AddCar(string name);
        [OperationContract]
        DataSet GetCars();
        [OperationContract]
        bool AssignCar(string email, string name);
        [OperationContract]
        bool ReturnCar(string email, string name);
        [OperationContract]
        DataSet GetUserCar(string email);
        [OperationContract]
        DataSet GetUserCarNames(string email);
        [OperationContract]
        List<string> GetCarNames();
        [OperationContract]
        bool DeleteCar(int id);
    }

    [DataContract]
    public class Car
    {
        string name, email;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
