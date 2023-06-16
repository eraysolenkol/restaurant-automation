using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class UpdateEmployeeForm : Form
    {
        private Employee employee;
        public EmployeesMenu menu;
        public UpdateEmployeeForm(Employee employee, EmployeesMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
            this.employee = employee;
            if (employee.Id is not 0)
            {
                textBox1.Text = employee.Id.ToString();
                textBox2.Text = employee.Name;
                textBox3.Text = employee.Surname;
                textBox4.Text = employee.PhoneNumber;
                textBox5.Text = employee.BirthDate.ToString("dd'/'MM'/'yyyy");
                textBox6.Text = employee.JoinTime.ToString("dd'/'MM'/'yyyy");
                textBox7.Text = employee.Email;
                textBox8.Text = employee.Job;
                

                if (employee.Gender.Equals("M"))
                {
                    guna2PictureBox1.Image = Image.FromFile(@"../../../Resources/employee.png");
                    guna2RadioButton1.Checked = true;
                }
                else
                {
                    guna2PictureBox1.Image = Image.FromFile(@"../../../Resources/employeeF.png");
                    guna2RadioButton2.Checked = true;
                }
            }
            
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Dispose();
        }



        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            // update
            string text = guna2GroupBox1.Controls.OfType<Guna2RadioButton>().FirstOrDefault(r => r.Checked).Name;
            string gender = (text == "guna2RadioButton1") ? "M" : "F";
            
            if (employee.Id is 0)
            {
                Employee employee = new Employee(textBox2.Text, textBox3.Text, textBox4.Text, DateTime.ParseExact(textBox5.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(textBox6.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture), textBox8.Text, textBox7.Text, gender);
                Employee.saveEmployee(employee);
                Account.saveAccount(Account.createAccount(employee.Email, "123", 0));
                MessageBox.Show("Created!");
                menu.updateAll();
            } 
            else
            {
                Employee updatedEmployee = new Employee(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, DateTime.ParseExact(textBox5.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(textBox6.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture), textBox8.Text, textBox7.Text, gender);
                Employee.updateEmployee(updatedEmployee);
                MessageBox.Show("Updated!");
                menu.updateAll();
            }

            Dispose();
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UpdateEmployeeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
