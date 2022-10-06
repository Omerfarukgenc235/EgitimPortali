using EgitimPortali.Models;

namespace EgitimPortali.Repository.SoruCevap
{
    public interface ISoruCevapRepository
    {
        ICollection<SorularinCevaplari> SorularinCevaplariListele();
        SorularinCevaplari SorularinCevaplariGetir(int id);
        bool SorularinCevaplariKontrol(int id);
        bool SorularinCevaplariEkle(SorularinCevaplari sorularinCevaplari);
        bool SorularinCevaplariGuncelle(SorularinCevaplari sorularinCevaplari);
        bool SorularinCevaplariSil(SorularinCevaplari sorularinCevaplari);
        bool Kaydet();
    }
}
