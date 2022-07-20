using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interfaces;



namespace DAL
{
    public class CounterDAO : ICounterDAO
    {
        private readonly string _connectionString;
        public CounterDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Counter> GetAll()
        {
            var rewards = new List<Counter>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT [Id], [Title], [Description] FROM dbo.Rewards", connection))
            {
                connection.Open();
                //command.ExecuteNonQuery();
                //command.ExecuteScalar();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var counter = new Counter
                    (
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.IsDBNull(2) ? null : reader.GetString(2)
                    );
                    rewards.Add(counter);
                }
            }
            return counters;
        }
        public void Edit(Counter counter)
        {
            using (var connection = new SqlConnection(_connectionString))
            //using (var command = new SqlCommand($"INSERT INTO dbo.Rewards VALUES('{reward.Title}', '{reward.Description}')", connection))
            using (var command = new SqlCommand("EXEC UpdateReward @Id, @title, @description", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = reward.ID;
                command.Parameters.Add("title", SqlDbType.NVarChar).Value = reward.Title;
                command.Parameters.Add("description", SqlDbType.NVarChar).Value = reward.Description;

                command.ExecuteNonQuery();
            }
        }
        public void Delete(Counter counter)
        {
            using (var connection = new SqlConnection(_connectionString))
            //using (var command = new SqlCommand($"INSERT INTO dbo.Rewards VALUES('{reward.Title}', '{reward.Description}')", connection))
            using (var command = new SqlCommand("EXEC DeleteReward @Id", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = reward.ID;

                command.ExecuteNonQuery();
            }
        }

    }
}
