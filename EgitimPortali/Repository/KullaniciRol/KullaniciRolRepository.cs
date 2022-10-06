using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.KullaniciRol
{
    public class KullaniciRolRepository : IKullaniciRolRepository
    {
        private readonly SqlServerDbContext _context;

        public KullaniciRolRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool KullanicilarinRolEkle(KullanicilarinRolleri kullanicilarinRolleri)
        {
            _context.KullanicilarinRolleris.Add(kullanicilarinRolleri);
            return Kaydet();
        }

        public bool KullanicilarinRolGuncelle(KullanicilarinRolleri kullanicilarinRolleri)
        {
            _context.KullanicilarinRolleris.Update(kullanicilarinRolleri);
            return Kaydet();
        }

        public bool KullanicilarinRolKontrol(int id)
        {
            return _context.KullanicilarinRolleris.Any(x=>x.Id == id);
        }

        public KullanicilarinRolleri KullanicilarinRolleriGetir(int id)
        {
            return _context.KullanicilarinRolleris.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<KullanicilarinRolleri> KullanicilarinRolleriListele()
        {
            return _context.KullanicilarinRolleris.ToList();
        }

        public bool KullanicilarinRolSil(KullanicilarinRolleri kullanicilarinRolleri)
        {
            _context.KullanicilarinRolleris.Remove(kullanicilarinRolleri);
            return Kaydet();
        }
    }
}
