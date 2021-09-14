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
namespace muh_sgk
{
    public partial class FirmaKayit : Form
    {
        public FirmaKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-89G3BRQ\SQLEXPRESS;Initial Catalog=sgk_ebildirge;Integrated Security=True");
        
         public void verilerigoster (string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler,baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void FirmaKayit_Load(object sender, EventArgs e)
        {

            verilerigoster("select * from firma_bilgileri");
        }
        
        
        
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            
            
                int id = Convert.ToInt32(lblfirmano.Text);
            


            string kayitno = lblfirmano.Text;
            if (kayitno =="-" )
            {
                baglanti.Open();
                SqlCommand ekle = new SqlCommand("insert into Firma_Bilgileri (Referans_Gurubu,Firma_Gurubu,Firma_Unvanı,Sube,Yetkili,Telefon,Adres,İl,İlce,Vergi_no,Vergi_dairesi,Sgk_isyeri_no,Ticaret_sicil_no,Muhtasar_no,Sgk_kullanici,Sgk_ek,Sgk_isyeri_sifresi,Sgk_sistem_sifresi,Vdk_kullanici,Vdk_parola,Vdk_sifre,Durumu) values ('" + txtreferans.Text + "','" + txtfirmagurup.Text + "','" + txtfirmaunvan.Text + "','" + txtsube.Text + "','" + txtyetkili.Text + "','" + txttelefon.Text.ToString() + "','" + txtadres.Text + "','" + txtil.Text + "','" + txtilce.Text + "','" + txtvergino.Text + "','" + txtvdairesi.Text + "','" + txtsgkisyerino.Text + "','" + txtticsicilno.Text + "','" + txtmuhtno.Text + "','" + txtsgkkullanicino.Text + "','" + txtsgkek.Text + "','" + txtsgkisyerisifresi.Text + "','" + txtsgksistemsifresi.Text + "','" + txtvdkkullanici.Text + "','" + txtvdkparola.Text + "','" + txtvdksifre.Text + "','" + comboBox1.Text + "')", baglanti);

                ekle.ExecuteNonQuery();
                baglanti.Close();
                verilerigoster("select * from Firma_Bilgileri");
            }
            else
            {
                
                int firmaid = Convert.ToInt32(lblfirmano.Text);
                baglanti.Open();
                SqlCommand guncelle = new SqlCommand("Update Firma_Bilgileri set Referans_Gurubu= '" + txtreferans.Text.ToString() + "',Firma_Gurubu= '" + txtfirmagurup.Text.ToString() + "',Firma_Unvanı= '" + txtfirmaunvan.Text.ToString() + "',Sube= '" + txtsube.Text.ToString() + "',Yetkili= '" + txtyetkili.Text.ToString() + "',Telefon= '" + txttelefon.Text.ToString() + "',Adres= '" + txtadres.Text.ToString() + "',İl= '" + txtil.Text.ToString() + "',İlce= '" + txtilce.Text.ToString() + "',Vergi_no= '" + txtvergino.Text.ToString() + "',Vergi_dairesi= '" + txtvdairesi.Text.ToString() + "',Sgk_isyeri_no= '" + txtsgkisyerino.Text.ToString() + "',Ticaret_sicil_no= '" + txtticsicilno.Text.ToString() + "',Muhtasar_no= '" + txtmuhtno.Text.ToString() + "',Sgk_kullanici= '" + txtsgkkullanicino.Text.ToString() + "',Sgk_ek= '" + txtsgkek.Text.ToString() + "',Sgk_isyeri_sifresi= '" + txtsgkisyerisifresi.Text.ToString() + "',Sgk_sistem_sifresi= '" + txtsgksistemsifresi.Text.ToString() + "',Vdk_kullanici= '" + txtvdkkullanici.Text.ToString() + "',Vdk_parola= '" + txtvdkparola.Text.ToString() + "',Vdk_sifre= '" + txtvdksifre.Text.ToString() + "',Durumu= '" + comboBox1.Text.ToString() + "'  where id = " + id + "", baglanti);

                guncelle.ExecuteNonQuery();
                baglanti.Close();
                tabloyutemizle("temizle");
                verilerigoster("select * from Firma_Bilgileri");
            }

            //firma kisa adı Firma_Kısa_Adi,, vergi dairesi adı Vergi_dairesi,
        }

        
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string Referans_Gurubu = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string Firma_Gurubu = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string Firma_Unvanı = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string Firma_Kisa_Adi = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string Sube = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            string Yetkili = dataGridView1.Rows[secilialan].Cells[6].Value.ToString();
            string Telefon = dataGridView1.Rows[secilialan].Cells[7].Value.ToString();
            string Adres = dataGridView1.Rows[secilialan].Cells[8].Value.ToString();
            string İl = dataGridView1.Rows[secilialan].Cells[9].Value.ToString();
            string İlce = dataGridView1.Rows[secilialan].Cells[10].Value.ToString();
            string Vergi_no = dataGridView1.Rows[secilialan].Cells[11].Value.ToString();
            string Vergi_dairesi = dataGridView1.Rows[secilialan].Cells[12].Value.ToString();
            string Sgk_isyeri_no = dataGridView1.Rows[secilialan].Cells[13].Value.ToString();
            string Ticaret_sicil_no = dataGridView1.Rows[secilialan].Cells[14].Value.ToString();
            string Muhtasar_no = dataGridView1.Rows[secilialan].Cells[15].Value.ToString();
            string Sgk_kullanici = dataGridView1.Rows[secilialan].Cells[16].Value.ToString();
            string Sgk_ek = dataGridView1.Rows[secilialan].Cells[17].Value.ToString();
            string Sgk_isyeri_sifresi = dataGridView1.Rows[secilialan].Cells[18].Value.ToString();
            string Sgk_sistem_sifresi = dataGridView1.Rows[secilialan].Cells[19].Value.ToString();
            string Vdk_kullanici = dataGridView1.Rows[secilialan].Cells[20].Value.ToString();
            string Vdk_parola = dataGridView1.Rows[secilialan].Cells[21].Value.ToString();
            string Vdk_sifre = dataGridView1.Rows[secilialan].Cells[22].Value.ToString();
            string Durumu = dataGridView1.Rows[secilialan].Cells[23].Value.ToString();

            lblfirmano.Text = id.Trim();
            txtreferans.Text = Referans_Gurubu.Trim();
            txtfirmagurup.Text = Firma_Gurubu.Trim();
            txtfirmaunvan.Text = Firma_Unvanı.Trim();
            lblkisaad.Text = Firma_Kisa_Adi.Trim();
            txtsube.Text = Sube.Trim();
            txtyetkili.Text = Yetkili.Trim();
            txttelefon.Text = Telefon.Trim();
            txtadres.Text = Adres.Trim();
            txtil.Text = İl.Trim();
            txtilce.Text = İlce.Trim();
            txtvergino.Text = Vergi_no.Trim();
            txtvdairesi.Text = Vergi_dairesi.Trim();
            txtsgkisyerino.Text = Sgk_isyeri_no.Trim();
            txtticsicilno.Text = Ticaret_sicil_no.Trim();
            txtmuhtno.Text = Muhtasar_no.Trim();
            txtsgkkullanicino.Text = Sgk_kullanici.Trim();
            txtsgkek.Text = Sgk_ek.Trim();
            txtsgkisyerisifresi.Text = Sgk_isyeri_sifresi.Trim();
            txtsgksistemsifresi.Text = Sgk_sistem_sifresi.Trim();
            txtvdkkullanici.Text = Vdk_kullanici.Trim();
            txtvdkparola.Text = Vdk_parola.Trim();
            txtvdksifre.Text = Vdk_sifre.Trim();
            comboBox1.Text = Durumu.Trim();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblfirmano.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Firma_Bilgileri where id =(" + id +")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            tabloyutemizle("temizle");
            verilerigoster("select * from Firma_Bilgileri");
        }
        public void tabloyutemizle(string temizle)
        {
            lblfirmano.Text = "-";
            lblkisaad.Text = "-";
            txtfirmagurup.Text = "";
            txtfirmaunvan.Text = "";
            txtsube.Text = "";
            txtreferans.Text = "";
            txtyetkili.Text = "";
            txttelefon.Text = "";
            txtadres.Text = "";
            txtil.Text = "";
            txtilce.Text = "";
            txtsgkisyerino.Text = "";
            txtvdairesi.Text = "";
            txtvergino.Text = "";
            txtticsicilno.Text = "";
            txtmuhtno.Text = "";
            txtsgkkullanicino.Text = "";
            txtsgkek.Text = "";
            txtsgkisyerisifresi.Text = "";
            txtsgksistemsifresi.Text = "";
            txtvdkkullanici.Text = "";
            txtvdkparola.Text = "";
            txtvdksifre.Text = "";
            comboBox1.Text = "";
        }
        private void btnyeni_Click(object sender, EventArgs e)
        {
            tabloyutemizle("temizle");
            verilerigoster("select * from Firma_Bilgileri");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bildirgebilgial bld = new bildirgebilgial();
            bld.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from Firma_Bilgileri where Durumu ='" + comboBox1.Text +"'");
        }
    }
}
