using EgitimPortali.Context;
using EgitimPortali.Models;

namespace EgitimPortali.Repository.SoruCevap
{
    public class SoruCevapRepository : ISoruCevapRepository
    {
        private readonly SqlServerDbContext _context;

        public SoruCevapRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public ICollection<SorularinCevaplari> CevaplariSoralaraGoreGetir(int id)
        {
            return _context.SorularinCevaplaris.Where(x => x.SorularID == id).ToList();
        }

        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool SorularinCevaplariEkle(SorularinCevaplari sorularinCevaplari)
        {
            _context.SorularinCevaplaris.Add(sorularinCevaplari);
            return Kaydet();
        }

        public SorularinCevaplari SorularinCevaplariGetir(int id)
        {
            return _context.SorularinCevaplaris.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool SorularinCevaplariGuncelle(SorularinCevaplari sorularinCevaplari)
        {
            _context.SorularinCevaplaris.Update(sorularinCevaplari);
            return Kaydet();
        }

        public bool SorularinCevaplariKontrol(int id)
        {
            return _context.SorularinCevaplaris.Any(x=>x.Id == id);
        }

        public ICollection<SorularinCevaplari> SorularinCevaplariListele()
        {
            return _context.SorularinCevaplaris.ToList();
        }

        public bool SorularinCevaplariSil(SorularinCevaplari sorularinCevaplari)
        {
            _context.SorularinCevaplaris.Remove(sorularinCevaplari);
            return Kaydet();
        }
    }
}
