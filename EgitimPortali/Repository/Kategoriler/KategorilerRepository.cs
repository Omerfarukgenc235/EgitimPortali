using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Kategori
{
    public class KategorilerRepository : IKategorilerRepository
    {
        private readonly SqlServerDbContext _context;

        public KategorilerRepository(SqlServerDbContext context)
        {
            _context = context;
        }
       
        public bool KategoriEkle(Kategoriler category)
        {
            _context.Kategorilers.Add(category);
            return Kaydet();
        }

        public Kategoriler KategoriGetir(int id)
        {
            return _context.Kategorilers.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool KategoriGuncelle(Kategoriler category)
        {
            _context.Kategorilers.Update(category);
            return Kaydet();
        }

        public bool KategoriKontrol(int id)
        {
            return _context.Kategorilers.Any(x => x.Id == id);
        }

        public ICollection<Kategoriler> KategorileriListele()
        {
            return _context.Kategorilers.ToList();
        }

        public bool KategoriSil(Kategoriler category)
        {
            _context.Kategorilers.Remove(category);
            return Kaydet();
        }

        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}