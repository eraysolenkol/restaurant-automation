﻿using System;
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
    public partial class LogMenu : UserControl
    {
        List<Order> paidOrders = Order.GetPaidOrders();
        public LogMenu()
        {
            InitializeComponent();
            loadOrders();
        }

        private void LogMenu_Load(object sender, EventArgs e)
        {

        }

        private void loadOrders()
        {
            paidOrders = Order.GetPaidOrders();
            flowLayoutPanel1.Controls.Clear();
            foreach (Order order in paidOrders)
            {
                flowLayoutPanel1.Controls.Add(new OrderWidget(order));
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            loadOrders();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Order order in paidOrders)
            {
                TimeSpan ts = DateTime.Now.Subtract(order.date);
                int NumberOfDays = (int)ts.TotalDays;
                if (NumberOfDays <= 1)
                {
                    flowLayoutPanel1.Controls.Add(new OrderWidget(order));
                }   
            }
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Order order in paidOrders)
            {
                TimeSpan ts = DateTime.Now.Subtract(order.date);
                int NumberOfDays = (int)ts.TotalDays;
                if (NumberOfDays <= 7)
                {
                    flowLayoutPanel1.Controls.Add(new OrderWidget(order));
                }
            }
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Order order in paidOrders)
            {
                TimeSpan ts = DateTime.Now.Subtract(order.date);
                int NumberOfDays = (int)ts.TotalDays;
                if (NumberOfDays <= 30)
                {
                    flowLayoutPanel1.Controls.Add(new OrderWidget(order));
                }
            }
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Order order in paidOrders)
            {
                if (order.orderId.IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    flowLayoutPanel1.Controls.Add(new OrderWidget(order));
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
