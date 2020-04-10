using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1ListaPrzebojów
{
    public partial class CheckingDate : Form
    {
        public string TrackToCheck { get; set; }
        public CheckingDate()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var checkingDate = new MainProgram();
            checkingDate.Closed += (s, args) => this.Close();
            checkingDate.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TrackToCheck = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var baza = new TPCContextDBHitsList())
            {
                if (baza.Database.Exists())
                {
                    var INFO = baza.Utwory.Select(x => x).ToList();
                    var INFO2 = INFO.SelectMany(x => x.Gatunki);
                    var INFO3 = INFO.SelectMany(x => x.Nagrody);
                    //var IdUtworu = trackInfo.Select(x => x.IdUtworu);
                    var trackInfo2 = from gatunki in baza.Gatunki join utwory in INFO2 on gatunki.IdGatunku equals utwory.IdGatunku select new  { NazwaGatunku = gatunki.NazwaGatunku, RokPowstania = gatunki.RokPowstania, MiejscePowstania = gatunki.MiejscePowstania };
                    //var trackInfo3 = baza.Oceny.Where(x => baza.Oceny.Select(z => z.IdOceny) == trackInfo.Select(y => y.OcenaId)); //tutaj musialem selectem  pobrac bo typ mi sie nie zgadzał
                    //var trackInfo4 = baza.Albumy.Where(x => baza.Albumy.Select(z => z.IdAlbumu) == trackInfo.Select(y => y.AlbumId)); ; //tutaj musialem selectem  pobrac bo typ mi sie nie zgadzał
                    //var trackInfo5 = baza.Nagrody.Where(x => baza.Nagrody.Select(z => z.Utwory.Select(w => w.IdUtworu)) == trackInfo.Select(y => y.IdUtworu)); ; //tutaj musialem selectem  pobrac bo typ mi sie nie zgadzał
                    //var trackInfo6 = baza.Wykonawca.Where(x => baza.Wykonawca.Select(z => z.IdWykonawcy) == trackInfo.Select(y => y.WykonawcaId)); ; //tutaj musialem selectem  pobrac bo typ mi sie nie zgadzał
                    //var trackInfo4 = baza.Albumy.Where(x => x.IdAlbumu == IdUtworu);
                    foreach (var item in INFO)
                    {
                        InfoBox1.Text = $"Nazwa utworu: {item.NazwaUtworu}\r\nRok Wydania: {item.RokWykonania}\r\nOpis Utworu: { item.OpisUtworu}\r\nDługość: {item.Długość}\r\nWykonawca: {item.Wykonawca.Wykonawca}.";
                    }
                    foreach (var item in INFO2)
                    {
                        InfoBox2.Text = $"Nazwa gatunku: {item.NazwaGatunku}\r\nRok powstania: {item.RokPowstania}\r\nMiejsce Powstania: {item.MiejscePowstania}";
                    }
                    //InfoBox3.Text = $"Ocena Administratora: {trackInfo3.Select(x => x.OcenaAdministratora)}\r\nOcena Administratorki: {trackInfo3.Select(x => x.OcenaAdministratora)}\r\nKomentarz: {trackInfo3.Select(x => x.Komentarz)}.";
                    //InfoBox4.Text = $"Nazwa Albumu: {trackInfo4.Select(x => x.NazwaAlbumu)}\r\nData Wydania: {trackInfo4.Select(x => x.RokWydania)}\r\nRok Rozpoczęcia Nagrań: {trackInfo4.Select(x => x.RokRozpoczecieNagrań)}\r\nWydawnictwo: {trackInfo4.Select(x => x.Wydawnictwo)}.";
                    //InfoBox5.Text = $"Nazwa Nagrody: {trackInfo5.Select(x => x.NazwaNagrody)}\r\nKategoria: {trackInfo5.Select(x => x.Kategoria)}\r\nPierwsze Wręczenie: {trackInfo5.Select(x => x.RokWreczeniaPierwszejNagrody)}.";
                    //InfoBox6.Text = $"Wykonawca: {trackInfo6.Select(x => x.Wykonawca)}.";

                    InfoBox1.Visible = true;
                    InfoBox2.Visible = true;
                    InfoBox3.Visible = true;
                    InfoBox4.Visible = true;
                    InfoBox5.Visible = true;
                    InfoBox6.Visible = true;
                }
            }
           
        }
    }
}
