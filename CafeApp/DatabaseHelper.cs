using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    internal class DatabaseHelper
    {
        private string myConnectionString = "server=127.0.0.1;uid=root;pwd=erayesTR26;database=database";
        public MySqlConnection conn;

        public MySqlConnection getConnection()
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
            }
            catch (MySqlException ex)
            {
                return null;
            }
            return conn;
        }

    }
}
