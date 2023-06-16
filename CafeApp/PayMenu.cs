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
    public partial class PayMenu : Form
    {
        private Table table;
        private List<Order> orders;
        public PayMenu(Table table)
        {
            InitializeComponent();
            this.table = table;
            orders = Order.GetOrdersByTableId(table.ID);
            foreach(Order order in orders)
            {
                List<OrderDetails> details = OrderDetails.GetOrderDetailsByOrderId(order.orderId);
                foreach(OrderDetails detail in details)
                {
                    flowLayoutPanel1.Controls.Add(new ProductPayWidget(Product.getProductById(detail.ProductId), detail.ProductAmount));
                }
            }
            guna2HtmlLabel1.Text = $"{table.CurrentPayment}$";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void PayMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            foreach (Order order in orders)
            {
                Order.payOrder(order.orderId); 
            }
            table.setTable(true);
            MessageBox.Show("Successfully paid!");
        }
    }
}
