using Guna.UI2.WinForms;
using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        private bool[] buttons = new bool[7];
        private Guna2Button[] gunaButtons = new Guna2Button[7];
        private UserControl[] userControls = new UserControl[7];
        public static Employee loggedEmployee;
        public static bool isAdmin = false;
        //private Dictionary<Guna2Button,UserControl> dict = new Dictionary<Guna2Button, UserControl>();
        
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = false;
            }
            gunaButtons[0] = guna2Button2;
            gunaButtons[1] = guna2Button3;
            gunaButtons[2] = guna2Button5;
            gunaButtons[3] = guna2Button7;
            gunaButtons[4] = guna2Button8;
            gunaButtons[5] = guna2Button4;
            gunaButtons[6] = guna2Button6;
            userControls[0] = userControl13;
            userControls[1] = menu3;
            userControls[2] = employeeProfile1;
            userControls[3] = employeesMenu1;
            userControls[4] = tablesMenu1;
            userControls[5] = kitchenMenu1;
            userControls[6] = logMenu1;
            for (int i = 0; i < buttons.Length; i++)
            {
                userControls[i].Hide();
            }
        }

        private void loadButtons()
        {
            for (int i = 0; i < buttons.Length; i++)
            {                
                if (buttons[i])
                {
                    userControls[i].Show();
                    gunaButtons[i].FillColor = Color.FromArgb(63, 0, 255);
                }
                else
                {
                    userControls[i].Hide();
                    gunaButtons[i].FillColor = Color.FromArgb(29, 27, 45);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isAdmin = Account.getIsAdminByEmail(loggedEmployee.Email);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("You need to be admin to see this page");
                return;
            }
            buttons[0] = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 0) continue;
                buttons[i] = false;
            }
            loadButtons();
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("You need to be admin to see this page");
                return;
            }
            buttons[1] = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 1) continue;
                buttons[i] = false;
            }
            loadButtons();
        }

        private void menu1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            buttons[2] = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 2) continue;
                buttons[i] = false;
            }
            loadButtons();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Dispose();
            MessageBox.Show("Logged out");
            Login login = new Login();
            login.Show();
        }

        private void userControl13_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("You need to be admin to see this page");
                return;
            }
            buttons[3] = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 3) continue;
                buttons[i] = false;
            }
            loadButtons();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (!(isAdmin || loggedEmployee.Job.Equals("Waiter") || loggedEmployee.Job.Equals("Cashier")))
            {
                MessageBox.Show("You need to be admin or waiter or cashier to see this page");
                return;
            }
            buttons[4] = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 4) continue;
                buttons[i] = false;
            }
            loadButtons();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!(isAdmin || loggedEmployee.Job.Equals("Chef")))
            {
                MessageBox.Show("You need to be admin or Chef to see this page");
                return;
            }
            buttons[5] = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 5) continue;
                buttons[i] = false;
            }
            loadButtons();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("You need to be admin to see this page");
                return;
            }
            buttons[6] = true;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i == 6) continue;
                buttons[i] = false;
            }
            loadButtons();
        }
    }
}
