using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Konu
{
    public class KonularRepository : IKonularRepository
    {
        private readonly SqlServerDbContext _context;

        public KonularRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool KonuEkle(Konular konular)
        {
            _context.Konulars.Add(konular);
            return Kaydet();
        }

        public Konular KonuGetir(int id)
        {
            return _context.Konulars.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool KonuGuncelle(Konular konular)
        {
            _context.Konulars.Update(konular);
            return Kaydet();
        }

        public bool KonuKontrol(int id)
        {
            return _context.Konulars.Any(x => x.Id == id);
        }

        public ICollection<Konular> KonulariListele()
        {
            return _context.Konulars.ToList();
        }

        public bool KonuSil(Konular konular)
        {
            _context.Konulars.Remove(konular);
            return Kaydet();
        }
    }
}
