using EgitimPortali.Models;

namespace EgitimPortali.Repository.Reklam
{
    public interface IReklamRepository
    {
        ICollection<Reklamlar> ReklamlariListele();
        Reklamlar ReklamGetir(int id);
        bool ReklamKontrol(int id);
        bool ReklamEkle(Reklamlar reklam);
        bool ReklamGuncelle(Reklamlar reklam);
        bool ReklamSil(Reklamlar reklam);
        bool Kaydet();
    }
}
