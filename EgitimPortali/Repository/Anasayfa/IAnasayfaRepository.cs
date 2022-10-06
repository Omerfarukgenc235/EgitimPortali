using EgitimPortali.Models;

namespace EgitimPortali.Repository.Anasayfa
{
    public interface IAnasayfaRepository
    {
        ICollection<AnaSayfa> AnaSayfaListele();
        AnaSayfa AnaSayfaGetir(int id);
        bool AnaSayfaKontrol(int id);
        bool AnaSayfaEkle(AnaSayfa anaSayfa);
        bool AnaSayfaGuncelle(AnaSayfa anaSayfa);
        bool AnaSayfaSil(AnaSayfa anaSayfa);
        bool Kaydet();
    }
}
