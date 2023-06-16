using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public string OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }
        public bool IsReady { get; set; }

        private static DatabaseHelper databaseHelper = new DatabaseHelper();
        private static MySqlConnection connection;

        public OrderDetails(int orderDetailId, string orderId, int productId, int productAmount, bool isReady)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            ProductId = productId;
            ProductAmount = productAmount;
            IsReady = isReady;
        }

        public OrderDetails(string orderId, int productId, int productAmount, bool isReady)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductAmount = productAmount;
            IsReady = isReady;
        }

        public static List<OrderDetails> GetOrderDetails()
        {
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            connection = databaseHelper.getConnection();
            connection.Open();

            string query = "SELECT * FROM order_details";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderDetailId = reader.GetInt32(0);
                string orderId = reader.GetString(1);
                int productId = reader.GetInt32(2);
                int productAmount = reader.GetInt32(3);
                bool isReady = reader.GetBoolean(4);

                OrderDetails orderDetails = new OrderDetails(orderDetailId, orderId, productId, productAmount, isReady);
                orderDetailsList.Add(orderDetails);
            }
            connection.Close();
            return orderDetailsList;
        }

        public void saveOrderDetails()
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO order_details(orderDetailId, orderId, productId, productAmount, isReady) VALUES (@orderDetailId, @orderId, @productId, @productAmount, @isReady)";
            cmd.Parameters.AddWithValue("@orderId", OrderId);
            cmd.Parameters.AddWithValue("@orderDetailId", OrderDetailId);
            cmd.Parameters.AddWithValue("@productId", ProductId);
            cmd.Parameters.AddWithValue("@productAmount", ProductAmount);
            cmd.Parameters.AddWithValue("@isReady", IsReady ? 1 : 0);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void orderIsReady(OrderDetails orderDetails)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE order_details SET isReady = @isReady WHERE orderDetailId = @orderDetailId";
            cmd.Parameters.AddWithValue("@isReady", 1);
            cmd.Parameters.AddWithValue("@orderDetailId", orderDetails.OrderDetailId);
            cmd.ExecuteNonQuery();

            connection.Close();
        }


        public static List<OrderDetails> GetOrderDetailsByOrderId(string id)
        {
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            connection = databaseHelper.getConnection();
            connection.Open();

            string query = "SELECT * FROM order_details WHERE orderId = @orderId";
            MySqlCommand command = connection.CreateCommand();
            command.Parameters.AddWithValue("@orderId", id);
            command.CommandText = query;

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderDetailId = reader.GetInt32(0);
                string orderId = reader.GetString(1);
                int productId = reader.GetInt32(2);
                int productAmount = reader.GetInt32(3);
                bool isReady = reader.GetBoolean(4);

                OrderDetails orderDetails = new OrderDetails(orderDetailId, orderId, productId, productAmount, isReady);
                orderDetailsList.Add(orderDetails);
            }
            connection.Close();
            return orderDetailsList;
        }


        public static OrderDetails GetOrderDetailsById(int id)
        {
            connection = databaseHelper.getConnection();
            connection.Open();

            string query = "SELECT * FROM order_details WHERE orderDetailId = @orderDetailId";
            MySqlCommand command = connection.CreateCommand();
            command.Parameters.AddWithValue("@orderDetailId", id);
            command.CommandText = query;
            OrderDetails orderDetails = null;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int orderDetailId = reader.GetInt32(0);
                string orderId = reader.GetString(1);
                int productId = reader.GetInt32(2);
                int productAmount = reader.GetInt32(3);
                bool isReady = reader.GetBoolean(4);

                orderDetails = new OrderDetails(orderDetailId, orderId, productId, productAmount, isReady);
            }
            connection.Close();
            return orderDetails;
        }


    }

}
