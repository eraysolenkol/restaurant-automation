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
    public partial class OrderWidget : UserControl
    {
        private Order order;
        public OrderWidget(Order order)
        {
            InitializeComponent();
            this.order = order;
            guna2HtmlLabel1.Text = order.orderId;
            guna2HtmlLabel6.Text = order.tableId.ToString();
            Employee waiter = Employee.getEmployeeById(order.waiterId);
            guna2HtmlLabel8.Text = $"{waiter.Name} {waiter.Surname}";
            guna2HtmlLabel2.Text = order.date.ToString("dd'/'MM'/'yyyy");
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void OrderWidget_Load(object sender, EventArgs e)
        {

        }
    }
}
