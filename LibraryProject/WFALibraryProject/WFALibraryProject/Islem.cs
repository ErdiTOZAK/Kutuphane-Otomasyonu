using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFALibraryProject
{
    public class Islem <T> where T : BaseModel
    {
        public void Ekle(T data)
        {
            if (data is Yazar yazar)
            {
                Data.Yazarlar.Add(yazar);
            }
            else if (data is Kitap kitap)
            {
                Data.Kitaplar.Add(kitap);

            }
            else if (data is Tur tur)
            {
                Data.Turler.Add(tur);

            }
        }
        public void Sil(T data)
        {
            if (data is Yazar yazar)
            {
                Data.Yazarlar.Remove(yazar);
            }
            else if (data is Kitap kitap)
            {
                Data.Kitaplar.Remove(kitap);

            }
            else if (data is Tur tur)
            {
                Data.Turler.Remove(tur);

            }

        }
        public List<T> HepsiniGetir()
        {
            var data = new List<T>();

            if (typeof(T) == typeof(Yazar))
            {
                data = Data.Yazarlar.OfType<T>().ToList();
            }
            else if (typeof(T) == typeof(Kitap))
            {
                data = Data.Kitaplar.OfType<T>().ToList();
            }
            else if (typeof(T) == typeof(Tur))
            {
                data = Data.Turler.OfType<T>().ToList();
            }
            return data;
        }
        public T Getir(Guid id)
        {
            var veri = new BaseModel();

            if (typeof(T) == typeof(Yazar))
            {
                veri = Data.Yazarlar.OfType<T>().ToList().FirstOrDefault(x => x.Id == id);
            }
            else if (typeof(T) == typeof(Kitap))
            {
                veri = Data.Kitaplar.OfType<T>().ToList().FirstOrDefault(x => x.Id == id);
            }
            else if (typeof(T) == typeof(Tur))
            {
                veri = Data.Turler.OfType<T>().ToList().FirstOrDefault(x => x.Id == id);
            }
            return (T)veri;
        }

        public void Guncelle(T data)
        {

            if (data is Yazar Yazar)
            {
                var guncellenecekYazar = Data.Yazarlar.FirstOrDefault(x => x.Id == Yazar.Id);

                var index = Data.Yazarlar.IndexOf(guncellenecekYazar);

                Data.Yazarlar[index] = Yazar;
            }
            else if (data is Kitap kitap)
            {
                var guncellenecekKitap = Data.Kitaplar.FirstOrDefault(x => x.Id == kitap.Id);

                var index = Data.Kitaplar.IndexOf(guncellenecekKitap);

                Data.Kitaplar[index] = kitap;

            }
            else if (data is Tur tur)
            {
                var guncellenecekTur = Data.Turler.FirstOrDefault(x => x.Id == tur.Id);

                var index = Data.Turler.IndexOf(guncellenecekTur);

                Data.Turler[index] = tur;

            }

        }
    }
}
