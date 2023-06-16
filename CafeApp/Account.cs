using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CafeApp
{
    internal class Account
    {
        private int employeeId;
        private string email;
        private string hashedPassword;
        private string salt;
        private int isAdmin;

        private static DatabaseHelper databaseHelper = new DatabaseHelper();
        private static MySqlConnection connection;

        public Account(int employeeId, string email, string hashedPassword, string salt, int isAdmin)
        {
            this.employeeId = employeeId;
            this.email = email;
            this.hashedPassword = hashedPassword;
            this.salt = salt;
            this.isAdmin = isAdmin;
        }

        public Account(string email, string hashedPassword, string salt, int isAdmin)
        {
            this.email = email;
            this.hashedPassword = hashedPassword;
            this.salt = salt;
            this.isAdmin = isAdmin;
        }

        public static Account createAccount(string email, string password, int isAdmin)
        {
            string salt = Encoding.Latin1.GetString(RNGCryptoServiceProvider.GetBytes(16));
            string hashedPassword = hashPassword(password, salt);
            return new Account(email, hashedPassword, salt, isAdmin);
        }

        private static string hashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var secretBytes = Encoding.UTF8.GetBytes(password + salt);
            var secretHash = sha256.ComputeHash(secretBytes);
            return Convert.ToHexString(secretHash);
        }


        public static void saveAccount(Account account)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO accounts(email, hashedPassword, salt, isAdmin) VALUES(@email, @hashedPassword, @salt, @isAdmin)";
            cmd.Parameters.AddWithValue("@email", account.email);
            cmd.Parameters.AddWithValue("@hashedPassword", account.hashedPassword);
            cmd.Parameters.AddWithValue("@salt", account.salt);
            cmd.Parameters.AddWithValue("@isAdmin", account.isAdmin);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

  

        public static bool getIsAdminByEmail(string email)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from accounts WHERE email = @email";
            cmd.Parameters.AddWithValue("@email", email);
            MySqlDataReader reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {
                if (reader.GetInt32("isAdmin") == 1) return true;
            }
            return false;
            connection.Close();
        }

        public static bool isCorrectLogin(string email, string password)
        {
            
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from accounts WHERE email = '" + email + "'";

            MySqlDataReader reader = cmd.ExecuteReader();
            Account account = null;

            while (reader.Read())
            {
                account = new Account(reader.GetString("email"), reader.GetString("hashedPassword"),
                                        reader.GetString("salt"), reader.GetInt32("isAdmin"));
            }
            if (account == null)
            {
                return false;
            }
            connection.Close();
            string hashedPassword = hashPassword(password, account.salt);
            if (hashedPassword.Equals(account.hashedPassword))
            {
                return true;
            }
            return false;
        }


    }
}
