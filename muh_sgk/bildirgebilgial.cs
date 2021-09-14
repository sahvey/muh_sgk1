using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using HtmlAgilityPack;
using System.Xml;
using System.Net;
using System.Net.Http;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace muh_sgk
{
    public partial class bildirgebilgial : Form
    {
        public bildirgebilgial()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-89G3BRQ\SQLEXPRESS;Initial Catalog=sgk_ebildirge;Integrated Security=True");

        


        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        
        
        private void bildirgebilgial_Load(object sender, EventArgs e)
        {
            
            verilerigoster("select id,Referans_Gurubu,Firma_Gurubu,Firma_Unvanı,Sgk_kullanici,Sgk_ek,Sgk_isyeri_sifresi,Sgk_sistem_sifresi From Firma_Bilgileri");
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string firma;// = txtfirmaunvan.Text.ToString();
            string gurup;// = txtfirmagurup.Text.ToString();
            string referansi;// = txtreferans.Text.ToString();
            string durum;// = comboBox1.Text.ToString();
            if (txtfirmaunvan.Text != "")
            {
                 firma = "Firma_Unvanı like '%" + txtfirmaunvan.Text.ToString() + "%' or";
            }
            else
            {
                 firma = "";
            }
            if (txtfirmagurup.Text != "")
            {
                gurup = "firmagurup like '%" + txtfirmagurup.Text.ToString() + "%' or";
            }
            else
            {
                gurup = "";
            }
            if (txtreferans.Text != "")
            {
                referansi = "Referans_Gurubu like '%" + txtreferans.Text.ToString() + "%' or";
            }
            else
            {
                referansi = "";
            }
            if (comboBox1.Text != "")
            {
                durum = "Durumu like '%" + comboBox1.Text.ToString() + "%'";
            }
            else
            {
                durum = "";
            }
            verilerigoster("select id, Referans_Gurubu, Firma_Gurubu, Firma_Unvanı, Sgk_kullanici, Sgk_ek, Sgk_isyeri_sifresi, Sgk_sistem_sifresi From Firma_Bilgileri where "+firma+" "+gurup +" "+referansi+" "+durum+"");

        }

        
        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.GetElementById("isyeri_guvenlik").InnerText = txtguvenlik.Text.Trim();
            webBrowser1.Document.GetElementById("btnSubmit").Focus();
            SendKeys.Send("{enter}");
        }


        public void dataGridView1_Click(object sender, EventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string Referans_Gurubu = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string Firma_Gurubu = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string Firma_Unvanı = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string Sgk_kullanici = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string Sgk_ek = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string Sgk_isyeri_sifresi = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string Sgk_sistem_sifresi = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();

            lblkullanici.Text = Sgk_kullanici.Trim();
            lblek.Text = Sgk_ek.Trim();
            lblisyerisifresi.Text = Sgk_isyeri_sifresi.Trim();
            lblsistemsifresi.Text = Sgk_sistem_sifresi.Trim();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender,  EventArgs e)
        {

                      var v2baglan = "https://ebildirge.sgk.gov.tr/EBildirgeV2/login/kullaniciIlkKontrollerGiris.action?username=" + lblkullanici.Text.ToString() + "&isyeri_kod="+lblek.Text.ToString()+"&password=" +lblsistemsifresi.Text.ToString() +"isyeri_sifre="+lblisyerisifresi.Text.ToString()  +"&isyeri_guvenlik=" + txtv2guvenlik.Text.ToString()+"";
                     //var httpclinet = new HttpClient();
                      //var html =  httpclinet.GetStringAsync(v2baglan).ToString();
                       
                     // var htmdoc = new HtmlDocument();
                      // htmdoc.LoadHtml(html);

                       //var firmalistehtml = htmdoc.DocumentNode.Descendants("li")

            ebildirgev2 baglan = new ebildirgev2();
           // baglan.v2baglan ("https://ebildirge.sgk.gov.tr/EBildirgeV2/login/kullaniciIlkKontrollerGiris.action?username=" + lblkullanici.Text.ToString() + "&isyeri_kod=" + lblek.Text.ToString() + "&password=" + lblsistemsifresi.Text.ToString() + "isyeri_sifre=" + lblisyerisifresi.Text.ToString() + "&isyeri_guvenlik=" + txtv2guvenlik.Text.ToString() + "");

            for (int i = 2; i < 4; i++)
            {
                baglan.VeriAl("https://ebildirge.sgk.gov.tr/EBildirgeV2", "//*[@id='contentContainer']/div/table/tbody/tr[1]/td/table/tbody/tr[2]/td[2]/table/tbody/tr[1]/td["+i+"]", listBox1);
            }

            //webBrowser2.Navigate("https://ebildirge.sgk.gov.tr/EBildirgeV2/login/kullaniciIlkKontrollerGiris.action?username=12178849190&isyeri_kod=084&password=32978025&isyeri_sifre=70272627&isyeri_guvenlik=" + txtv2guvenlik.Text.ToString() + "");
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var request = WebRequest.Create("https://ebildirge.sgk.gov.tr/EBildirgeV2/PG");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox2.Image = Bitmap.FromStream(stream);
            }
        }
    }
}
