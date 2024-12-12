using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpDRugiProjekat2
{
    public partial class Vozila : Form
    {
        RentACarDB ds;
        RentACarDBTableAdapters.VoziloTableAdapter voziloAdapter;
        RentACarDBTableAdapters.KategorijaTableAdapter kategorijaAdapter;
        RentACarDBTableAdapters.RezervacijaTableAdapter rezervacijaAdapter;

        public event FormClosedEventHandler osveziBazu;

        List<RentACarDB.VoziloRow> filter;
        List<RentACarDB.VoziloRow> filter1;
        List<RentACarDB.VoziloRow> filter2;
        List<RentACarDB.VoziloRow> filter3;

        bool onlyOnce;

        public Vozila()
        {
            InitializeComponent();
            ds = new RentACarDB();

            voziloAdapter = new RentACarDBTableAdapters.VoziloTableAdapter();
            kategorijaAdapter = new RentACarDBTableAdapters.KategorijaTableAdapter();
            rezervacijaAdapter = new RentACarDBTableAdapters.RezervacijaTableAdapter();

            //osveziBazu += OsveziBazu;

            checkBox1.CheckedChanged += checkBoxChanged;
            checkBox2.CheckedChanged += checkBoxChanged;
            checkBox3.CheckedChanged += checkBoxChanged;

            voziloAdapter.Fill(ds.Vozilo);
            kategorijaAdapter.Fill(ds.Kategorija);
            rezervacijaAdapter.Fill(ds.Rezervacija);

            filter = ds.Vozilo.ToList();

            dataGridView1.DataSource = filter;
            //dataGridView1.DataSource = ds.Vozilo;

            comboBox1.DataSource = ds.Kategorija;

  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.kategorijaTableAdapter.Fill(this.rentACarDB.Kategorija);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            numericUpDown1.Value = 0;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = int.MaxValue;

            numericUpDown2.Maximum = int.MaxValue;
            numericUpDown2.Value = 1000;

        }
        private void promenaComboBoxa()
        {
            if (comboBox1.SelectedValue == null)
                return;

            int id;
            Int32.TryParse(comboBox1.SelectedValue.ToString(), out id);

            var filPoKat = from vozilo in ds.Vozilo
                           where vozilo.id_kategorije == id
                           select vozilo;

            if (filPoKat == null)
            {
                MessageBox.Show("Nula je");
                return;

            }

            filter1 = filPoKat.ToList();

        }

        private void promenaVremena()
        {
            DateTime pocetno = dateTimePicker1.Value;
            DateTime krajnje = dateTimePicker2.Value;
            List<int> rezervacijeSePoklapaju = new List<int>();

            if (pocetno > krajnje)
            {
                dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-2);

                MessageBox.Show("Niste dobro namestili datum");
                return;
            }

            foreach (var rez in ds.Rezervacija)
            {

                if (pocetno <= rez.datumVreme_kraja && krajnje >= rez.datumVreme_pocetka)
                {
                    rezervacijeSePoklapaju.Add(rez.id_vozila);
                }

            }

            var fil = from vozilo in ds.Vozilo
                      where !rezervacijeSePoklapaju.Contains(vozilo.id_vozila)
                      select vozilo;

            filter2 = fil.ToList();

        }


        private void promenaOpsegaCene()
        {
            var filterPoCeni = from vozilo in ds.Vozilo
                               where vozilo.cena_po_satu >= numericUpDown1.Value
                               && vozilo.cena_po_satu <= numericUpDown2.Value
                               select vozilo;

            filter3 = filterPoCeni.ToList();

        }
        private void checkBoxChanged(object sender, EventArgs e)
        {
            checkChanged();
        }
        private void checkChanged()
        {
            if (checkBox1.Checked)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
            if (checkBox2.Checked)
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            if (checkBox3.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;

            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }

        }

        private void DodajKategoriju(object sender, EventArgs e)
        {
            DodajKategoriju dodajkategoriju = new DodajKategoriju(comboBox1);
            dodajkategoriju.ShowDialog();
        }
        private void DodajVozilo(object sender, EventArgs e)
        {
            DodajVozilo dodajvozilo = new DodajVozilo(dataGridView1, voziloAdapter, ds);
            dodajvozilo.onFormClosed += Dodajvozilo_onFormClosed;
            dodajvozilo.ShowDialog();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void Dodajvozilo_onFormClosed(object sender, FormClosedEventArgs e)
        {
            voziloAdapter.Fill(ds.Vozilo);
            filter.Clear();
            filter = ds.Vozilo.ToList();

            dataGridView1.DataSource = filter;

            numericUpDown2.Maximum = (from vozilo in ds.Vozilo
                                      select vozilo.cena_po_satu).Max();
            numericUpDown2.Value = numericUpDown2.Maximum - 100;


        }

        RentACarDB.VoziloRow vozilo1;

        private void ObrisiVozilo(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Niste lepo selektovali redove");
                return;
            }

            try {
                if (dataGridView1.SelectedRows[0].DataBoundItem == null)
                {
                    MessageBox.Show("Greska");
                    return;
                }
                vozilo1 = dataGridView1.SelectedRows[0].DataBoundItem as RentACarDB.VoziloRow;

               
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            if (vozilo1 == null)
                return;

            try
            {
                voziloAdapter.Delete(vozilo1.id_vozila, vozilo1.id_kategorije, vozilo1.godina_proizvodnje, vozilo1.cena_po_satu);

                voziloAdapter.Fill(ds.Vozilo);
                filter.Clear();
                filter = ds.Vozilo.ToList();
                dataGridView1.DataSource = filter;

                MessageBox.Show("Uspesno obrisano!");
            }
            catch (System.Data.OleDb.OleDbException ex) {
                MessageBox.Show("Nije moguce obrisati element jer postoji referenca kod rezervacija!"); ;
                return;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
                
        }
        private void button4_Click(object sender, EventArgs e)
        {
            filter = ds.Vozilo.ToList();
            if (checkBox1.Checked)
            {
                promenaComboBoxa();
            }
            else filter1 = ds.Vozilo.ToList();

            if (checkBox2.Checked)
            {
                promenaOpsegaCene();
            }
            else filter3 = ds.Vozilo.ToList();

            if (checkBox3.Checked)
            {
                promenaVremena();
            }
            else filter2 = ds.Vozilo.ToList();

            filter = filter?.Intersect(filter1)?.ToList();
            filter = filter?.Intersect(filter2)?.ToList();
            filter = filter?.Intersect(filter3)?.ToList();

            dataGridView1.DataSource = filter;

            //dataGridView1.Columns.Remove("KategorijaRow");
            //dataGridView1.Columns.Remove("RowError");
            //dataGridView1.Columns.Remove("RowState");
            //dataGridView1.Columns.Remove("Table");
            //dataGridView1.Columns.Remove("HasErrors");


        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
   
            if (Utils.KolonaPostoji("KategorijaRow", dataGridView1)) {

                dataGridView1.Columns.Remove("KategorijaRow");
                dataGridView1.Columns.Remove("RowError");
                dataGridView1.Columns.Remove("RowState");
                dataGridView1.Columns.Remove("Table");
                dataGridView1.Columns.Remove("HasErrors");
                dataGridView1.Columns["id_vozila"].Visible = false;
                dataGridView1.Columns["id_kategorije"].Visible = false;

            }

            if (!onlyOnce)
            {
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                newColumn.Name = "kategorija";
                newColumn.HeaderText = "Kategorija";
                dataGridView1.Columns.Add(newColumn);
                onlyOnce = true;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                var kategorijaInfp = (from kategorija in ds.Kategorija
                                      where (int)row.Cells["id_kategorije"].Value == kategorija.id_kategorije
                                      select new { naziv = kategorija.naziv }).FirstOrDefault();

                row.Cells["kategorija"].Value = kategorijaInfp?.naziv;

            }
        }
    }
}
