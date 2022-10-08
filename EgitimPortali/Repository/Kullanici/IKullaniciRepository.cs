using EgitimPortali.Models;
using EgitimPortali.Request.Kullanicilar;

namespace EgitimPortali.Repository.Kullanici
{
    public interface IKullaniciRepository
    {
        ICollection<Kullanicilar> KullanicilariListele();
        Kullanicilar KullaniciGetir(int id);
        bool KullaniciKontrol(int id);
        bool KullaniciEkle(Kullanicilar kullanicilar);
        bool KullaniciGuncelle(int Id,KullanicilarUpdateRequest kullanicilar);
        bool KullaniciSil(Kullanicilar kullanicilar);
        bool Kaydet();
    }
}
