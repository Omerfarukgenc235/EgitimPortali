using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Reklam
{
    public class ReklamRepository : IReklamRepository
    {
        private readonly SqlServerDbContext _context;

        public ReklamRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ReklamEkle(Reklamlar reklam)
        {
            _context.Reklamlars.Add(reklam);
            return Kaydet();
        }

        public Reklamlar ReklamGetir(int id)
        {
            return _context.Reklamlars.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool ReklamGuncelle(Reklamlar reklam)
        {
            _context.Reklamlars.Update(reklam);
            return Kaydet();
        }

        public bool ReklamKontrol(int id)
        {
           return _context.Reklamlars.Any(x => x.Id == id);
        }

        public ICollection<Reklamlar> ReklamlariListele()
        {
            return _context.Reklamlars.ToList();
        }

        public bool ReklamSil(Reklamlar reklam)
        {
            _context.Reklamlars.Remove(reklam);
            return Kaydet();
        }
    }
}
