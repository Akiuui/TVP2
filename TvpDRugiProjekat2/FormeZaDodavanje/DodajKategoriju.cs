using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpDRugiProjekat2
{
    public partial class DodajKategoriju : Form
    {
        RentACarDBTableAdapters.KategorijaTableAdapter kategorijaAdapter;
        RentACarDB ds;
        public event FormClosedEventHandler onFormClose;
        private ComboBox cmbx;

        public DodajKategoriju(ComboBox cmbx)
        {
            InitializeComponent();

            kategorijaAdapter = new RentACarDBTableAdapters.KategorijaTableAdapter();
            ds = new RentACarDB ();

            kategorijaAdapter.Fill(ds.Kategorija);

            this.cmbx = cmbx;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Provere.DaLiPostojeGreske(this.Controls))
                return;
            string naziv = textBox1.Text;
            string opis = textBox2.Text;

            kategorijaAdapter.Insert(naziv, opis);

            MessageBox.Show("Uspesno dodato!");

            kategorijaAdapter.Fill(ds.Kategorija);
            cmbx.DataSource = ds.Kategorija;
            cmbx.Refresh();

            this.Close();



        }

        private void DodajKategoriju_Load(object sender, EventArgs e)
        {
            Provere.DodajProveruUnosa(this.Controls);
        }
    }
}
