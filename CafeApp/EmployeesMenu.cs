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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CafeApp
{
    public partial class EmployeesMenu : UserControl
    {
        List<Employee> employees;
        public EmployeesMenu()
        {
            InitializeComponent();
            employees = Employee.getEmployees();
        }

        private void EmployeesMenu_Load(object sender, EventArgs e)
        {
            
            foreach (Employee employee in employees)
            {
                flowLayoutPanel1.Controls.Add(new EmployeeWidget(employee,this));
            }
        }

        public void updateAll()
        {
            flowLayoutPanel1.Controls.Clear();
            employees = Employee.getEmployees();

            foreach (Employee employee in employees)
            {
                flowLayoutPanel1.Controls.Add(new EmployeeWidget(employee,this));
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            updateAll();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            employees = Employee.getEmployees();

            foreach (Employee employee in employees)
            {
                if (employee.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    EmployeeWidget widget = new EmployeeWidget(employee,this);
                    flowLayoutPanel1.Controls.Add(widget);
                }
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            UpdateEmployeeForm addForm = new UpdateEmployeeForm(new Employee(), this);
            addForm.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
