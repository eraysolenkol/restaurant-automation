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
    public partial class PrepareWidget : Form
    {
        private Table table;
        private List<Order> orders; 
        private List<OrderDetails> orderDetails;
        public PrepareWidget(Table table)
        {
            InitializeComponent();
            this.table = table;
            orders = Order.GetOrdersByTableId(table.ID);
            foreach(Order order in orders)
            {
                orderDetails = OrderDetails.GetOrderDetailsByOrderId(order.orderId);
                foreach (OrderDetails orderDetail in orderDetails)
                {
                    ProductPrepareWidget widget = new ProductPrepareWidget(Product.getProductById(orderDetail.ProductId), orderDetail);
                    flowLayoutPanel1.Controls.Add(widget);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrepareWidget_Load(object sender, EventArgs e)
        {

        }
    }
}
