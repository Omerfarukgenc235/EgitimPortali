using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Soru
{
    public class SoruRepository : ISoruRepository
    {
        private readonly SqlServerDbContext _context;

        public SoruRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool SoruEkle(Sorular sorular)
        {
            _context.Sorulars.Add(sorular);
            return Kaydet();
        }

        public Sorular SoruGetir(int id)
        {
            return _context.Sorulars.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool SoruGuncelle(Sorular sorular)
        {
            _context.Sorulars.Update(sorular);
            return Kaydet();
        }

        public bool SoruKontrol(int id)
        {
            return _context.Sorulars.Any(x => x.Id == id);
        }

        public ICollection<Sorular> SorulariListele()
        {
            return _context.Sorulars.ToList();
        }

        public bool SoruSil(Sorular sorular)
        {
            _context.Sorulars.Remove(sorular);
            return Kaydet();
        }
    }
}
