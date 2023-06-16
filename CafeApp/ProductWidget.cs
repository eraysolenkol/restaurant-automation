using Guna.UI2.WinForms;
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
    public partial class ProductWidget : UserControl
    {
        public Product product;
        

        public ProductWidget(Product product)
        {
            InitializeComponent();
            this.product = product;
            guna2PictureBox1.Load(product.ImageURL);
            guna2HtmlLabel1.Text = product.Name;
            guna2HtmlLabel2.Text = $"${product.PriceUSD}";
            guna2HtmlLabel3.Text = product.Description;
            guna2HtmlLabel5.Text = product.ID.ToString();
        }


        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ProductWidget_Load(object sender, EventArgs e)
        {



        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            UpdateItemWidget productWidget = new UpdateItemWidget(product);
            productWidget.Show();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??","Confirm Delete!!",MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Product.deleteProductById(product.ID);
                MessageBox.Show("Successfully deleted");
                this.Parent.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show("Cancelled.");
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
