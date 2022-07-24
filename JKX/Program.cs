using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using BLL;
using DAL;

namespace JKX
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //// To customize application configuration such as set high DPI settings or default font,
            //// see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appConfig.json");

            var config = configurationBuilder.Build();
            var connectionString = config["ConnectionString"];

            var daoService = new ServiceDAO(connectionString);
            var logicService = new ServiceBL(daoService);

            var daoCounter = new CounterDAO(connectionString);
            var logicCounter = new CounterBL(daoCounter);

            var daoRate = new RateDAO(connectionString);
            var logicRate = new RateBL(daoRate);

            var daoReading = new ReadingDAO(connectionString);
            var logicReading = new ReadingBL(daoReading);


            Application.Run(new Form1(logicCounter, logicRate, logicReading, logicService));

        }
    }
}