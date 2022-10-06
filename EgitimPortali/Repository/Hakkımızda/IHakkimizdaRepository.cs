using EgitimPortali.Models;

namespace EgitimPortali.Repository.Hakkımızda
{
    public interface IHakkimizdaRepository
    {
        ICollection<Hakkimizda> HakkimizdaListele();
        Hakkimizda HakkimizdaGetir(int id);
        bool HakkimizdaKontrol(int id);
        bool HakkimizdaEkle(Hakkimizda hakkimizda);
        bool HakkimizdaGuncelle(Hakkimizda hakkimizda);
        bool HakkimizdaSil(Hakkimizda hakkimizda);
        bool Kaydet();
    }
}
