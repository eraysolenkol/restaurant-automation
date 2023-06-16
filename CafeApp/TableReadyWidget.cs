using Guna.UI2.WinForms;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CafeApp
{
    public partial class TableReadyWidget : UserControl
    {
        public Table table;
        public KitchenMenu menu;
        public List<Order> orders;
        public List<bool> isAllReady = new List<bool>();
        public TableReadyWidget(Table table, KitchenMenu menu)
        {
            this.table = table;
            this.menu = menu;
            InitializeComponent();
            orders = Order.GetOrdersByTableId(table.ID);
            foreach(Order order in orders)
            {
                isAllReady.Add(Order.isAllProductsReady(order.orderId));
            }


            if (isAllReadyTrue(isAllReady))
                guna2PictureBox2.FillColor = Color.Chartreuse;
            else
                guna2PictureBox2.FillColor = Color.Red;

            guna2HtmlLabel1.Text = table.ID.ToString();
        }

        private bool isAllReadyTrue(List<bool> all)
        {
            foreach (bool isReady in all)
            {
                if (isReady == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            PrepareWidget widget = new PrepareWidget(table);
            widget.Show();
        }

        private void TableReadyWidget_Load(object sender, EventArgs e)
        {

        }
    }
}
