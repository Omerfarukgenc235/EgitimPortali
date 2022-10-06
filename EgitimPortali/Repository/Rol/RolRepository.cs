using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Rol
{
    public class RolRepository : IRolRepository
    {
        private readonly SqlServerDbContext _context;

        public RolRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool RolEkle(Roller roller)
        {
            _context.Rollers.Add(roller);
            return Kaydet();
        }

        public Roller RolGetir(int id)
        {
            return _context.Rollers.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool RolGuncelle(Roller roller)
        {
            _context.Rollers.Update(roller);
            return Kaydet();
        }

        public bool RolKontrol(int id)
        {
            return _context.Rollers.Any(x=>x.Id == id);
        }

        public ICollection<Roller> RolleriListele()
        {
            return _context.Rollers.ToList();
        }

        public bool RolSil(Roller roller)
        {
            _context.Rollers.Remove(roller);
            return Kaydet();
        }
    }
}
