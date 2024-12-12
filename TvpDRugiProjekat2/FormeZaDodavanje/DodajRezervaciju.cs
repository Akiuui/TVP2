using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvpDRugiProjekat2.RentACarDBTableAdapters;

namespace TvpDRugiProjekat2
{
    public partial class DodajRezervaciju : Form
    {
        RentACarDBTableAdapters.RezervacijaTableAdapter rezervacijaAdapter;
        RentACarDBTableAdapters.VoziloTableAdapter voziloAdapter;
        RentACarDBTableAdapters.KlijentTableAdapter klijentAdapter;

        RentACarDB ds;
        //public event FormClosedEventHandler onFormClose;
        DataGridView dgw;
        
        RentACarDB.RezervacijaRow rezervacija;
        RentACarDB.VoziloRow vozilo;
        
        int ukupnaCena;
        int razlika;

        public DodajRezervaciju(DataGridView dataGrid)
        {
            InitializeComponent();

            rezervacijaAdapter = new RentACarDBTableAdapters.RezervacijaTableAdapter();
            voziloAdapter = new RentACarDBTableAdapters.VoziloTableAdapter();
            klijentAdapter = new RentACarDBTableAdapters.KlijentTableAdapter();

            ds = new RentACarDB();

            rezervacijaAdapter.Fill(ds.Rezervacija);
            voziloAdapter.Fill(ds.Vozilo);
            klijentAdapter.Fill(ds.Klijent);

            vozilo_dgw.DataSource = ds.Vozilo;
            klijent_dgw.DataSource = ds.Klijent;

            this.dgw = dataGrid;
            this.rezervacija = null;
            this.vozilo = null;
        }
        public DodajRezervaciju(RentACarDB.RezervacijaRow rez , DataGridView dataGrid)
        {
            InitializeComponent();

            rezervacijaAdapter = new RentACarDBTableAdapters.RezervacijaTableAdapter();
            voziloAdapter = new RentACarDBTableAdapters.VoziloTableAdapter();
            klijentAdapter = new RentACarDBTableAdapters.KlijentTableAdapter();

            ds = new RentACarDB();
            
            rezervacijaAdapter.Fill(ds.Rezervacija);
            klijentAdapter.Fill(ds.Klijent);
            voziloAdapter.Fill(ds.Vozilo);

            vozilo_dgw.DataSource = ds.Vozilo;
            klijent_dgw.DataSource = ds.Klijent;

            rezervacija = rez;
            this.dgw = dataGrid;

            //dateTimePicker1.ValueChanged += DateTimeChanged;
            //dateTimePicker2.ValueChanged += DateTimeChanged;


        }

        private void DateTimeChanged()
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;

            if (dt1 > dt2)
            {
                MessageBox.Show("Niste lepo podesili datum za rezervaciju!");
                return;
            }
            TimeSpan raz = dt2 - dt1;

            razlika = raz.Days*24+raz.Hours;
            if (vozilo != null) {
                ukupnaCena = razlika * vozilo.cena_po_satu;
                label4.Text = ukupnaCena.ToString();
            }


        }
        private void vozilo_dgw_SelectionChanged(object sender, EventArgs e)
        {
            if (vozilo_dgw.SelectedRows.Count > 0)
            {
                DataRowView voz = (DataRowView)vozilo_dgw.SelectedRows[0].DataBoundItem;
                vozilo = voz.Row as RentACarDB.VoziloRow;

                if (razlika != 0)
                {
                    ukupnaCena = razlika * vozilo.cena_po_satu;
                    label4.Text = ukupnaCena.ToString();
                }

            }
        }

        private void DodajRezervaciju_Load(object sender, EventArgs e)
        {

            klijent_dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vozilo_dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Provere.DodajProveruUnosa(this.Controls);

            //Selektujem redove u datagridu pri izmeni rezervacije
            if (rezervacija != null)
            {
                dateTimePicker1.Value = rezervacija.datumVreme_pocetka;
                dateTimePicker2.Value = rezervacija.datumVreme_kraja;

                vozilo_dgw.ClearSelection();
                foreach (DataGridViewRow row in vozilo_dgw.Rows)
                {
                    if ((int)row.Cells[0].Value == rezervacija.id_vozila)
                    {
                        row.Selected = true;

                        vozilo_dgw.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }

                }
                klijent_dgw.ClearSelection();
                foreach (DataGridViewRow row in klijent_dgw.Rows)
                {
                    if ((int)row.Cells[0].Value == rezervacija.id_klijenta)
                    {
                        row.Selected = true;

                        klijent_dgw.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }

                }
                DataRowView dtr = (DataRowView)vozilo_dgw?.SelectedRows[0].DataBoundItem;
                this.vozilo = dtr.Row as RentACarDB.VoziloRow;

            }

        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            if (Provere.DaLiPostojeGreske(this.Controls))
                return;

            DateTime pocetniDatum;
            DateTime zavrsniDatum;

            if (klijent_dgw.SelectedRows.Count != 1)
            {
                MessageBox.Show("Niste lepo selektovali redove");
                return;
            }
            if (vozilo_dgw.SelectedRows.Count != 1)
            {
                MessageBox.Show("Niste lepo selektovali redove");
                return;
            }

            DataRowView klijent = (DataRowView)klijent_dgw.SelectedRows[0].DataBoundItem;
            DataRowView vozilo = (DataRowView)vozilo_dgw.SelectedRows[0].DataBoundItem;

            RentACarDB.KlijentRow klijent1 = klijent.Row as RentACarDB.KlijentRow;
            RentACarDB.VoziloRow vozilo1 = vozilo.Row as RentACarDB.VoziloRow;

            pocetniDatum = dateTimePicker1.Value;
            zavrsniDatum = dateTimePicker2.Value;

            if(pocetniDatum > zavrsniDatum)
            {
                MessageBox.Show("Niste lepo podesili datum za rezervaciju!");
                return;
            }

            if (rezervacija != null) { 
                rezervacijaAdapter.Delete(rezervacija.id_rezervacija, rezervacija.id_vozila, rezervacija.id_klijenta, rezervacija.datumVreme_pocetka, rezervacija.datumVreme_kraja, rezervacija.cena);
                rezervacijaAdapter.Fill(ds.Rezervacija);
            }


            foreach (var r in ds.Rezervacija)
            {
                if (r.id_vozila == vozilo1.id_vozila)
                {
                    if (r.datumVreme_pocetka <= zavrsniDatum && r.datumVreme_kraja >= pocetniDatum)
                    {
                        MessageBox.Show("Ovo vozilo je vec zauzeto u ovom vremenskom periodu");
                        return;
                    }

                }

            }

            rezervacijaAdapter.Insert(vozilo1.id_vozila, klijent1.id_klijenta, pocetniDatum, zavrsniDatum, ukupnaCena);
            
            rezervacijaAdapter.Fill(ds.Rezervacija);

            dgw.DataSource = ds.Rezervacija;
            dgw.Refresh();

            MessageBox.Show("Uspesno kreirano");
            this.Close();


        }

        //private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        //{
        //    DateTime dt1 = dateTimePicker1.Value;
        //    DateTime dt2 = dateTimePicker2.Value;

        //    if (dt1 > dt2)
        //    {
        //        MessageBox.Show("Niste lepo podesili datum za rezervaciju!");
        //        return;
        //    }
        //    TimeSpan raz = dt2 - dt1;

        //    razlika = (int)raz.TotalHours;
        //    if (vozilo != null)
        //    {
        //        ukupnaCena = razlika * vozilo.cena_po_satu;
        //        label4.Text = ukupnaCena.ToString();
        //    }
        //}

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
        //    DateTime dt1 = dateTimePicker1.Value;
        //    DateTime dt2 = dateTimePicker2.Value;

        //    if (dt1 > dt2)
        //    {
        //        MessageBox.Show("Niste lepo podesili datum za rezervaciju!");
        //        return;
        //    }
        //    TimeSpan raz = dt2 - dt1;

        //    razlika = (int)raz.TotalHours;
        //    if (vozilo != null)
        //    {
        //        ukupnaCena = razlika * vozilo.cena_po_satu;
        //        label4.Text = ukupnaCena.ToString();
        //    }
        //}


        private void DodajRezervaciju_FormClosed_1(object sender, FormClosedEventArgs e)
        {

        }

        private void vozilo_dgw_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            vozilo_dgw.Columns[0].Visible = false;
            vozilo_dgw.Columns[1].Visible = false;

        }

        private void klijent_dgw_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
                klijent_dgw.Columns[0].Visible = false;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTimeChanged();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimeChanged();
        }
    }
}
