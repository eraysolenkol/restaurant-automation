using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    public class Table
    {
        private int id;
        private bool isEmpty;
        private int currentPayment;

        public int ID { get { return id; } set { id = value; } }
        public bool IsEmpty { get { return isEmpty; } set { isEmpty = value; } }
        public int CurrentPayment { get { return currentPayment; } set { currentPayment = value; } }

        private static DatabaseHelper databaseHelper = new DatabaseHelper();
        private static MySqlConnection connection;

 
        public Table(int id, bool isEmpty, int currentPayment)
        {
            this.id = id;
            this.isEmpty = isEmpty;
            this.currentPayment = currentPayment;
        }

        public Table(bool isEmpty, int currentPayment)
        {
            this.isEmpty = isEmpty;
            this.currentPayment = currentPayment;
        }

        public static List<Table> GetTables()
        {
            List<Table> tables = new List<Table>();
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from tables";

            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                bool empty = (reader.GetInt32("isEmpty") == 1) ? true : false;
                tables.Add(new Table(reader.GetInt32("tableId"), empty,
                    reader.GetInt32("currentPayment")));
            }
            connection.Close();


            return tables;
        }

        public void setTable(bool isEmpty)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE tables SET isEmpty = @isEmpty WHERE tableId = @tableId";
            cmd.Parameters.AddWithValue("@isEmpty", isEmpty ? 1 : 0);
            cmd.Parameters.AddWithValue("@tableId", this.id);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void updateCurrentPayment(int currentPayment)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE tables SET currentPayment = @currentPayment WHERE tableId = @tableId";
            cmd.Parameters.AddWithValue("@currentPayment", currentPayment);
            cmd.Parameters.AddWithValue("@tableId", this.id);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

    }
}
