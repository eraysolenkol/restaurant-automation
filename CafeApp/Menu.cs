using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CafeApp
{
    public partial class Menu : UserControl
    {
        List<Product> products;

        public Menu()
        {
            InitializeComponent();
            
            products = Product.getProducts();

            foreach (Product product in products)
            {
                ProductWidget widget = new ProductWidget(product);
                flowLayoutPanel1.Controls.Add(widget);
            }

        }

        public void updateProductsList()
        {
            flowLayoutPanel1.Controls.Clear();
            products = Product.getProducts();

            foreach (Product product in products)
            {
                ProductWidget widget = new ProductWidget(product);
                flowLayoutPanel1.Controls.Add(widget);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void LoadMenu()
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            updateProductsList();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            products = Product.getProducts();

            foreach (Product product in products)
            {
                if (product.Type.Equals("Food"))
                {
                    ProductWidget widget = new ProductWidget(product);
                    flowLayoutPanel1.Controls.Add(widget);
                }
            }
        }
        

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            products = Product.getProducts();

            foreach (Product product in products)
            {
                if (product.Type.Equals("Beverage"))
                {
                    ProductWidget widget = new ProductWidget(product);
                    flowLayoutPanel1.Controls.Add(widget);
                }
            }
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            products = Product.getProducts();

            foreach (Product product in products)
            {
                if (product.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    ProductWidget widget = new ProductWidget(product);
                    flowLayoutPanel1.Controls.Add(widget);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
