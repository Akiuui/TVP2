namespace TvpDRugiProjekat2
{
    partial class DodajRezervaciju
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.klijent_dgw = new System.Windows.Forms.DataGridView();
            this.idklijentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vozackakategorijaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klijentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rentACarDB = new TvpDRugiProjekat2.RentACarDB();
            this.vozilo_dgw = new System.Windows.Forms.DataGridView();
            this.idvozilaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idkategorijeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazivDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.godinaproizvodnjeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenaposatuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voziloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.voziloTableAdapter = new TvpDRugiProjekat2.RentACarDBTableAdapters.VoziloTableAdapter();
            this.klijentTableAdapter = new TvpDRugiProjekat2.RentACarDBTableAdapters.KlijentTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.klijent_dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.klijentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentACarDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vozilo_dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voziloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(647, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(273, 54);
            this.button1.TabIndex = 13;
            this.button1.Text = "Prosledi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kraj rezervacije:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pocetak rezervacije:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(265, 402);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 10;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 402);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // klijent_dgw
            // 
            this.klijent_dgw.AllowUserToAddRows = false;
            this.klijent_dgw.AllowUserToDeleteRows = false;
            this.klijent_dgw.AutoGenerateColumns = false;
            this.klijent_dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.klijent_dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idklijentaDataGridViewTextBoxColumn,
            this.imeDataGridViewTextBoxColumn,
            this.prezimeDataGridViewTextBoxColumn,
            this.adresaDataGridViewTextBoxColumn,
            this.telefonDataGridViewTextBoxColumn,
            this.vozackakategorijaDataGridViewTextBoxColumn});
            this.klijent_dgw.DataSource = this.klijentBindingSource;
            this.klijent_dgw.Location = new System.Drawing.Point(7, 183);
            this.klijent_dgw.Name = "klijent_dgw";
            this.klijent_dgw.ReadOnly = true;
            this.klijent_dgw.RowHeadersWidth = 51;
            this.klijent_dgw.RowTemplate.Height = 24;
            this.klijent_dgw.Size = new System.Drawing.Size(932, 150);
            this.klijent_dgw.TabIndex = 8;
            this.klijent_dgw.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.klijent_dgw_DataBindingComplete);
            // 
            // idklijentaDataGridViewTextBoxColumn
            // 
            this.idklijentaDataGridViewTextBoxColumn.DataPropertyName = "id_klijenta";
            this.idklijentaDataGridViewTextBoxColumn.HeaderText = "id_klijenta";
            this.idklijentaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idklijentaDataGridViewTextBoxColumn.Name = "idklijentaDataGridViewTextBoxColumn";
            this.idklijentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idklijentaDataGridViewTextBoxColumn.Width = 125;
            // 
            // imeDataGridViewTextBoxColumn
            // 
            this.imeDataGridViewTextBoxColumn.DataPropertyName = "ime";
            this.imeDataGridViewTextBoxColumn.HeaderText = "ime";
            this.imeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.imeDataGridViewTextBoxColumn.Name = "imeDataGridViewTextBoxColumn";
            this.imeDataGridViewTextBoxColumn.ReadOnly = true;
            this.imeDataGridViewTextBoxColumn.Width = 125;
            // 
            // prezimeDataGridViewTextBoxColumn
            // 
            this.prezimeDataGridViewTextBoxColumn.DataPropertyName = "prezime";
            this.prezimeDataGridViewTextBoxColumn.HeaderText = "prezime";
            this.prezimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.prezimeDataGridViewTextBoxColumn.Name = "prezimeDataGridViewTextBoxColumn";
            this.prezimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prezimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // adresaDataGridViewTextBoxColumn
            // 
            this.adresaDataGridViewTextBoxColumn.DataPropertyName = "adresa";
            this.adresaDataGridViewTextBoxColumn.HeaderText = "adresa";
            this.adresaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.adresaDataGridViewTextBoxColumn.Name = "adresaDataGridViewTextBoxColumn";
            this.adresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.adresaDataGridViewTextBoxColumn.Width = 125;
            // 
            // telefonDataGridViewTextBoxColumn
            // 
            this.telefonDataGridViewTextBoxColumn.DataPropertyName = "telefon";
            this.telefonDataGridViewTextBoxColumn.HeaderText = "telefon";
            this.telefonDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.telefonDataGridViewTextBoxColumn.Name = "telefonDataGridViewTextBoxColumn";
            this.telefonDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefonDataGridViewTextBoxColumn.Width = 125;
            // 
            // vozackakategorijaDataGridViewTextBoxColumn
            // 
            this.vozackakategorijaDataGridViewTextBoxColumn.DataPropertyName = "vozacka_kategorija";
            this.vozackakategorijaDataGridViewTextBoxColumn.HeaderText = "vozacka_kategorija";
            this.vozackakategorijaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.vozackakategorijaDataGridViewTextBoxColumn.Name = "vozackakategorijaDataGridViewTextBoxColumn";
            this.vozackakategorijaDataGridViewTextBoxColumn.ReadOnly = true;
            this.vozackakategorijaDataGridViewTextBoxColumn.Width = 125;
            // 
            // klijentBindingSource
            // 
            this.klijentBindingSource.DataMember = "Klijent";
            this.klijentBindingSource.DataSource = this.rentACarDB;
            // 
            // rentACarDB
            // 
            this.rentACarDB.DataSetName = "RentACarDB";
            this.rentACarDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vozilo_dgw
            // 
            this.vozilo_dgw.AllowUserToAddRows = false;
            this.vozilo_dgw.AllowUserToDeleteRows = false;
            this.vozilo_dgw.AutoGenerateColumns = false;
            this.vozilo_dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vozilo_dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idvozilaDataGridViewTextBoxColumn,
            this.idkategorijeDataGridViewTextBoxColumn,
            this.nazivDataGridViewTextBoxColumn,
            this.markaDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.godinaproizvodnjeDataGridViewTextBoxColumn,
            this.cenaposatuDataGridViewTextBoxColumn});
            this.vozilo_dgw.DataSource = this.voziloBindingSource;
            this.vozilo_dgw.Location = new System.Drawing.Point(8, 27);
            this.vozilo_dgw.Name = "vozilo_dgw";
            this.vozilo_dgw.ReadOnly = true;
            this.vozilo_dgw.RowHeadersWidth = 51;
            this.vozilo_dgw.RowTemplate.Height = 24;
            this.vozilo_dgw.Size = new System.Drawing.Size(932, 150);
            this.vozilo_dgw.TabIndex = 7;
            this.vozilo_dgw.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.vozilo_dgw_DataBindingComplete);
            this.vozilo_dgw.SelectionChanged += new System.EventHandler(this.vozilo_dgw_SelectionChanged);
            // 
            // idvozilaDataGridViewTextBoxColumn
            // 
            this.idvozilaDataGridViewTextBoxColumn.DataPropertyName = "id_vozila";
            this.idvozilaDataGridViewTextBoxColumn.HeaderText = "id_vozila";
            this.idvozilaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idvozilaDataGridViewTextBoxColumn.Name = "idvozilaDataGridViewTextBoxColumn";
            this.idvozilaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idvozilaDataGridViewTextBoxColumn.Width = 125;
            // 
            // idkategorijeDataGridViewTextBoxColumn
            // 
            this.idkategorijeDataGridViewTextBoxColumn.DataPropertyName = "id_kategorije";
            this.idkategorijeDataGridViewTextBoxColumn.HeaderText = "id_kategorije";
            this.idkategorijeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idkategorijeDataGridViewTextBoxColumn.Name = "idkategorijeDataGridViewTextBoxColumn";
            this.idkategorijeDataGridViewTextBoxColumn.ReadOnly = true;
            this.idkategorijeDataGridViewTextBoxColumn.Width = 125;
            // 
            // nazivDataGridViewTextBoxColumn
            // 
            this.nazivDataGridViewTextBoxColumn.DataPropertyName = "naziv";
            this.nazivDataGridViewTextBoxColumn.HeaderText = "naziv";
            this.nazivDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nazivDataGridViewTextBoxColumn.Name = "nazivDataGridViewTextBoxColumn";
            this.nazivDataGridViewTextBoxColumn.ReadOnly = true;
            this.nazivDataGridViewTextBoxColumn.Width = 125;
            // 
            // markaDataGridViewTextBoxColumn
            // 
            this.markaDataGridViewTextBoxColumn.DataPropertyName = "marka";
            this.markaDataGridViewTextBoxColumn.HeaderText = "marka";
            this.markaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.markaDataGridViewTextBoxColumn.Name = "markaDataGridViewTextBoxColumn";
            this.markaDataGridViewTextBoxColumn.ReadOnly = true;
            this.markaDataGridViewTextBoxColumn.Width = 125;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "model";
            this.modelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.ReadOnly = true;
            this.modelDataGridViewTextBoxColumn.Width = 125;
            // 
            // godinaproizvodnjeDataGridViewTextBoxColumn
            // 
            this.godinaproizvodnjeDataGridViewTextBoxColumn.DataPropertyName = "godina_proizvodnje";
            this.godinaproizvodnjeDataGridViewTextBoxColumn.HeaderText = "godina_proizvodnje";
            this.godinaproizvodnjeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.godinaproizvodnjeDataGridViewTextBoxColumn.Name = "godinaproizvodnjeDataGridViewTextBoxColumn";
            this.godinaproizvodnjeDataGridViewTextBoxColumn.ReadOnly = true;
            this.godinaproizvodnjeDataGridViewTextBoxColumn.Width = 125;
            // 
            // cenaposatuDataGridViewTextBoxColumn
            // 
            this.cenaposatuDataGridViewTextBoxColumn.DataPropertyName = "cena_po_satu";
            this.cenaposatuDataGridViewTextBoxColumn.HeaderText = "cena_po_satu";
            this.cenaposatuDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cenaposatuDataGridViewTextBoxColumn.Name = "cenaposatuDataGridViewTextBoxColumn";
            this.cenaposatuDataGridViewTextBoxColumn.ReadOnly = true;
            this.cenaposatuDataGridViewTextBoxColumn.Width = 125;
            // 
            // voziloBindingSource
            // 
            this.voziloBindingSource.DataMember = "Vozilo";
            this.voziloBindingSource.DataSource = this.rentACarDB;
            // 
            // voziloTableAdapter
            // 
            this.voziloTableAdapter.ClearBeforeFill = true;
            // 
            // klijentTableAdapter
            // 
            this.klijentTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Cena:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 16;
            // 
            // DodajRezervaciju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.klijent_dgw);
            this.Controls.Add(this.vozilo_dgw);
            this.Name = "DodajRezervaciju";
            this.Text = "DodajRezervaciju";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DodajRezervaciju_FormClosed_1);
            this.Load += new System.EventHandler(this.DodajRezervaciju_Load);
            ((System.ComponentModel.ISupportInitialize)(this.klijent_dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.klijentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentACarDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vozilo_dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voziloBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView klijent_dgw;
        private System.Windows.Forms.DataGridView vozilo_dgw;
        private RentACarDB rentACarDB;
        private System.Windows.Forms.BindingSource voziloBindingSource;
        private RentACarDBTableAdapters.VoziloTableAdapter voziloTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idvozilaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idkategorijeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn godinaproizvodnjeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenaposatuDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource klijentBindingSource;
        private RentACarDBTableAdapters.KlijentTableAdapter klijentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idklijentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vozackakategorijaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}