using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.DersIcerik
{
    public class DersIcerikRepository : IDersIcerikRepository
    {
        private readonly SqlServerDbContext _context;

        public DersIcerikRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool DersIcerikleriEkle(DersIcerikleri dersIcerikleri)
        {
            _context.DersIcerikleris.Add(dersIcerikleri);
            return Kaydet();
        }

        public DersIcerikleri DersIcerikleriGetir(int id)
        {
            return _context.DersIcerikleris.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool DersIcerikleriGuncelle(DersIcerikleri dersIcerikleri)
        {
            _context.DersIcerikleris.Update(dersIcerikleri);
            return Kaydet();
        }

        public bool DersIcerikleriKontrol(int id)
        {
            return _context.DersIcerikleris.Any(x=>x.Id == id);
        }

        public ICollection<DersIcerikleri> DersIcerikleriniListele()
        {
            return _context.DersIcerikleris.ToList(); 
        }

        public bool DersIcerikleriSil(DersIcerikleri dersIcerikleri)
        {
            _context.DersIcerikleris.Remove(dersIcerikleri);
            return Kaydet();
        }

        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
