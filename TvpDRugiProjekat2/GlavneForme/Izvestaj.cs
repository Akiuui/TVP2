using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpDRugiProjekat2
{
    public partial class Izvestaj : Form
    {
        RentACarDB ds;
        RentACarDBTableAdapters.RezervacijaTableAdapter rezervacijaAdapter;
        RentACarDBTableAdapters.KategorijaTableAdapter kategorijaAdapter;
        RentACarDBTableAdapters.VoziloTableAdapter vozilaAdapter;
        RentACarDBTableAdapters.KlijentTableAdapter klijentAdapter;


        Color[] bojeKategorija;
        List<RentACarDB.RezervacijaRow> potrebneRezervacije;
        bool onlyOnce = false;
        List<RentACarDB.RezervacijaRow> filter;

        public Izvestaj()
        {
            InitializeComponent();

            ds = new RentACarDB();
            rezervacijaAdapter = new RentACarDBTableAdapters.RezervacijaTableAdapter();
            vozilaAdapter = new RentACarDBTableAdapters.VoziloTableAdapter();
            kategorijaAdapter = new RentACarDBTableAdapters.KategorijaTableAdapter();
            klijentAdapter = new RentACarDBTableAdapters.KlijentTableAdapter();

            dateTimePicker1.ValueChanged += promenaDateTime;
            dateTimePicker2.ValueChanged += promenaDateTime;

            rezervacijaAdapter.Fill(ds.Rezervacija);
            vozilaAdapter.Fill(ds.Vozilo);
            kategorijaAdapter.Fill(ds.Kategorija);
            klijentAdapter.Fill(ds.Klijent);

            filter = ds.Rezervacija.ToList();

            bojeKategorija = new Color[ds.Kategorija.Count];
            Random rand = new Random();
            for (int i = 0; i < ds.Kategorija.Count; i++)
            {
                bojeKategorija[i] = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            }
        }

        private void Izvestaj_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void srediDGW() {

            dataGridView1.Columns.Remove("KlijentRow");
            dataGridView1.Columns.Remove("VoziloRow");
            dataGridView1.Columns.Remove("RowError");
            dataGridView1.Columns.Remove("RowState");
            dataGridView1.Columns.Remove("Table");
            dataGridView1.Columns.Remove("HasErrors");

            if (!onlyOnce) {
                dataGridView1.Columns["id_klijenta"].Visible = false;
                dataGridView1.Columns["id_vozila"].Visible = false;
                dataGridView1.Columns["id_rezervacija"].Visible = false;
            }

            onlyOnce = true;
            
        }
        private void promenaDateTime(object sender, EventArgs e)
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

                if (pocetno <= rez.datumVreme_pocetka && krajnje >= rez.datumVreme_kraja)
                {
                    rezervacijeSePoklapaju.Add(rez.id_rezervacija);
                }

            }

            var fil = from rezervacija in ds.Rezervacija
                      where rezervacijeSePoklapaju.Contains(rezervacija.id_rezervacija)
                      select rezervacija;
            potrebneRezervacije = fil.ToList();


            filter = fil.ToList();

            dataGridView1.DataSource = filter;


            textBox1.Text = fil.ToList().Count.ToString();

            srediDGW();


            Invalidate();


        }

        private void NacrtajPie(Graphics e)
        {
            if (potrebneRezervacije == null || potrebneRezervacije.Count() == 0)
                return;
            float deo = 360 / potrebneRezervacije.Count();

            //Definisemo mapu na osnovu koje cemo da crtamo pitu
            Dictionary<int, int> brojRezervacijaPoKategoriji = new Dictionary<int, int>();
            foreach (var kat in ds.Kategorija)
            {
                brojRezervacijaPoKategoriji.Add(kat.id_kategorije, 0);
            }

            //Prethodnu mapu dopunjujemo sa brojem pojavljivanja
            foreach (var rez in potrebneRezervacije)
            {
                foreach (var voz in ds.Vozilo)
                {
                    if (voz.id_vozila == rez.id_vozila)
                    {
                        brojRezervacijaPoKategoriji[voz.id_kategorije] += 1;
                        break;
                    }
                }
            }
           

            Rectangle r;
            float korak = 0;
            int korakLbl = 250;
            int i = 0;


            foreach (var a in brojRezervacijaPoKategoriji)
            {

                if (a.Value == 0)
                    continue;

                double procenat = (double)a.Value / potrebneRezervacije.Count() * 100;

                SolidBrush brush = new SolidBrush(bojeKategorija[i]);
                r = new Rectangle(400, 250, 150, 150);
                e.FillPie(brush, r, korak, a.Value * deo);
                
                korak += a.Value * deo;
                korakLbl += 20;
                
                foreach (var kat in ds.Kategorija)
                {
                    if (kat.id_kategorije == a.Key)
                    {
                        string linija = kat.naziv +": "+ procenat.ToString("0.00") + "%" + "("+a.Value+")";
                        e.DrawString(linija, new Font("Arial", 13, FontStyle.Regular), new SolidBrush(bojeKategorija[i]), (float)570.0,korakLbl);
                        break;
                    }
                }
                i++;
            }
        }

        private void Izvestaj_Paint(object sender, PaintEventArgs e)
        {
            NacrtajPie(e.Graphics);

            //dataGridView1.DataSource = filter;

        }

        private void Izvestaj_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string detalji = "";

            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Niste lepo selektovali redove");
                return;
            }

            RentACarDB.RezervacijaRow rezervacija1 = (RentACarDB.RezervacijaRow)dataGridView1.SelectedRows[0].DataBoundItem;

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
    }
}
