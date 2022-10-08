using EgitimPortali.Models;
using EgitimPortali.Request.KullanicilarinRolleri;

namespace EgitimPortali.Repository.KullaniciRol
{
    public interface IKullaniciRolRepository
    {
        ICollection<KullanicilarinRolleri> KullanicilarinRolleriListele();
        KullanicilarinRolleri KullanicilarinRolleriGetir(int id);
        bool KullanicilarinRolKontrol(int id);
        bool KullanicilarinRolEkle(KullanicilarinRolleri kullanicilarinRolleri);
        bool KullanicilarinRolGuncelle(int Id,KullanicilarinRolleriUpdateRequest kullanicilarinRolleri);
        bool KullanicilarinRolSil(KullanicilarinRolleri kullanicilarinRolleri);
        bool Kaydet();
    }
}
