using _1213ZooApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1213ZooApp2.Services
{
    public class ZooService2
    {
        public List<ZooModel2> GetAll(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            List<ZooModel2> sqlZoo = new List<ZooModel2>();
            using (var command = new SqlCommand("SELECT * from dbo.Zoo2", sqlConnection))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sqlZoo.Add(new ZooModel2() {Id= dr.GetInt32(0), Name = dr.GetString(1), Description = dr.GetString(2), Gender = dr.GetString(3), Age = dr.GetInt32(4) });
                    }
                }

                sqlConnection.Close();
                return sqlZoo;
            }
        }

        public void Add(ZooModel2 model, SqlConnection sqlConnection)
        {
            if (model.Name != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"INSERT INTO dbo.Zoo2 (Name, Description, Gender, Age) VALUES ('{model.Name}','{model.Description}','{model.Gender}',{model.Age})";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Update(ZooModel2 model, SqlConnection sqlConnection)
        {
            if (model.Id != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"UPDATE dbo.Zoo2 SET '{model.Name}', Name = Description = '{model.Description}', Gender = '{model.Gender}', Age = {model.Age} WHERE Id = '{model.Id}'";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void ClearTable(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sqlCommand = $"DELETE FROM dbo.zoo2 WHERE ID=1 DBCC CHECKIDENT ('dbo.zoo2', RESEED, 0)";
            adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
            adapter.InsertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void Delete(string Id, SqlConnection sqlConnection)
        {
            if (Id != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"DELETE FROM dbo.Zoo2 WHERE Id = '{Id}'";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
