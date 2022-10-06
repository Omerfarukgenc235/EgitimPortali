using EgitimPortali.Models;

namespace EgitimPortali.Repository.Kullanici
{
    public interface IKullaniciRepository
    {
        ICollection<Kullanicilar> KullanicilariListele();
        Kullanicilar KullaniciGetir(int id);
        bool KullaniciKontrol(int id);
        bool KullaniciEkle(Kullanicilar kullanicilar);
        bool KullaniciGuncelle(Kullanicilar kullanicilar);
        bool KullaniciSil(Kullanicilar kullanicilar);
        bool Kaydet();
    }
}
