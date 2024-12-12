using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpDRugiProjekat2
{

    public partial class DodajVozilo : Form
    {
        int idKategorije;
        string naziv;
        string marka;
        string model;
        int godinaProizvodnje;
        int cena;

        RentACarDBTableAdapters.VoziloTableAdapter voziloAdapter;
        public event FormClosedEventHandler onFormClosed;
        DataGridView dgw;
        RentACarDBTableAdapters.VoziloTableAdapter da;
        RentACarDB ds;
        RentACarDBTableAdapters.KategorijaTableAdapter kategorijaAdapter;
        public DodajVozilo(DataGridView dgw, RentACarDBTableAdapters.VoziloTableAdapter da, RentACarDB ds)
        {
            InitializeComponent();

            kategorijaAdapter = new RentACarDBTableAdapters.KategorijaTableAdapter();



            voziloAdapter = new RentACarDBTableAdapters.VoziloTableAdapter();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.DataSource = ds.Kategorija;
            comboBox1.DisplayMember = "naizv"; // The property to display
            comboBox1.ValueMember = "id_kategorije"; // The property to use as the value

            //textBox1.val
            this.dgw = dgw;
            this.da = da;
            this.ds = ds;

            kategorijaAdapter.Fill(ds.Kategorija);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Provere.DaLiPostojeGreske(this.Controls))
                return;

            idKategorije = Int32.Parse(comboBox1.SelectedValue.ToString());
            naziv = textBox1.Text;
            marka = textBox2.Text;
            model = textBox3.Text;
            godinaProizvodnje = Int32.Parse(numericUpDown1.Value.ToString());
            cena = Int32.Parse(numericUpDown2.Value.ToString());

            da.Insert(idKategorije, naziv, marka, model, godinaProizvodnje, cena);


            FormClosedEventArgs args = new FormClosedEventArgs(CloseReason.UserClosing);

            MessageBox.Show("Uspesno ste doodali vozilo!");

            //voziloAdapter.Fill(ds.Vozilo);

            onFormClosed.Invoke(this, args);

            dgw.DataSource = ds.Vozilo;

            this.Close();
        }

        private void DodajVozilo_Load(object sender, EventArgs e)
        {
            Provere.DodajProveruUnosa(this.Controls);

            comboBox1.DataSource = ds.Kategorija.ToList();

            numericUpDown1.Maximum = DateTime.Now.Year + 3;
            numericUpDown1.Value = 2015;

            numericUpDown2.Maximum = 1000000;
            
            numericUpDown2.Value = 1000;



        }
    }
}
