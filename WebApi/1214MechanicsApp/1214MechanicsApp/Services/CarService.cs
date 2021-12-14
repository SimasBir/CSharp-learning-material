using _1214MechanicsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1214MechanicsApp.Services
{
    public class CarService
    {
        internal List<CarModel> GetAll(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            List<CarModel> sqlZoo = new List<CarModel>();
            using (var command = new SqlCommand("SELECT C.Id, C.Number, C.Manifacturer, C.Year, M.Name, M.Surname FROM dbo.Cars AS C JOIN dbo.Mechanics AS M ON C.AssignedId = M.Id ", sqlConnection))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sqlZoo.Add(new CarModel() { Id = dr.GetInt32(0), Number = dr.GetString(1), Manifacturer = dr.GetString(2), Year = dr.GetInt32(3), AssignedName = dr.GetString(4), AssignedSurname = dr.GetString(5) });
                    }
                }

                sqlConnection.Close();
                return sqlZoo;

            }
        }

        public void Add(CarModel model, SqlConnection sqlConnection)
        {
            if (model.Number != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"INSERT INTO dbo.Cars (Number, Manifacturer, Year, AssignedId) VALUES ('{model.Number}','{model.Manifacturer}','{model.Year}',{model.AssignedId})";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Update(CarModel model, SqlConnection sqlConnection)
        {
            if (model.Id != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"UPDATE dbo.Cars SET Number ='{model.Number}', Manifacturer = '{model.Manifacturer}', Year = '{model.Year}', AssignedId = {model.AssignedId} WHERE Id = '{model.Id}'";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Delete(string Id, SqlConnection sqlConnection)
        {
            if (Id != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"DELETE FROM dbo.Cars WHERE Id = '{Id}'";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }


    }
}
