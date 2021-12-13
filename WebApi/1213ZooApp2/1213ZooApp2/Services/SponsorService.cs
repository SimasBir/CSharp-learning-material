using _1213ZooApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1213ZooApp2.Services
{
    public class SponsorService
    {
        public List<SponsorModel> GetAll(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            List<SponsorModel> sqlZoo = new List<SponsorModel>();
            using (var command = new SqlCommand("SELECT * from dbo.Sponsor", sqlConnection))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sqlZoo.Add(new SponsorModel() { Id = dr.GetInt32(0), FirstName = dr.GetString(1), LastName = dr.GetString(2), Amount = dr.GetInt32(3), ZooId = dr.GetInt32(4) });
                    }
                }

                sqlConnection.Close();
                return sqlZoo;
            }
        }

        public void Add(SponsorModel model, SqlConnection sqlConnection)
        {
            if (model.FirstName != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"INSERT INTO dbo.Sponsor (FirstName, LastName, Amount, ZooId) VALUES ('{model.FirstName}','{model.LastName}','{model.Amount}',{model.ZooId})";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void Update(SponsorModel model, SqlConnection sqlConnection)
        {
            if (model.Id != null)
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sqlCommand = $"UPDATE dbo.Sponsor SET '{model.FirstName}', FirstName = LastName = '{model.LastName}', Amount = '{model.Amount}', ZooId = {model.ZooId} WHERE Id = '{model.Id}'";
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
                string sqlCommand = $"DELETE FROM dbo.Sponsor WHERE Id = '{Id}'";
                adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
                adapter.InsertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void ClearTable(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sqlCommand = $"DELETE FROM dbo.Sponsor WHERE ID=1 DBCC CHECKIDENT ('dbo.Sponsor', RESEED, 0)";
            adapter.InsertCommand = new SqlCommand(sqlCommand, sqlConnection);
            adapter.InsertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
