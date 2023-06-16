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
    public partial class TableWidget : UserControl
    {
        public Table table;
        public TablesMenu menu;
        public double currentPayment;

        public TableWidget(Table table, TablesMenu menu)
        {
            this.table = table;
            this.menu = menu;
            table.CurrentPayment = (int)Order.getCurrentPaymentByTableId(table.ID);

            InitializeComponent();
            if (table.IsEmpty)
                guna2PictureBox2.FillColor = Color.Chartreuse;
            else
                guna2PictureBox2.FillColor = Color.Red;

            guna2HtmlLabel1.Text = table.ID.ToString();
            guna2HtmlLabel5.Text = "$" + table.CurrentPayment.ToString();

        }

        private void TableWidget_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            TableOrderMenu menu = new TableOrderMenu(this);
            menu.Show();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (table.IsEmpty)
            {
                MessageBox.Show("Table is empty.");
                return;
            }
            if (Form1.loggedEmployee.Job.Equals("Cashier") || Form1.isAdmin)
            {
                PayMenu menu = new PayMenu(table);
                menu.Show();
            }
            else
            {
                MessageBox.Show("You need to be admin or cashier for this page.");
            }

        }
    }
}
