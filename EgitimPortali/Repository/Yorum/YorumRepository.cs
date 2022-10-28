using AutoMapper;
using EgitimPortali.Context;
using EgitimPortali.DTO;
using EgitimPortali.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.Repository.Yorum
{
    public class YorumRepository : IYorumRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public YorumRepository(SqlServerDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Yorumlar> IcerikYorumlariniListele(int icerikid)
        {
            return _context.Yorumlars.Where(x => x.DersIcerikleriID == icerikid).ToList();
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

        public ICollection<Yorumlar> YorumlariListele()
        {
            return _context.Yorumlars.ToList();
        }
        public ICollection<Yorumlar> DerslereGoreYorumListele()
        {
            return _context.Yorumlars.Include(x => x.DersIcerikleri).ToList();
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