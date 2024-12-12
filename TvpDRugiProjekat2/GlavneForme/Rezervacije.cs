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


    public partial class Rezervacije : Form
    {
        //public event FormClosedEventHandler onFormClose;
        RentACarDB ds;
        RentACarDBTableAdapters.RezervacijaTableAdapter rezervacijaAdapter;
        RentACarDBTableAdapters.KategorijaTableAdapter kategorijaAdapter;
        RentACarDBTableAdapters.VoziloTableAdapter vozilaAdapter;
        RentACarDBTableAdapters.KlijentTableAdapter klijentAdapter;

        bool onlyOnce = false;

        public Rezervacije()
        {
            InitializeComponent();

            ds = new RentACarDB();
            rezervacijaAdapter = new RentACarDBTableAdapters.RezervacijaTableAdapter();
            vozilaAdapter = new RentACarDBTableAdapters.VoziloTableAdapter();
            kategorijaAdapter = new RentACarDBTableAdapters.KategorijaTableAdapter();
            klijentAdapter = new RentACarDBTableAdapters.KlijentTableAdapter();

            rezervacijaAdapter.Fill(ds.Rezervacija);
            vozilaAdapter.Fill(ds.Vozilo);
            kategorijaAdapter.Fill(ds.Kategorija);
            klijentAdapter.Fill(ds.Klijent);

        }

        private void Rezervacije_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Rezervacija;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            DodajRezervaciju dodajrezervaciju = new DodajRezervaciju(dataGridView1);
            dodajrezervaciju.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Niste lepo selektovali redove");
                return;
            }

            DataRowView rezervacijaTemp = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;

            if (rezervacijaTemp == null)
            {
                MessageBox.Show("Greska");
                return;
            }

            RentACarDB.RezervacijaRow rezevacija1 = rezervacijaTemp.Row as RentACarDB.RezervacijaRow;

            try {

                rezervacijaAdapter.Delete(rezevacija1.id_rezervacija, rezevacija1.id_vozila, rezevacija1.id_klijenta, rezevacija1.datumVreme_pocetka, rezevacija1.datumVreme_kraja, rezevacija1.cena);
                rezervacijaAdapter.Fill(ds.Rezervacija);
                dataGridView1.DataSource = ds.Rezervacija;
                dataGridView1.Refresh();


            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("Nije moguce obrisati element jer postoji referenca na ovaj element!"); ;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


            MessageBox.Show("Uspesno obrisano!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Niste lepo selektovali redove");
                return;
            }

            DataRowView rezervacijaTemp = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;

            if (rezervacijaTemp == null)
            {
                MessageBox.Show("Greska");
                return;
            }

            RentACarDB.RezervacijaRow rezevacija1 = rezervacijaTemp.Row as RentACarDB.RezervacijaRow;

            DodajRezervaciju dodajrezervaciju = new DodajRezervaciju(rezevacija1, dataGridView1);
            dodajrezervaciju.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string detalji = "";

            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Niste lepo selektovali redove");
                return;
            }

            DataRowView rezervacija = (DataRowView)dataGridView1.SelectedRows[0].DataBoundItem;

            RentACarDB.RezervacijaRow rezervacija1 = rezervacija.Row as RentACarDB.RezervacijaRow;

            var voziloInfo = (from vozilo in ds.Vozilo
                              where vozilo.id_vozila == rezervacija1.id_vozila
                              select vozilo
                              ).FirstOrDefault();

            var kategorijaInfo = (from kategorija in ds.Kategorija
                                  where kategorija.id_kategorije == voziloInfo.id_kategorije
                                  select kategorija).FirstOrDefault();

            var klijentInfo = (from klijent in ds.Klijent
                               where klijent.id_klijenta == rezervacija1.id_klijenta
                               select klijent
                               ).FirstOrDefault();

            detalji += "Info o vozilu:\n" + "Vrsta: " + voziloInfo.naziv + " Model: " + voziloInfo.model + " Marka: " + voziloInfo.marka + " Godina Proizvodnje: " + voziloInfo.godina_proizvodnje + " Kategorija: " + kategorijaInfo.naziv;
            detalji += "\nInfo o klijentu:\n" + "Ime: " + klijentInfo.ime + " Prezime: " + klijentInfo.prezime + " Broj telefona: " + klijentInfo.telefon + " Polozena Kategorija: " + klijentInfo.vozacka_kategorija;

            MessageBox.Show(detalji);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!onlyOnce)
            {
                //MessageBox.Show(dataGridView1.Columns.Count.ToString());
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                onlyOnce = true;
            }

            //dataGridView1.Refresh();
            //rezervacijaAdapter.Fill(ds.Rezervacija);
            //dataGridView1.DataSource = ds.Rezervacija;

        }
    }
}
