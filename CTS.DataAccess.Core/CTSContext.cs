using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.X.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.DataAccess.Core
{
    public class CTSContext : DbContext
    {
        private IConfiguration _configuration;
        public static string _connectionString;

        public CTSContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public CTSContext(string connName) : base(CreateDatabaseContextOptions(connName))
        {

        }
        public static DbContextOptions<CTSContext> CreateDatabaseContextOptions(string connName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CTSContext>();
            if(connName == "")
            {
                _connectionString = "server=localhost;user=root;password=root;database=ctc_common_database;port=3306";
                //optionsBuilder.UseMySQL("server=localhost;user=root;password=root;database=ctc_common_database;port=3306");
            }
            else
            {
                _connectionString = "server=localhost;user=root;password=root;port=3306;database=" + connName;
                //optionsBuilder.UseMySQL("server=localhost;user=root;password=root;port=3306;database=" + connName);
            }
            return optionsBuilder.Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
    }
}
