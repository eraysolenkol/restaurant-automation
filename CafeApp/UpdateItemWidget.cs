using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class UpdateItemWidget : Form
    {
        private Product product;
        


        public UpdateItemWidget(Product product)
        {
            InitializeComponent();
            this.product = product;
            textBox1.Text = product.ID.ToString();
            textBox4.Text = product.Description;
            textBox3.Text = product.PriceUSD.ToString();
            textBox5.Text = product.Amount.ToString();
            textBox6.Text = product.ImageURL;
            textBox2.Text = product.Name;
            guna2PictureBox1.Load(product.ImageURL);
            
        }


        private void UpdateItemWidget_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Product updatedProduct = new Product(int.Parse(textBox1.Text), textBox2.Text,
                double.Parse(textBox3.Text), textBox4.Text, int.Parse(textBox5.Text),
                product.Type, textBox6.Text);
            Product.updateProduct(updatedProduct);
            MessageBox.Show("Updated!");
            
        }




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

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            Uri uriResult;
            bool result = ValidHttpURL(textBox6.Text);
            if (result == true)
            {
                if (IsImageUrl(textBox6.Text))
                {
                    guna2PictureBox1.Load(textBox6.Text);
                }
            }
        }
    }
}
