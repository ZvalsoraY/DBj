using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL
{
    public class CounterDAO
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
                    var reward = new Reward
                    (
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.IsDBNull(2) ? null : reader.GetString(2)
                    );
                    rewards.Add(reward);
                }
            }
            return counters;
        }
    }
}
