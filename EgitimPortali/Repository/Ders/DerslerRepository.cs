using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Ders
{
    public class DerslerRepository : IDerslerRepository
    {
        private readonly SqlServerDbContext _context;

        public DerslerRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool DersEkle(Dersler dersler)
        {
            _context.Derslers.Add(dersler);
            return Kaydet();
        }

        public Dersler DersGetir(int id)
        {
            return _context.Derslers.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool DersGuncelle(Dersler dersler)
        {
            _context.Derslers.Update(dersler);
            return Kaydet();
        }

        public bool DersKontrol(int id)
        {
            return _context.Derslers.Any(x => x.Id == id);
        }

        public ICollection<Dersler> DersleriListele()
        {
            return _context.Derslers.ToList();
        }

        public bool DersSil(Dersler dersler)
        {
            _context.Derslers.Remove(dersler);
            return Kaydet();
        }

        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
