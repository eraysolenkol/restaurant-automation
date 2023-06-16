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
    public partial class ProductPrepareWidget : UserControl
    {
        private OrderDetails orderDetails;
        public ProductPrepareWidget(Product product, OrderDetails orderDetails)
        {
            InitializeComponent();
            this.orderDetails = orderDetails;
            guna2PictureBox1.Load(product.ImageURL);
            if (orderDetails.IsReady)
            {
                guna2PictureBox2.FillColor = Color.Chartreuse;
            }
            else
            {
                guna2PictureBox2.FillColor = Color.Red;
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ProductPrepareWidget_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (orderDetails.IsReady)
            {
                MessageBox.Show("Its already prepared");
            }
            else
            {
                OrderDetails.orderIsReady(orderDetails);
                orderDetails.IsReady = true;
                MessageBox.Show("Its prepared!");
                guna2PictureBox2.FillColor = Color.Chartreuse;
            }
            
        }
    }
}
