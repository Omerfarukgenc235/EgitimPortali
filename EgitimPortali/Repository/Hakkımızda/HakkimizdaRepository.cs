using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Hakkımızda
{
    public class HakkimizdaRepository : IHakkimizdaRepository
    {
        private readonly SqlServerDbContext _context;

        public HakkimizdaRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool HakkimizdaEkle(Hakkimizda hakkimizda)
        {
            _context.Hakkimizdas.Add(hakkimizda);
            return Kaydet();
        }

        public Hakkimizda HakkimizdaGetir(int id)
        {
            return _context.Hakkimizdas.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool HakkimizdaGuncelle(Hakkimizda hakkimizda)
        {
            _context.Hakkimizdas.Update(hakkimizda);
            return Kaydet();
        }

        public bool HakkimizdaKontrol(int id)
        {
            return _context.Hakkimizdas.Any(x => x.Id == id);
        }

        public ICollection<Hakkimizda> HakkimizdaListele()
        {
            return _context.Hakkimizdas.ToList();
        }

        public bool HakkimizdaSil(Hakkimizda hakkimizda)
        {
            _context.Hakkimizdas.Remove(hakkimizda);
            return Kaydet();
        }

        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
