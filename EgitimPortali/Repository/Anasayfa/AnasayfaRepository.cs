using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Anasayfa
{
    public class AnasayfaRepository : IAnasayfaRepository
    {
        private readonly SqlServerDbContext _context;

        public AnasayfaRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool AnaSayfaEkle(AnaSayfa anaSayfa)
        {
            _context.AnaSayfas.Add(anaSayfa);
            return Kaydet();
        }

        public bool AnaSayfaGuncelle(AnaSayfa anaSayfa)
        {
            _context.AnaSayfas.Update(anaSayfa);
            return Kaydet();
        }

        public bool AnaSayfaKontrol(int id)
        {
            return _context.AnaSayfas.Any(x => x.Id == id);
        }

        public ICollection<AnaSayfa> AnaSayfaListele()
        {
            return _context.AnaSayfas.ToList();
        }

        public bool AnaSayfaSil(AnaSayfa anaSayfa)
        {
            _context.AnaSayfas.Remove(anaSayfa);
            return Kaydet();
        }

        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public AnaSayfa AnaSayfaGetir(int id)
        {
            return _context.AnaSayfas.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
