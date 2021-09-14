using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;

namespace muh_sgk
{
    public partial class ebildirgev2 : Form
    {
        public String html;
        public Uri url;

        public object baglantidurumu { get; private set; }

        public ebildirgev2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string v = textBox1.Text.ToString().Trim();
            Uri url = new Uri("https://ebildirge.sgk.gov.tr/EBildirgeV2/login/kullaniciIlkKontrollerGiris.action?username=12178849190&isyeri_kod=084&password=32978025&isyeri_sifre=70272627&isyeri_guvenlik=" + v + "");
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            listBox1.Items.Add(doc.DocumentNode.SelectSingleNode("//*[@id='contentContainer']/div/table/tbody/tr[1]/td/table/tbody/tr[2]/td[2]/table/tbody/tr[1]/td[3]").InnerText);


          //  foreach (HtmlNode item in doc.DocumentNode.SelectSingleNode("//*[@id='contentContainer']/div/table/tbody/tr[1]/td/table/tbody/tr[2]/td[2]/table/tbody/tr[1]/td[3]"))
           // {
                //.DocumentNode.SelectNodes("//*[@id='contentContainer']/div/table/tbody/tr[2]/td/table/tbody/tr[2]/td[2]/div/table[2]/tbody/tr/td/table/tbody/tr[3]/td[2]")
          //      listBox1.Items.Add(item.InnerText);

                ///html/body/div[3]/table/tbody/tr[2]/td/div/div[2]/div/table/tbody/tr[1]/td/table/tbody/tr[2]/td[2]/table
           // }
            //VeriAl("https://www.ebay.com/sch/i.html?_nkw=computer&_sop=12","//*[@id='srp-river-results']/ul/li[2]/div/div[2]/a/h3", listBox1);
            //*[@id="srp-river-results"]/ul/li[1]/div/div[2]/a/h3/span
            //*[@id="srp-river-results"]/ul/li[2]/div/div[2]/a/h3
            //*[@id="srp-river-results"]/ul/li[3]/div/div[2]/a/h3

        }
        public void VeriAl(String Url, String Xpath, ListBox cikansonuc)
        {
            
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {

                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            catch (ArgumentException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);
            }
            catch (WebException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                cikansonuc.Items.Add(doc.DocumentNode.SelectSingleNode(Xpath).InnerText);
                //cikansonuc.Items.Add(doc.DocumentNode.SelectSingleNode(Url).InnerText);
                //   cikansonuc.Items.Add(doc.GetElementbyId("p10").InnerText);
                //cikansonuc.Items.Add(doc.DocumentNode.Descendants("td")["p10"].InnerText);
                //cikansonuc.Items.Add(doc.DocumentNode.SelectSingleNode(Xpath).InnerText);
                //foreach (var item in doc)
                {

                }
                
                
            }
            catch (NullReferenceException)
            {

                if (MessageBox.Show("Hatalı Xpath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }

            }
        }
        public void v2baglan(String Url, ListBox baglantidurumu )
        {
            try
            {
                url = new Uri(Url);
            }
            catch (UriFormatException)
            {

                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            catch (ArgumentException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                html = client.DownloadString(url);
            }
            catch (WebException)
            {
                if (MessageBox.Show("Hatalı Url", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            try
            {
                //baglantidurumu.Items.Add(doc.DocumentNode.SelectSingleNode("//title").InnerText);
               //baglantidurumu.Items.Add(doc.DocumentNode.SelectSingleNode(Url).InnerText);
                baglantidurumu.Items.Add(doc.DocumentNode.GetDataAttribute(Url).Value);
            }
            catch (NullReferenceException)
            {

                if (MessageBox.Show("Hatalı Xpath", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {

                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var request = WebRequest.Create("https://ebildirge.sgk.gov.tr/EBildirgeV2/PG");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
        }
    }
}
