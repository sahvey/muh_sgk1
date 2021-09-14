using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muh_sgk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FirmaKayit kayit = new FirmaKayit();
            kayit.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bildirgebilgial bld = new bildirgebilgial();
            bld.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ebildirgev2 v2 = new ebildirgev2();
            v2.Show();
            this.Hide();
        }
    }
}
