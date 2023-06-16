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

namespace CafeApp
{
    public partial class KitchenMenu : UserControl
    {
        private List<Table> tables = new List<Table>();

        public KitchenMenu()
        {
            InitializeComponent();
            loadTables();
        }

        private void loadTables()
        {
            flowLayoutPanel1.Controls.Clear();
            tables = Table.GetTables();

            foreach (Table table in tables)
            {
                if (!table.IsEmpty)
                {
                    flowLayoutPanel1.Controls.Add(new TableReadyWidget(table, this));
                }
            }
        }

        private void KitchenMenu_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Table table in tables)
            {
                try
                {
                    if (table.ID == int.Parse(textBox1.Text) && !table.IsEmpty)
                        flowLayoutPanel1.Controls.Add(new TableReadyWidget(table, this));
                }
                catch
                {
                    MessageBox.Show("Please enter an id first");
                    loadTables();
                    break;
                }

            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            loadTables();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
