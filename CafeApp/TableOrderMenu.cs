using MySqlX.XDevAPI.Relational;
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

namespace CafeApp
{
    public partial class TableOrderMenu : Form
    {
        public TableWidget widget;
        private List<Product> products;
        public List<KeyValuePair<Product, int>> orderedProducts = new List<KeyValuePair<Product, int>>();

        public TableOrderMenu(TableWidget widget)
        {
            InitializeComponent();
            this.widget = widget;
            products = Product.getProducts();

            foreach (Product product in products)
            {
                ProductOrderWidget orderWidget = new ProductOrderWidget(product, this);
                flowLayoutPanel1.Controls.Add(orderWidget);
            }
        }

        public List<KeyValuePair<Product, int>> getOrderedProducts()
        {
            List<KeyValuePair<Product, int>> orderedProducts = new List<KeyValuePair<Product, int>>();
            for (int i = 0; i < flowLayoutPanel2.Controls.Count; i++)
            {
                if (flowLayoutPanel2.Controls[i].GetType() == typeof(OrderedItemWidget))
                {
                    OrderedItemWidget orderedItemWidget = (OrderedItemWidget)flowLayoutPanel2.Controls[i];
                    orderedProducts.Add(new KeyValuePair<Product, int>(orderedItemWidget.product, orderedItemWidget.getAmount()));
                }
            }
            return orderedProducts;
        }

        public FlowLayoutPanel getOrderedItemsPanel()
        {
            return flowLayoutPanel2;
        }

        private void TableOrderMenu_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Product product in products)
            {
                if (product.Name.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    ProductOrderWidget orderWidget = new ProductOrderWidget(product, this);
                    flowLayoutPanel1.Controls.Add(orderWidget);
                }
            }
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            foreach (KeyValuePair<Product, int> orderedProduct in orderedProducts)
            {
                if (orderedProduct.Key.Name.IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    OrderedItemWidget orderWidget = new OrderedItemWidget(orderedProduct.Key, this, orderedProduct.Value);
                    flowLayoutPanel2.Controls.Add(orderWidget);
                }
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            products = Product.getProducts();

            foreach (Product product in products)
            {
                ProductOrderWidget orderWidget = new ProductOrderWidget(product, this);
                flowLayoutPanel1.Controls.Add(orderWidget);
            }
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            foreach (KeyValuePair<Product, int> orderedProduct in orderedProducts)
            {

                OrderedItemWidget orderWidget = new OrderedItemWidget(orderedProduct.Key, this, orderedProduct.Value);
                flowLayoutPanel2.Controls.Add(orderWidget);
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            products = Product.getProducts();

            foreach (Product product in products)
            {
                if (product.Type.Equals("Food"))
                {
                    ProductOrderWidget orderWidget = new ProductOrderWidget(product, this);
                    flowLayoutPanel1.Controls.Add(orderWidget);
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
                    ProductOrderWidget orderWidget = new ProductOrderWidget(product, this);
                    flowLayoutPanel1.Controls.Add(orderWidget);
                }
            }
        }

        private void guna2ImageButton7_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            foreach (KeyValuePair<Product, int> orderedProduct in orderedProducts)
            {
                if (orderedProduct.Key.Type.Equals("Food"))
                {
                    OrderedItemWidget orderWidget = new OrderedItemWidget(orderedProduct.Key, this, orderedProduct.Value);
                    flowLayoutPanel2.Controls.Add(orderWidget);
                }
            }
        }

        private void guna2ImageButton8_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            foreach (KeyValuePair<Product, int> orderedProduct in orderedProducts)
            {
                if (orderedProduct.Key.Type.Equals("Beverage"))
                {
                    OrderedItemWidget orderWidget = new OrderedItemWidget(orderedProduct.Key, this, orderedProduct.Value);
                    flowLayoutPanel2.Controls.Add(orderWidget);
                }
            }
        }

        private void guna2ImageButton9_Click(object sender, EventArgs e)
        {
            // unik id olusturuyo

            string orderId = Order.createOrderId();
            // unik siparis
            Order order = new Order(orderId, Form1.loggedEmployee.Id, widget.table.ID, 0, guna2DateTimePicker1.Value);
            //siparisi database e at
            order.saveOrder();
            // siparisteki her productı database at
            foreach (KeyValuePair<Product, int> orderedProduct in orderedProducts)
            {
                // listedeki her eleman icin 
                OrderDetails orderDetails = new OrderDetails(orderId, orderedProduct.Key.ID, orderedProduct.Value, false);
                orderDetails.saveOrderDetails();
            }
            widget.table.setTable(false);
            widget.menu.updateTables();
            MessageBox.Show("Order has been taken!");
            widget.table.CurrentPayment = (int)Order.getCurrentPaymentByTableId(widget.table.ID);
            widget.table.updateCurrentPayment(widget.table.CurrentPayment);
            Close();
        }
    }
}
