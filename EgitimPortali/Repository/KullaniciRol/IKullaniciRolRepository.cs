using EgitimPortali.Models;

namespace EgitimPortali.Repository.KullaniciRol
{
    public interface IKullaniciRolRepository
    {
        ICollection<KullanicilarinRolleri> KullanicilarinRolleriListele();
        KullanicilarinRolleri KullanicilarinRolleriGetir(int id);
        bool KullanicilarinRolKontrol(int id);
        bool KullanicilarinRolEkle(KullanicilarinRolleri kullanicilarinRolleri);
        bool KullanicilarinRolGuncelle(KullanicilarinRolleri kullanicilarinRolleri);
        bool KullanicilarinRolSil(KullanicilarinRolleri kullanicilarinRolleri);
        bool Kaydet();
    }
}
