using EgitimPortali.Models;

namespace EgitimPortali.Repository.Konu
{
    public interface IKonularRepository
    {
        ICollection<Konular> KonulariListele();
        Konular KonuGetir(int id);
        bool KonuKontrol(int id);
        bool KonuEkle(Konular konular);
        bool KonuGuncelle(Konular konular);
        bool KonuSil(Konular konular);
        bool Kaydet();
    }
}
