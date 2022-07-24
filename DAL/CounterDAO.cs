using System;
using System.Collections.Generic;
using System.Data;
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
            var counters = new List<Counter>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT [Id], [Name], [ServiceId], [SerialNumber], [Capacity], [DecimalCapacity], [InitialValue], [CreateData] FROM dbo.Counters", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var counter = new Counter
                    (
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3),
                        reader.GetInt32(4),
                        reader.GetInt32(5),
                        reader.GetDouble(6),
                        reader.GetDateTime(7)
                    );
                    counters.Add(counter);
                }
            }
            return counters;
        }
        public void Add(Counter counter)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand($"INSERT INTO dbo.Counters VALUES (  @name, @serviceId, @serialNumber, @capacity, @decimalCapacity, @initialValue, @createData)", connection))
            {
                connection.Open();

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = counter.Name;
                command.Parameters.Add("serviceId", SqlDbType.Int).Value = counter.ServiceId;
                command.Parameters.Add("serialNumber", SqlDbType.Int).Value = counter.SerialNumber;
                command.Parameters.Add("capacity", SqlDbType.Int).Value = counter.Capacity;
                command.Parameters.Add("decimalCapacity", SqlDbType.Int).Value = counter.DecimalCapacity;
                command.Parameters.Add("initialValue", SqlDbType.Float).Value = counter.InitialValue;
                command.Parameters.Add("createData", SqlDbType.Date).Value = counter.CreateData;

                command.ExecuteNonQuery();
            }
        }
        public void Edit(Counter counter)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC UpdateCounter @Id, @name, @serviceId, @serialNumber, @capacity, @decimalCapacity, @initialValue, @createData", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = counter.Id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = counter.Name;
                command.Parameters.Add("serviceId", SqlDbType.Int).Value = counter.ServiceId;
                command.Parameters.Add("serialNumber", SqlDbType.Int).Value = counter.SerialNumber;
                command.Parameters.Add("capacity", SqlDbType.Int).Value = counter.Capacity;
                command.Parameters.Add("decimalCapacity", SqlDbType.Int).Value = counter.DecimalCapacity;
                command.Parameters.Add("initialValue", SqlDbType.Int).Value = counter.InitialValue;
                command.Parameters.Add("createData", SqlDbType.Date).Value = counter.CreateData;

                command.ExecuteNonQuery();
            }
        }
        public void Delete(Counter counter)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC DeleteCounter @Id", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = counter.Id;

                command.ExecuteNonQuery();
            }
        }
    }
}
