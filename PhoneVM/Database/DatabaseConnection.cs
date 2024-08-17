using MySql.Data.MySqlClient;
using System;

namespace PhoneVM.Database
{
    internal class DatabaseConnection
    {
        private readonly string connectionString;

        public DatabaseConnection()
        {
            string server = "schoolhelp.co.za";
            string database = "EvolveVirtualPhone";
            string username = "Evolve";
            string password = "Evolve_01";
            connectionString = $"Server={server};Database={database};User ID={username};Password={password};Port=3306;";
        }

        public MySqlConnection CreateNewConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
