using EgitimPortali.Models;

namespace EgitimPortali.Repository.Ders
{
    public interface IDerslerRepository
    {
        ICollection<Dersler> DersleriListele();
        Dersler DersGetir(int id);
        bool DersKontrol(int id);
        bool DersEkle(Dersler dersler);
        bool DersGuncelle(Dersler dersler);
        bool DersSil(Dersler dersler);
        bool Kaydet();
    }
}
