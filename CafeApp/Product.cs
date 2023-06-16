using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeApp;
using MySql.Data.MySqlClient;

namespace CafeApp
{
    public class Product
    {
        private int id;
        private string name;
        private double priceUSD;
        private string description;
        private int amount;
        private string type;
        private string imageURL;

        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public double PriceUSD { get { return priceUSD; } }
        public string Description { get { return description; } }
        public int Amount { get { return amount; } }
        public string Type { get { return type; } }
        public string ImageURL { get { return imageURL; } }

        private static DatabaseHelper databaseHelper = new DatabaseHelper();
        private static MySqlConnection connection;

        public Product(string name, double priceUSD, string description, int amount, string type, string imageURL)
        {
            this.name = name;
            this.priceUSD = priceUSD;
            this.description = description;
            this.amount = amount;
            this.type = type;
            this.imageURL = imageURL;
        }

        public Product(int id, string name, double priceUSD, string description, int amount, string type, string imageURL)
        {
            this.id = id;
            this.name = name;
            this.priceUSD = priceUSD;
            this.description = description;
            this.amount = amount;
            this.type = type;
            this.imageURL = imageURL;
        }

        public static Product getProductById(int id)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from products WHERE id = '"+ id +"'";

            MySqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read()) 
            {
                return new Product(reader.GetInt32("id"), reader.GetString("name"),
                    reader.GetDouble("priceUSD"), reader.GetString("description"), reader.GetInt32("amount"),
                    reader.GetString("type"), reader.GetString("imageURL"));
            }
            connection.Close();
            return null;

        }

        public static double getPriceById(int id)
        {
            Product product = getProductById(id);
            return product.priceUSD;
        }

        public static Product getProductByName(string name)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from products WHERE name = '" + name + "'";

            MySqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                return new Product(reader.GetInt32("id"), reader.GetString("name"),
                    reader.GetDouble("priceUSD"), reader.GetString("description"), reader.GetInt32("amount"),
                    reader.GetString("type"), reader.GetString("imageURL"));
            }
            connection.Close();
            return null;
        }

        public static void addProduct(Product p)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO products(name, priceUSD, description, amount, type, imageURL) VALUES(@name, @priceUSD, @description, @amount, @type, @imageURL)";
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@priceUSD", p.priceUSD);
            cmd.Parameters.AddWithValue("@description", p.description);
            cmd.Parameters.AddWithValue("@amount", p.amount);
            cmd.Parameters.AddWithValue("@type", p.type);
            cmd.Parameters.AddWithValue("@imageURL", p.imageURL);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void deleteProductById(int id)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM products WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void updateProduct(Product p)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE products SET name = @name, priceUSD = @priceUSD, description = @description, amount = @amount, type = @type, imageURL = @imageURL WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", p.id);
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@priceUSD", p.priceUSD);
            cmd.Parameters.AddWithValue("@description", p.description);
            cmd.Parameters.AddWithValue("@amount", p.amount);
            cmd.Parameters.AddWithValue("@type", p.type);
            cmd.Parameters.AddWithValue("@imageURL", p.imageURL);
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public static List<Product> getProducts()
        {
            List<Product> products = new List<Product>();
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from products";

            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                products.Add(new Product(reader.GetInt32("id"), reader.GetString("name"),
                    reader.GetDouble("priceUSD"), reader.GetString("description"), reader.GetInt32("amount"),
                    reader.GetString("type"), reader.GetString("imageURL")));
            }
            connection.Close();
            return products;
        }


    }

}

