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
    public partial class TablesMenu : UserControl
    {
        List<Table> tables = new List<Table>();

        public TablesMenu()
        {
            InitializeComponent();
            tables = Table.GetTables();

            foreach (Table table in tables)
            {
                flowLayoutPanel1.Controls.Add(new TableWidget(table, this));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TablesMenu_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Table table in tables)
            {
                try
                {
                    if (table.ID == int.Parse(textBox1.Text))
                        flowLayoutPanel1.Controls.Add(new TableWidget(table,this));
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
            updateTables();
        }

        public void updateTables()
        {
            tables = Table.GetTables();
            flowLayoutPanel1.Controls.Clear();
            foreach (Table table in tables)
            {
                flowLayoutPanel1.Controls.Add(new TableWidget(table,this));
            }
        }

        private void loadTables()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Table table in tables)
            {
                flowLayoutPanel1.Controls.Add(new TableWidget(table,this));
            }
        }
    }
}
