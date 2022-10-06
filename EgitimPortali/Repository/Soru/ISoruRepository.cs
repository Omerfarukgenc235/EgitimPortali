using EgitimPortali.Models;

namespace EgitimPortali.Repository.Soru
{
    public interface ISoruRepository
    {
        ICollection<Sorular> SorulariListele();
        Sorular SoruGetir(int id);
        bool SoruKontrol(int id);
        bool SoruEkle(Sorular sorular);
        bool SoruGuncelle(Sorular sorular);
        bool SoruSil(Sorular sorular);
        bool Kaydet();
    }
}
