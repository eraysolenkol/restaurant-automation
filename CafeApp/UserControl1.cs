using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class UserControl1 : UserControl
    {
        public static Menu Menu;
        private bool IsImageUrl(string URL)
        {
            var req = (HttpWebRequest)HttpWebRequest.Create(URL);
            req.Method = "HEAD";
            try
            {
                var resp = req.GetResponse();
                return resp.ContentType.ToLower(CultureInfo.InvariantCulture)
                               .StartsWith("image/");
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static bool ValidHttpURL(string URL)
        {
            Uri uriResult;
            return Uri.TryCreate(URL, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        




        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Uri uriResult;
            bool result = ValidHttpURL(textBox4.Text);
            if (result == true)
            {
                if (IsImageUrl(textBox4.Text))
                {
                    guna2PictureBox1.Load(textBox4.Text);
                }
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            string text = guna2GroupBox1.Controls.OfType<Guna.UI2.WinForms.Guna2RadioButton>().FirstOrDefault(r => r.Checked).Name;
            string type = (text == "guna2RadioButton1") ? "Food" : "Beverage";
            Product product = new Product(textBox1.Text, double.Parse(textBox3.Text), textBox2.Text, 0, type, textBox4.Text);
            Product.addProduct(product);
            MessageBox.Show("Succesfully added!");
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
