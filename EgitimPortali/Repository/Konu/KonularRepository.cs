using AutoMapper;
using EgitimPortali.Context;
using EgitimPortali.Models;
using EgitimPortali.Request.Konular;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.Repository.Konu
{
    public class KonularRepository : IKonularRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public KonularRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Kaydet()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool KonuEkle(Konular konular)
        {
            _context.Konulars.Add(konular);
            return Kaydet();
        }

        public Konular KonuGetir(int id)
        {
            return _context.Konulars.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool KonuGuncelle(int Id,KonularUpdateRequest konular)
        {
            if (konular == null)
            {
                throw new ArgumentNullException(nameof(konular));
                return false;
            }

            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
                return false;
            }

            Models.Konular cases = _context.Konulars.FirstOrDefault(u => u.Id == Id);

            if (cases == null)
            {
                throw new KeyNotFoundException(nameof(Id));
                return false;
            }

            if (konular.Name != null) cases.Name = konular.Name;
            if (konular.DerslerID != null) cases.DerslerID = (int)konular.DerslerID;
            _context.Entry(cases).State = EntityState.Modified;
            _mapper.Map(cases, konular);
            return Kaydet();
        }

        public bool KonuKontrol(int id)
        {
            return _context.Konulars.Any(x => x.Id == id);
        }

        public ICollection<Konular> KonulariListele()
        {
            return _context.Konulars.ToList();
        }

        public bool KonuSil(Konular konular)
        {
            _context.Konulars.Remove(konular);
            return Kaydet();
        }
    }
}
