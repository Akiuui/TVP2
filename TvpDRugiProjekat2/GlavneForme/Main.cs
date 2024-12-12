using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpDRugiProjekat2
{
    public partial class Main : Form
    {
        
        RentACarDB ds;
        RentACarDBTableAdapters.RezervacijaTableAdapter rezervacijaAdapter;
        RentACarDBTableAdapters.KategorijaTableAdapter kategorijaAdapter;
        RentACarDBTableAdapters.VoziloTableAdapter voziloAdapter;
        Thread t;
        public Main()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            
            ds = new RentACarDB();
            rezervacijaAdapter = new RentACarDBTableAdapters.RezervacijaTableAdapter();
            kategorijaAdapter = new RentACarDBTableAdapters.KategorijaTableAdapter();
            voziloAdapter = new RentACarDBTableAdapters.VoziloTableAdapter();

            rezervacijaAdapter.Fill(ds.Rezervacija);
            kategorijaAdapter.Fill(ds.Kategorija);
            voziloAdapter.Fill(ds.Vozilo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vozila vozila = new Vozila();
            vozila.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rezervacije rezervacije = new Rezervacije();
            rezervacije.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Izvestaj izvestaj = new Izvestaj();
            izvestaj.ShowDialog();
        }
        int x = -300;
        int font = 20;
        PointF point = new PointF(-300, 80);
        Font fnt;
        string najpopularnijiAuto;
        private void Main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            fnt = new Font("Ariel", font, FontStyle.Bold);

            e.Graphics.DrawString(najpopularnijiAuto, fnt,Brushes.Black,point);
           
        }
        private void LevoDesno()
        {
            while (true)
            {
                if (x > 550)
                    x = -300;
                if (font > 45)
                    font = 20;

                point = new PointF(x, 80);
                x += 10;
                font += 2;


                this.Invalidate();
                Thread.Sleep(50);
            }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (ds.Rezervacija.Count == 0)
                return;

            t = new Thread(LevoDesno);
            t.Start();

            Dictionary<int, int> mapa = new Dictionary<int, int>();

            foreach(var voz in ds.Vozilo)
            {
                mapa.Add(voz.id_vozila, 0);
            }

            foreach(var rez in ds.Rezervacija)
            {
                mapa[rez.id_vozila] += 1;
            }
            KeyValuePair<int, int> max = new KeyValuePair<int, int>(0, int.MinValue);
            foreach(var ma in mapa)
            {
                if (ma.Value > max.Value)
                    max = ma;

            }
            voziloAdapter.Fill(ds.Vozilo);
            foreach(var voz in ds.Vozilo)
            {
                if (voz.id_vozila == max.Key)
                {
                    najpopularnijiAuto = voz.marka + " "+voz.model+" "+voz.naziv;
                    break;

                }
            }

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ds.Rezervacija.Count() == 0)
                return;
            t.Abort();
        }
    }
}
