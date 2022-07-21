using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;
using Interfaces;
using System.Data;

namespace DAL
{
    public class ReadingDAO : IReadingDAO
    {
        private readonly string _connectionString;
        public ReadingDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Reading> GetAll()
        {
            var readings = new List<Reading>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT [Id], [ServiceId], [CurValue], [TransDate] FROM dbo.Readings", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var reading = new Reading
                    (
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetFloat(2),
                        reader.GetDateTime(3)
                    );
                    readings.Add(reading);
                }
            }
            return readings;
        }
        public void Add(Reading reading)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand($"INSERT INTO dbo.Readings VALUES ( @serviceId, @curValue, @transDate)", connection))
            {
                connection.Open();

                command.Parameters.Add("serviceId", SqlDbType.Int).Value = reading.ServiceId;
                command.Parameters.Add("curValue", SqlDbType.Char).Value = reading.CurValue;
                command.Parameters.Add("transDate", SqlDbType.DateTime).Value = reading.TransDate;

                command.ExecuteNonQuery();
            }
        }
        public void Edit(Reading reading)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC UpdateReading @Id, @serviceId, @curValue, @transDate", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = reading.Id;
                command.Parameters.Add("serviceId", SqlDbType.Int).Value = reading.ServiceId;
                command.Parameters.Add("curValue", SqlDbType.Char).Value = reading.CurValue;
                command.Parameters.Add("transDate", SqlDbType.DateTime).Value = reading.TransDate;

                command.ExecuteNonQuery();
            }
        }
        public void Delete(Reading reading)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC DeleteReading @Id", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = reading.Id;

                command.ExecuteNonQuery();
            }
        }
    }
}
