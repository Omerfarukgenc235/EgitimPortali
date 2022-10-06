using EgitimPortali.Models;

namespace EgitimPortali.Repository.Kategori
{
    public interface IKategorilerRepository
    {
        ICollection<Kategoriler> KategorileriListele();
        Kategoriler KategoriGetir(int id);
        bool KategoriKontrol(int id);
        bool KategoriEkle(Kategoriler category);
        bool KategoriGuncelle(Kategoriler category);
        bool KategoriSil(Kategoriler category);
        bool Kaydet();
    }
}
