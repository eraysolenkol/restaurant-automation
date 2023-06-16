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
    public partial class OrderedItemWidget : UserControl
    {
        public Product product;
        private TableOrderMenu menu;

        public OrderedItemWidget(Product product, TableOrderMenu menu, int amount)
        {
            InitializeComponent();
            this.product = product;
            this.menu = menu;
            guna2HtmlLabel3.Text = product.Name;
            guna2HtmlLabel8.Text = amount.ToString();
            guna2HtmlLabel9.Text = (product.PriceUSD * amount).ToString();
            guna2PictureBox2.Load(product.ImageURL);
        }

        public int getAmount()
        {
            return int.Parse(guna2HtmlLabel8.Text);
        }

        private void OrderedItemWidget_Load(object sender, EventArgs e)
        {

        }

        private void ProductOrderWidget_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

            ProductOrderWidget orderWidget = new ProductOrderWidget(product, menu);
            menu.getOrderedItemsPanel().Controls.Add(orderWidget);

        }

        private void ProductOrderWidget_Load_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            menu.orderedProducts.Remove(new KeyValuePair<Product, int>(product, getAmount()));
            Dispose();
        }
    }
}
