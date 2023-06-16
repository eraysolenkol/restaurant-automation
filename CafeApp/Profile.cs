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
    public partial class Profile : UserControl
    {
        private Employee employee;
        public Profile()
        {
            InitializeComponent();
            employee = Form1.loggedEmployee;
            guna2HtmlLabel8.Text = employee.Name;
            guna2HtmlLabel9.Text = employee.Surname;
            guna2HtmlLabel10.Text = employee.PhoneNumber;
            guna2HtmlLabel11.Text = employee.BirthDate.ToString("dd'/'MM'/'yyyy");
            guna2HtmlLabel12.Text = employee.JoinTime.ToString("dd'/'MM'/'yyyy");
            guna2HtmlLabel13.Text = employee.Email;
            guna2HtmlLabel14.Text = employee.Job;
            if (employee.Gender.Equals("M"))
            {
                guna2PictureBox1.Image = Image.FromFile(@"../../../Resources/employee.png");
            }
            else
            {
                guna2PictureBox1.Image = Image.FromFile(@"../../../Resources/employeeF.png");
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
