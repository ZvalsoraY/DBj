﻿using System;
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
    public class RateDAO : IRateDAO
    {
        private readonly string _connectionString;
        public RateDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Rate> GetAll()
        {
            var rates = new List<Rate>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT [Id], [Name], [ServiceId], [Price], [StartData], [EndData] FROM dbo.Rates", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var rate = new Rate
                    (
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3),
                        reader.GetDateTime(4),
                        reader.GetDateTime(5)
                    );
                    rates.Add(rate);
                }
            }
            return rates;
        }
        public void Add(Rate rate)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand($"INSERT INTO dbo.Rates VALUES (@name, @serviceId, @price, @startData, @endData)", connection))
            {
                connection.Open();

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = rate.Name;
                command.Parameters.Add("serviceId", SqlDbType.Int).Value = rate.ServiceId;
                command.Parameters.Add("price", SqlDbType.Int).Value = rate.Price;
                command.Parameters.Add("startData", SqlDbType.DateTime).Value = rate.StartData;
                command.Parameters.Add("endData", SqlDbType.DateTime).Value = rate.EndData;

                command.ExecuteNonQuery();
            }
        }
        public void Edit(Rate rate)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC UpdateRate @Id, @name, @serviceId, @price, @startData, @endData", connection))
            {//int id, string name, int serviceId, int price, DateTime startData, DateTime endData
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = rate.Id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = rate.Name;
                command.Parameters.Add("serviceId", SqlDbType.Int).Value = rate.ServiceId;
                command.Parameters.Add("price", SqlDbType.Int).Value = rate.Price;
                command.Parameters.Add("startData", SqlDbType.DateTime).Value = rate.StartData;
                command.Parameters.Add("endData", SqlDbType.DateTime).Value = rate.EndData;

                command.ExecuteNonQuery();
            }
        }
        public void Delete(Rate rate)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("EXEC DeleteRate @Id", connection))
            {
                connection.Open();

                command.Parameters.Add("Id", SqlDbType.Int).Value = rate.Id;

                command.ExecuteNonQuery();
            }
        }

        List<Rate> IRateDAO.GetServicesRates(Service service)
        {
            var rates = new List<Rate>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("Exec GetServicesRates @serviceId", connection))
            //using (var command = new SqlCommand("SELECT [Id], [Name], [ServiceId], [Price], [StartData], [EndData] FROM dbo.Rates", connection))

            {
                connection.Open();

                command.Parameters.Add("serviceId", System.Data.SqlDbType.Int).Value = service.Id;

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var rate = new Rate
                    (
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3),
                        reader.GetDateTime(4),
                        reader.GetDateTime(5)
                    );
                    rates.Add(rate); ;
                }
            }

            return rates;
        }
    }
}
