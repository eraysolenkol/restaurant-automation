using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    public class Order
    {
        public string orderId;
        public int waiterId;
        public int tableId;
        public int isPaid;
        public DateTime date;

        private static DatabaseHelper databaseHelper = new DatabaseHelper();
        private static MySqlConnection connection;

        public Order(string orderId, int waiterId, int tableId, int isPaid, DateTime date)
        {
            this.orderId = orderId;
            this.waiterId = waiterId;
            this.tableId = tableId;
            this.isPaid = isPaid;
            this.date = date;
        }

        public Order(int waiterId, int tableId, int isPaid, DateTime date)
        {
            this.waiterId = waiterId;
            this.tableId = tableId;
            this.isPaid = isPaid;
            this.date = date;
        }

        public static string createOrderId()
        {
            return Guid.NewGuid().ToString();
        }

        public void saveOrder()
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO orders(orderId, waiterId, tableId, isPaid, date) VALUES (@orderId, @waiterId, @tableId, @isPaid, @date)";
            cmd.Parameters.AddWithValue("@orderId", orderId);
            cmd.Parameters.AddWithValue("@waiterId", waiterId);
            cmd.Parameters.AddWithValue("@tableId", tableId);
            cmd.Parameters.AddWithValue("@isPaid", isPaid);
            cmd.Parameters.AddWithValue("@date", date.ToString("dd'/'MM'/'yyyy"));
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static List<Order> GetOrdersByTableId(int tableId)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            List<Order> orders = new List<Order>();

            string query = "SELECT * FROM orders WHERE tableId = @tableId AND isPaid = @isPaid";
            MySqlCommand command = connection.CreateCommand();
            command.Parameters.AddWithValue("@tableId", tableId);
            command.Parameters.AddWithValue("@isPaid", 0);
            command.CommandText = query;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order(reader.GetString("orderId"), reader.GetInt32("waiterId"), 
                    reader.GetInt32("tableId"), reader.GetInt32("isPaid"),
                    DateTime.ParseExact(reader.GetString("date"), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }
            connection.Close();
            return orders;
        }

        public static bool isAllProductsReady(string orderId)
        {
            List<OrderDetails> details = OrderDetails.GetOrderDetailsByOrderId(orderId);
            foreach(OrderDetails detail in details)
            {
                if (detail.IsReady == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static void payOrder(string orderId)
        {
            connection = databaseHelper.getConnection();
            connection.Open();

            string query = "UPDATE orders SET isPaid = @isPaid WHERE orderId = @orderId";
            MySqlCommand command = connection.CreateCommand();
            command.Parameters.AddWithValue("@orderId", orderId);
            command.Parameters.AddWithValue("@isPaid", 1);
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static double getCurrentPaymentByTableId(int tableId)
        {
            int currentPayment = 0;
            connection = databaseHelper.getConnection();
            connection.Open();


            List<Order> orders = Order.GetOrdersByTableId(tableId);
            List<OrderDetails> details;
            foreach (Order order in orders)
            {
                details = OrderDetails.GetOrderDetailsByOrderId(order.orderId);
                foreach (OrderDetails detail in details)
                {
                    currentPayment += (int)Product.getPriceById(detail.ProductId) * detail.ProductAmount;
                }
            }
            connection.Close();
            return currentPayment;
        }

        public static List<Order> GetPaidOrders()
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            List<Order> orders = new List<Order>();

            string query = "SELECT * FROM orders WHERE isPaid = @isPaid";
            MySqlCommand command = connection.CreateCommand();
            command.Parameters.AddWithValue("@isPaid", 1);
            command.CommandText = query;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order(reader.GetString("orderId"), reader.GetInt32("waiterId"),
                    reader.GetInt32("tableId"), reader.GetInt32("isPaid"),
                    DateTime.ParseExact(reader.GetString("date"), "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }
            connection.Close();
            return orders;
        }

    }
}
