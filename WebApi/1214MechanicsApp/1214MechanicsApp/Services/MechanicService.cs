using _1214MechanicsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1214MechanicsApp.Services
{
    public class MechanicService
    {
        public List<MechanicModel> GetAll(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            List<MechanicModel> sqlMechanics = new List<MechanicModel>();
            using (var command = new SqlCommand("SELECT * FROM dbo.Mechanics", sqlConnection))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sqlMechanics.Add(new MechanicModel() { Id = dr.GetInt32(0), Name = dr.GetString(1), Surname = dr.GetString(2), Experience = dr.GetInt32(3) });
                    }
                }

                sqlConnection.Close();
                return sqlMechanics;
            }
        }

        public void Add(MechanicModel model, SqlConnection sqlConnection)
        {
            if (model.Name != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"INSERT INTO dbo.Mechanics (Name, Surname, Experience) VALUES ('{model.Name}','{model.Surname}',{model.Experience})";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Update(MechanicModel model, SqlConnection sqlConnection)
        {
            if (model.Id != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"UPDATE dbo.Mechanics SET Name = '{model.Name}', Surname = '{model.Surname}', Experience = {model.Experience} WHERE Id = '{model.Id}'";
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
                string sqlCommand = $"DELETE FROM dbo.Mechanics WHERE Id = '{Id}'";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
