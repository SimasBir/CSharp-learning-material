using _1209ZooApp.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _1209ZooApp
{
    public class ZooService
    {
        public List<ZooModel> GetAll(SqlConnection sqlConnection)
        {

            sqlConnection.Open();
            List<ZooModel> sqlZoo = new List<ZooModel>();
            using (var command = new SqlCommand("SELECT * from dbo.Zoo", sqlConnection))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sqlZoo.Add(new ZooModel() { Name = dr.GetString(0), Description = dr.GetString(1), Gender = dr.GetString(2), Age = dr.GetInt32(3) });
                    }
                }
                sqlConnection.Close();
                return sqlZoo;
            }
        }
        public void Add(ZooModel model, SqlConnection sqlConnection)
        {
            if (model.Name != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"INSERT INTO dbo.Zoo (Name, Description, Gender, Age) VALUES ('{model.Name}','{model.Description}','{model.Gender}',{model.Age})";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Update(ZooModel model, SqlConnection sqlConnection)
        {
            if (model.Name != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                //string sqlCommand = $"INSERT INTO dbo.Zoo (Name, Description, Gender, Age) VALUES ('{model.Name}','{model.Description}','{model.Gender}',{model.Age})";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Delete(string name, SqlConnection sqlConnection)
        {
            if (name != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                //string sqlCommand = $"INSERT INTO dbo.Zoo (Name, Description, Gender, Age) VALUES ('{model.Name}','{model.Description}','{model.Gender}',{model.Age})";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}