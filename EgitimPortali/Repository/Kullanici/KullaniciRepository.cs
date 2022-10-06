using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Kullanici
{
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly SqlServerDbContext _context;

        public KullaniciRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool KullaniciEkle(Kullanicilar kullanicilar)
        {
            _context.Kullanicilars.Add(kullanicilar);
            return Kaydet();
        }

        public Kullanicilar KullaniciGetir(int id)
        {
            return _context.Kullanicilars.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool KullaniciGuncelle(Kullanicilar kullanicilar)
        {
            _context.Kullanicilars.Update(kullanicilar);
            return Kaydet();
        }

        public bool KullaniciKontrol(int id)
        {
            return _context.Kullanicilars.Any(x=>x.Id == id);
        }

        public ICollection<Kullanicilar> KullanicilariListele()
        {
            return _context.Kullanicilars.ToList();
        }

        public bool KullaniciSil(Kullanicilar kullanicilar)
        {
            _context.Kullanicilars.Remove(kullanicilar);
            return Kaydet();
        }
    }
}
