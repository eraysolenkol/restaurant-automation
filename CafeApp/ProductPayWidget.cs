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
    public partial class ProductPayWidget : UserControl
    {
        private Product product;
        private int amount;
        public ProductPayWidget(Product product, int amount)
        {
            InitializeComponent();
            this.product = product;
            this.amount = amount;
            guna2HtmlLabel1.Text = amount.ToString();
            guna2HtmlLabel3.Text = product.Name;
            guna2PictureBox2.Load(product.ImageURL);
        }

        private void ProductPayWidget_Load(object sender, EventArgs e)
        {

        }
    }
}
