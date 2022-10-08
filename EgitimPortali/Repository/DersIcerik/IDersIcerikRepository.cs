using EgitimPortali.Models;
using EgitimPortali.Request.DersIcerikleri;

namespace EgitimPortali.Repository.DersIcerik
{
    public interface IDersIcerikRepository
    {
        ICollection<DersIcerikleri> DersIcerikleriniListele();
        DersIcerikleri DersIcerikleriGetir(int id);
        bool DersIcerikleriKontrol(int id);
        bool DersIcerikleriEkle(DersIcerikleri dersIcerikleri);
        bool DersIcerikleriGuncelle(int Id, DersIcerikleriUpdateRequest dersIcerikleri);
        bool DersIcerikleriSil(DersIcerikleri dersIcerikleri);
        bool Kaydet();
    }
}
