using AutoMapper;
using EgitimPortali.Context;
using EgitimPortali.Models;
using EgitimPortali.Request.KullanicilarinRolleri;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.Repository.KullaniciRol
{
    public class KullaniciRolRepository : IKullaniciRolRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public KullaniciRolRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public bool KullanicilarinRolGuncelle(int Id, KullanicilarinRolleriUpdateRequest kullanicilarinRolleri)
        {
            if (kullanicilarinRolleri == null)
            {
                throw new ArgumentNullException(nameof(kullanicilarinRolleri));
                return false;
            }

            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
                return false;
            }

            Models.KullanicilarinRolleri cases = _context.KullanicilarinRolleris.FirstOrDefault(u => u.Id == Id);

            if (cases == null)
            {
                throw new KeyNotFoundException(nameof(Id));
                return false;
            }

            if (kullanicilarinRolleri.KullaniciID != null) cases.KullaniciID = (int)kullanicilarinRolleri.KullaniciID;
            if (kullanicilarinRolleri.RolID != null) cases.RolID = (int)kullanicilarinRolleri.RolID;
         
            _context.Entry(cases).State = EntityState.Modified;
            _mapper.Map(cases, kullanicilarinRolleri);
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
