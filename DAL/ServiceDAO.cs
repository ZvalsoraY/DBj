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
    public class ServiceDAO : IServiceDAO
    {
        private readonly string _connectionString;
        public ServiceDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Service> GetAll()
        {
            var services = new List<Service>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT [Id], [Name] FROM dbo.Services", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var service = new Service
                    (
                        reader.GetInt32(0),
                        reader.GetString(1)
                    );
                    services.Add(service);
                }
            }
            return services;
        }
        public void Add(Service service)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand($"INSERT INTO dbo.Services VALUES (@name)", connection))
            {
                connection.Open();

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = service.Name;

                command.ExecuteNonQuery();
            }
        }
        public void Edit(Service service)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC UpdateService @Id, @name", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = service.Id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = service.Name;
                
                command.ExecuteNonQuery();
            }
        }
        public void Delete(Service service)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC DeleteService @Id", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = service.Id;

                command.ExecuteNonQuery();
            }
        }

        Service IServiceDAO.GetServiceById(int id)
        {
            var service = new Service();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC GetServiceById @Id", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", System.Data.SqlDbType.Int).Value = id;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    service.Id = reader.GetInt32(0);
                    service.Name = reader.GetString(1);
                }
                return service;
            }
        }
    }
}
