using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace TechShop.Utility
{
    internal static class DbConnUtil
    {
        private static IConfiguration _iconfiguration;

        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory()) // sets the base path where the configuration file is located
                         .AddJsonFile("appsettings.json"); // configuration should include the configuration file named as appsettings.json

            _iconfiguration = builder.Build(); // build creates an IConfiguration object which has data from the Appsettings file
        }

        public static string GetConnString()
        {
            // Attempt to retrieve the connection string
            string connectionString = _iconfiguration.GetConnectionString("LocalConnectionString");

            if (string.IsNullOrEmpty(connectionString))
            {
                // Handle the case where the connection string is missing
                throw new InvalidOperationException("Connection string 'LocalConnectionString' is not found in the configuration file.");
            }

            return connectionString;
        }
    }
}

