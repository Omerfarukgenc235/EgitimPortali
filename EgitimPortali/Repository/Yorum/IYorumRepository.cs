using EgitimPortali.Models;

namespace EgitimPortali.Repository.Yorum
{
    public interface IYorumRepository
    {
        ICollection<Yorumlar> YorumiListele();
        Yorumlar YorumGetir(int id);
        bool YorumKontrol(int id);
        bool YorumEkle(Yorumlar yorumlar);
        bool YorumGuncelle(Yorumlar yorumlar);
        bool YorumSil(Yorumlar yorumlar);
        bool Kaydet();
    }
}
