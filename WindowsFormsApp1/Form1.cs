using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string url =" http://smsc.vianett.no/v3/send.ashx?"+
                        "src="+textBox1.Text+"&"+
                        "dst="+textBox1.Text+" & "+
                       " msg="+System.Web.HttpUtility.UrlEncode(textBox2.Text,System.Text.Encoding.GetEncoding("ISO-8859-1"))+"&" +
                       "username="+System.Web.HttpUtility.UrlEncode(textBox3.Text) +"&"+ 
                       "password="+System.Web.HttpUtility.UrlEncode(textBox4.Text);
                    string result = client.DownloadString(url);
                    if (result.Contains("OK"))
                    {
                        MessageBox.Show("GÖNDERİLDİ", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("HATA", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }
    }
}
