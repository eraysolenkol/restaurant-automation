using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    public class Employee
    {
        private int id;
        private string name;
        private string surname;
        private string phoneNumber;
        private DateTime birthDate;
        private DateTime joinTime;
        private string job;
        private string email;
        private string gender;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }
        public DateTime JoinTime { get { return joinTime; } set { joinTime = value; } }
        public string Job { get { return job; } set { job = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Gender { get { return gender; } set { gender = value; } }

        private static DatabaseHelper databaseHelper = new DatabaseHelper();
        private static MySqlConnection connection;

        public Employee() { }

        public Employee(int id, string name, string surname, string phoneNumber, DateTime birthDate, DateTime joinTime, string job, string email, string gender)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.birthDate = birthDate;
            this.joinTime = joinTime;
            this.job = job;
            this.email = email;
            this.gender = gender;
        }

        public Employee(string name, string surname, string phoneNumber, DateTime birthDate, DateTime joinTime, string job, string email, string gender)
        {
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
            this.birthDate = birthDate;
            this.joinTime = joinTime;
            this.job = job;
            this.email = email;
            this.gender = gender;
        }


        public static void deleteEmployeeByEmail(string email)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM employee WHERE email = @email";
            cmd.Parameters.AddWithValue("@email", email);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void saveEmployee(Employee employee)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO employee(name,surname,phoneNumber,birthDate,joinDate,email,job, gender) VALUES (@name,@surname,@phoneNumber,@birthDate,@joinDate,@email,@job,@gender)";
            cmd.Parameters.AddWithValue("@name", employee.name);
            cmd.Parameters.AddWithValue("@surname", employee.surname);
            cmd.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
            cmd.Parameters.AddWithValue("@birthDate", employee.birthDate.ToString("dd'/'MM'/'yyyy"));
            cmd.Parameters.AddWithValue("@joinDate", employee.joinTime.ToString("dd'/'MM'/'yyyy"));
            cmd.Parameters.AddWithValue("@email", employee.email);
            cmd.Parameters.AddWithValue("@job", employee.job);
            cmd.Parameters.AddWithValue("@gender", employee.gender);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static Employee getEmployeeByEmail(string email)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from employee WHERE email = @email";
            cmd.Parameters.AddWithValue("@email", email);

            MySqlDataReader reader = cmd.ExecuteReader();
            Employee emp = null;

            while (reader.Read())
            {
                emp = new Employee(reader.GetInt32("id"), reader.GetString("name"), reader.GetString("surname"),
                    reader.GetString("phoneNumber"), DateTime.ParseExact(reader.GetString("birthDate"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(reader.GetString("joinDate"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    reader.GetString("job"), reader.GetString("email"), reader.GetString("gender"));
            }
            connection.Close();
            return emp;

        }

        public static Employee getEmployeeById(int id)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from employee WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = cmd.ExecuteReader();
            Employee emp = null;

            while (reader.Read())
            {
                emp = new Employee(reader.GetInt32("id"), reader.GetString("name"), reader.GetString("surname"),
                    reader.GetString("phoneNumber"), DateTime.ParseExact(reader.GetString("birthDate"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(reader.GetString("joinDate"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    reader.GetString("job"), reader.GetString("email"), reader.GetString("gender"));
            }
            connection.Close();
            return emp;

        }

        public static List<Employee> getEmployees()
        {
            List<Employee> employees = new List<Employee>();
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * from employee";

            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                employees.Add(new Employee(reader.GetInt32("id"), reader.GetString("name"), reader.GetString("surname"),
                    reader.GetString("phoneNumber"), DateTime.ParseExact(reader.GetString("birthDate"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(reader.GetString("joinDate"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    reader.GetString("job"), reader.GetString("email"), reader.GetString("gender")));
            }
            connection.Close();
            return employees;

        }

        public static void updateEmployee(Employee employee)
        {
            connection = databaseHelper.getConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE employee SET name = @name, surname = @surname, phoneNumber = @phoneNumber, birthDate = @birthDate, joinDate = @joinDate, job = @job, email = @email, gender = @gender WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", employee.id);
            cmd.Parameters.AddWithValue("@name", employee.name);
            cmd.Parameters.AddWithValue("@surname", employee.surname);
            cmd.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
            cmd.Parameters.AddWithValue("@birthDate", employee.birthDate.ToString("dd'/'MM'/'yyyy"));
            cmd.Parameters.AddWithValue("@joinDate", employee.joinTime.ToString("dd'/'MM'/'yyyy"));
            cmd.Parameters.AddWithValue("@email", employee.email);
            cmd.Parameters.AddWithValue("@job", employee.job);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }
}