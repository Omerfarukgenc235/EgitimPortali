using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.Yorum
{
    public class YorumRepository : IYorumRepository
    {
        private readonly SqlServerDbContext _context;

        public YorumRepository(SqlServerDbContext context)
        {
            _context = context;
        }
        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool YorumEkle(Yorumlar yorumlar)
        {
            _context.Yorumlars.Add(yorumlar);
            return Kaydet();
        }

        public Yorumlar YorumGetir(int id)
        {
            return _context.Yorumlars.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool YorumGuncelle(Yorumlar yorumlar)
        {
            _context.Yorumlars.Update(yorumlar);
            return Kaydet();
        }

        public ICollection<Yorumlar> YorumiListele()
        {
            return _context.Yorumlars.ToList();
        }

        public bool YorumKontrol(int id)
        {
            return _context.Yorumlars.Any(x=>x.Id == id);
        }

        public bool YorumSil(Yorumlar yorumlar)
        {
            _context.Yorumlars.Remove(yorumlar);
            return Kaydet();
        }
    }
}