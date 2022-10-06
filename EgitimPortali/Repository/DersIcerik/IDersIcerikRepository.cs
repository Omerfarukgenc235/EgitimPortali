using EgitimPortali.Models;

namespace EgitimPortali.Repository.DersIcerik
{
    public interface IDersIcerikRepository
    {
        ICollection<DersIcerikleri> DersIcerikleriniListele();
        DersIcerikleri DersIcerikleriGetir(int id);
        bool DersIcerikleriKontrol(int id);
        bool DersIcerikleriEkle(DersIcerikleri dersIcerikleri);
        bool DersIcerikleriGuncelle(DersIcerikleri dersIcerikleri);
        bool DersIcerikleriSil(DersIcerikleri dersIcerikleri);
        bool Kaydet();
    }
}
