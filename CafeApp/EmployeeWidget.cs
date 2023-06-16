using Guna.UI2.WinForms;
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
    public partial class EmployeeWidget : UserControl
    {
        public Employee employee;
        public EmployeesMenu menu;
        public EmployeeWidget(Employee employee, EmployeesMenu menu)
        {
            this.menu = menu;
            InitializeComponent();
            this.employee = employee;
            guna2HtmlLabel1.Text = employee.Name;
            guna2HtmlLabel2.Text = employee.Surname;
            guna2HtmlLabel3.Text = employee.PhoneNumber;
            guna2HtmlLabel4.Text = employee.BirthDate.ToString("dd'/'MM'/'yyyy");
            guna2HtmlLabel5.Text = employee.JoinTime.ToString("dd'/'MM'/'yyyy");
            guna2HtmlLabel6.Text = employee.Email;
            guna2HtmlLabel7.Text = employee.Job;
            if (employee.Gender.Equals("M"))
                guna2PictureBox1.Image = Image.FromFile(@"../../../Resources/employee.png");
            else
                guna2PictureBox1.Image = Image.FromFile(@"../../../Resources/employeeF.png");
            
        }



        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            UpdateEmployeeForm employeetWidget = new UpdateEmployeeForm(employee,this.menu);
            employeetWidget.Show();
        }

        private void guna2ImageButton2_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this employee ??", "Confirm Delete!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Employee.deleteEmployeeByEmail(employee.Email);
                MessageBox.Show("Successfully deleted");
                this.Parent.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show("Cancelled.");
            }
        }

        private void EmployeeWidget_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
