using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class ProductOrderWidget : UserControl
    {
        private Product product;
        private TableOrderMenu menu;
        public ProductOrderWidget(Product product, TableOrderMenu menu)
        {
            InitializeComponent();
            this.product = product;
            this.menu = menu;
            guna2HtmlLabel1.Text = product.Name;
            guna2HtmlLabel4.Text = product.Amount.ToString();
            guna2HtmlLabel5.Text = product.ID.ToString();
            guna2PictureBox1.Load(product.ImageURL);
        }

        private void ProductOrderWidget_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OrderedItemWidget orderWidget = new OrderedItemWidget(product, menu, int.Parse(textBox1.Text));
                menu.getOrderedItemsPanel().Controls.Add(orderWidget);
                menu.orderedProducts.Add(new KeyValuePair<Product, int>(product, int.Parse(textBox1.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter amount of item");
            }
           
            //Order order = new Order(Order.createOrderId(), Form1.loggedEmployee.Id, widget.table.ID, false);

            //order.saveOrder();


        }

        private void ProductOrderWidget_Load_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
