using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFALibraryProject
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();

            Yazar yazar = new Yazar()
            {
                Ad = "Orhan",
                Soyad = "Pamuk",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar1 = new Yazar()
            {
                Ad = "Reşat Nuri",
                Soyad = "Güntekin",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar2 = new Yazar()
            {
                Ad = "Yahya",
                Soyad = "Kemal",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar3 = new Yazar()
            {
                Ad = "Ayşe",
                Soyad = "Kulin",
                Cinsiyet = false,
                Id = Guid.NewGuid(),
            };
            Yazar yazar4 = new Yazar()
            {
                Ad = "Kemal",
                Soyad = "Tahir",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar5 = new Yazar()
            {
                Ad = "Ömer",
                Soyad = "Seyfettin",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar6 = new Yazar()
            {
                Ad = "Halide Edip",
                Soyad = "Adıvar",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar7 = new Yazar()
            {
                Ad = "Orhan",
                Soyad = "Pamuk",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar8 = new Yazar()
            {
                Ad = "Yoluğ",
                Soyad = "Tigin",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar9 = new Yazar()
            {
                Ad = "Fazıl Hüsnü",
                Soyad = "Dağlarca",
                Cinsiyet = true,
                Id = Guid.NewGuid(),
            };
            Yazar yazar10 = new Yazar()
            {
                Ad = "Elif",
                Soyad = "Şafak",
                Cinsiyet = false,
                Id = Guid.NewGuid(),
            };
            Data.Yazarlar.Add(yazar);
            Data.Yazarlar.Add(yazar1);
            Data.Yazarlar.Add(yazar2);
            Data.Yazarlar.Add(yazar3);
            Data.Yazarlar.Add(yazar4);
            Data.Yazarlar.Add(yazar5);
            Data.Yazarlar.Add(yazar6);
            Data.Yazarlar.Add(yazar7);
            Data.Yazarlar.Add(yazar8);
            Data.Yazarlar.Add(yazar9);
            Data.Yazarlar.Add(yazar10);

            Kitap kitap = new Kitap()
            {
                Ad = "ÇALIKUŞU",
                Tur = "ROMAN",
                BasimYili = dtpBasimYili.Value.AddDays(6),
                Id = Guid.NewGuid(),
            };

            Kitap kitap1 = new Kitap()
            {
                Ad = "MAİ VE SİYAH",
                Tur = "ROMAN",
                BasimYili = dtpBasimYili.Value.AddDays(5),
                Id = Guid.NewGuid(),
            };
            Kitap kitap2 = new Kitap()
            {
                Ad = "SEVDALİNKA",
                Tur = "MACERA",
                BasimYili = dtpBasimYili.Value.AddDays(3),
                Id = Guid.NewGuid(),
            };
            Data.Kitaplar.Add(kitap);
            Data.Kitaplar.Add(kitap1);
            Data.Kitaplar.Add(kitap2);

        


    }


        // Genel Metotlar
        private void VerileriGetir()
        {
            dgwYazarlar.DataSource = null;
            dgwYazarlar.DataSource = Data.Yazarlar;
            dgwYazarlar.Columns[2].Visible = false;
        }

        private void AlaniTemizle()
        {
            txtYazarAdi.Text = string.Empty;
            txtYazarSoyadi.Text = string.Empty;
            txtKitapAdi.Text = string.Empty;
            txtKitapTuru.Text = string.Empty;
            txtKitapTuru.Text = string.Empty;


        }


        // Yazar için Metotlar

        private void YazarlarıGetir()
        {
            cbYazarlar.DataSource = null;
            cbYazarlar.DataSource = Data.Yazarlar;
            cbYazarlar.DisplayMember = "FulAd";
            cbYazarlar.ValueMember = "Id";
        }
        private Guid YazarIdBul()
        {
            var selectedId = dgwYazarlar.Rows[dgwYazarlar.SelectedCells[0].RowIndex].Cells[4].Value;

            return (Guid)selectedId;

        }


        // DatagridView için

        private void dgwYazarlar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnYazarSil.Enabled = true;
        }

        //Yazarlar için - ContextMenü Strip - Güncelle işlemi
        private void güncelleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Islem<Yazar> yazarIslemler = new Islem<Yazar>();
            var guncellenecekYazar = yazarIslemler.Getir(YazarIdBul());
            txtYazarAdi.Text = guncellenecekYazar.Ad;
            txtYazarSoyadi.Text = guncellenecekYazar.Soyad;
            chkErkek.Checked = guncellenecekYazar.Cinsiyet ? true : false;
            chkKadin.Checked = guncellenecekYazar.Cinsiyet ? false : true;
        }

        // Yazar buton işlemleri

        private void btnYazarEkle_Click(object sender, EventArgs e)
        {
            Yazar eklenecekYazar = new Yazar()
            {
                Id = Guid.NewGuid(),
                Ad = txtYazarAdi.Text,
                Soyad = txtYazarSoyadi.Text,
                Cinsiyet = chkErkek.Checked ? true : false,
            };

            Islem<Yazar> yazarIslemler = new Islem<Yazar>();
            yazarIslemler.Ekle(eklenecekYazar);

            VerileriGetir();
            AlaniTemizle();
            YazarlarıGetir();



        }

        private void btnYazarSil_Click(object sender, EventArgs e)
        {
            Islem<Yazar> yazarIslemler = new Islem<Yazar>();
            var silinecekYazar = yazarIslemler.Getir(YazarIdBul());
            yazarIslemler.Sil(silinecekYazar);
            VerileriGetir();
            btnYazarSil.Enabled = false;
        }

        private void btnYazarGuncelle_Click(object sender, EventArgs e)
        {
            Islem<Yazar> yazarIslemler = new Islem<Yazar>();
            var yeniyazar = new Yazar()
            {

                Ad = txtYazarAdi.Text,
                Soyad = txtYazarSoyadi.Text,
                Cinsiyet = chkErkek.Checked ? true : false,

                Id = YazarIdBul()
            };
            yazarIslemler.Guncelle(yeniyazar);
            VerileriGetir();
            AlaniTemizle();
        }


        private void KitaplariGetir()
        {
            dgwKitaplar.DataSource = null;
            dgwKitaplar.DataSource = Data.Kitaplar;

        }

        private void dgwKitaplar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var secilenId = dgwKitaplar.Rows[dgwKitaplar.SelectedCells[0].RowIndex].Cells[4].Value.ToString();

            btnKitapSil.Enabled = true;
        }

        private Guid KitapIdBul()
        {
            var selectedId = dgwKitaplar.Rows[dgwKitaplar.SelectedCells[0].RowIndex].Cells[4].Value;

            return (Guid)selectedId;

        }

        // Kitaplar için - ContextMenü Strip- Güncelle işlemi
        private void güncelleToolStripMenuItem1_Click_2(object sender, EventArgs e)
        {
            Islem<Kitap> kitapIslemler = new Islem<Kitap>();
            Islem<Yazar> yazarIslemler = new Islem<Yazar>();
            var guncellenecekKitap = kitapIslemler.Getir(KitapIdBul());
            txtKitapAdi.Text = guncellenecekKitap.Ad;
            txtKitapTuru.Text = guncellenecekKitap.Tur;
            dtpBasimYili.Value = guncellenecekKitap.BasimYili;
            cbYazarlar.SelectedItem = yazarIslemler.Getir(Guid.Parse(guncellenecekKitap.YazarId));

            btnKitapGuncelle.Enabled = true;
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            Kitap eklenecekKitap = new Kitap()
            {

                Ad = txtKitapAdi.Text,
                Tur = txtKitapTuru.Text,
                BasimYili = dtpBasimYili.Value,

                YazarId = cbYazarlar.SelectedValue.ToString(),
                Id = Guid.NewGuid(),

            };

            Islem<Kitap> kitapIslemler = new Islem<Kitap>();
            kitapIslemler.Ekle(eklenecekKitap);


            AlaniTemizle();
            KitaplariGetir();



        }


        private void btnKitapSil_Click(object sender, EventArgs e)
        {
            Islem<Kitap> kitapIslemler = new Islem<Kitap>();
            var silinecekKitap = kitapIslemler.Getir(KitapIdBul());
            kitapIslemler.Sil(silinecekKitap);
            VerileriGetir();
            btnKitapSil.Enabled = false;
            AlaniTemizle();
            KitaplariGetir();


        }

        private void btnKitapGuncelle_Click(object sender, EventArgs e)
        {
            Islem<Kitap> kitapIslemler = new Islem<Kitap>();
            Kitap yenikitap = new Kitap()
            {

                Ad = txtKitapAdi.Text,
                Tur = txtKitapTuru.Text,
                BasimYili = dtpBasimYili.Value,
                YazarId = cbYazarlar.SelectedValue.ToString(),
                Id = KitapIdBul(),
            };
            kitapIslemler.Guncelle(yenikitap);
            KitaplariGetir();
            AlaniTemizle();
        }

        private void txtKitapAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtKitapAdi.Text.Length > 0)

                btnKitapEkle.Enabled = true;

            else
                btnKitapEkle.Enabled = false;
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            YazarlarıGetir();
            KitaplariGetir();
            TurGetir();
            VerileriGetir();
        }



        // Türler için Metotlar
        private void TurGetir()
        {
            dgwTurler.DataSource = null;
            dgwTurler.DataSource = Data.Turler;
        }

        private Guid TurIdBul()
        {
            var selectedId = dgwTurler.Rows[dgwTurler.SelectedCells[0].RowIndex].Cells["Id"].Value;

            return (Guid)selectedId;

        }
    
     

        // Türler için Crud işlemleri
        private void btnTurEkle_Click(object sender, EventArgs e)
        {
            {
                Tur eklenecekTur = new Tur()
                {
                    TurAdi = txtKitapTurAdi.Text,
                    Id = Guid.NewGuid()


                };

                Islem<Tur> turIslemler = new Islem<Tur>();
                turIslemler.Ekle(eklenecekTur);

                TurGetir();
                AlaniTemizle();

            }
        }

        private void btnTurSil_Click(object sender, EventArgs e)
        {
            Islem<Tur> turIslemler = new Islem<Tur>();
            var silinecekTur = turIslemler.Getir(TurIdBul());
            turIslemler.Sil(silinecekTur);
            VerileriGetir();
            btnTurSil.Enabled = false;
            AlaniTemizle();
            TurGetir();
        }

        private void btnTurGuncelle_Click(object sender, EventArgs e)
        {
            Islem<Tur> turIslemler = new Islem<Tur>();
            Tur yenitur = new Tur()
            {

                TurAdi = txtKitapTurAdi.Text,
                Id = TurIdBul()
            };
            turIslemler.Guncelle(yenitur);

            TurGetir();
            AlaniTemizle();
        }

        // Tür için - CMS - Güncelle işlemi
        private void güncelleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Islem<Tur> turIslemler = new Islem<Tur>();

            var guncellenecekTur = turIslemler.Getir(TurIdBul());
            txtKitapTurAdi.Text = guncellenecekTur.TurAdi;
            btnKitapGuncelle.Enabled = true;
        }
    }

















}
