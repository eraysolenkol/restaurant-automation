using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class Login : Form
    {
        private Form1 Form1;
        public Login()
        {
            Form1 = new Form1();
            InitializeComponent();
            guna2PictureBox1.Image = Image.FromFile(@"../../../Resources/cafe_photo.jfif");
            //Random random = new Random();
            
            //Account.saveAccount(Account.createAccount("solenkoleray@gmail.com", "eses", 1));
            //Employee.saveEmployee(new Employee("Faruk", "Siner", "0505" + random.Next(1000000, 9999999).ToString(), new DateTime(2003, 7, 30), new DateTime(2022, 5, 10), "Waiter", "faruksiner@gmail.com","M"));
            //Employee.saveEmployee(new Employee("Rümeysa", "Yaşar", "0505" + random.Next(1000000, 9999999).ToString(), new DateTime(2002, 3, 10), new DateTime(2022, 5, 12), "Chef", "rumeysayasar@gmail.com","F"));
            //Employee.saveEmployee(new Employee("Şevval", "Yıldırım", "0505" + random.Next(1000000, 9999999).ToString(), new DateTime(2002,10, 15), new DateTime(2022, 2, 13), "Cashier", "sevvalyildirim@gmail.com","F"));
            //Employee.saveEmployee(new Employee("Altay", "Ergin", "0505" + random.Next(1000000, 9999999).ToString(), new DateTime(2001, 3, 5), new DateTime(2022, 1, 20), "Parking Attendant", "altayergin@gmail.com", "M"));
            //Employee.saveEmployee(new Employee("Uygar", "Akat", "0505" + random.Next(1000000, 9999999).ToString(), new DateTime(2003, 11, 17), new DateTime(2022, 7, 24), "Security Guard", "uygarakat55@gmail.com", "M" ));
            //Employee.saveEmployee(new Employee("Mustafa", "Yalçın", "0505" + random.Next(1000000, 9999999).ToString(), new DateTime(2003, 7, 10), new DateTime(2022, 9, 1), "Developer", "mustafayalcin@gmail.com", "M")); 

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;
            if (Account.isCorrectLogin(email, password))
            {
                MessageBox.Show("WELCOME!");
                Form1.loggedEmployee = Employee.getEmployeeByEmail(email);
                Hide();
                Form1.Show();
            }
            else
            {
                MessageBox.Show("INVALID CRENDENTIALS");
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
