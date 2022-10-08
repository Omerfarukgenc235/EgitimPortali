using AutoMapper;
using EgitimPortali.Context;
using EgitimPortali.Models;
using EgitimPortali.Request.Kullanicilar;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.Repository.Kullanici
{
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public KullaniciRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public bool KullaniciGuncelle(int Id,KullanicilarUpdateRequest kullanicilar)
        {
            if (kullanicilar == null)
            {
                throw new ArgumentNullException(nameof(kullanicilar));
                return false;
            }

            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
                return false;
            }

            Models.Kullanicilar cases = _context.Kullanicilars.FirstOrDefault(u => u.Id == Id);

            if (cases == null)
            {
                throw new KeyNotFoundException(nameof(Id));
                return false;
            }

            if (kullanicilar.Ad != null) cases.Ad = kullanicilar.Ad;
            if (kullanicilar.Soyad != null) cases.Soyad = kullanicilar.Soyad;
            if (kullanicilar.Mail != null) cases.Mail = kullanicilar.Mail;
            if (kullanicilar.Sifre != null) cases.Sifre = kullanicilar.Sifre;
            _context.Entry(cases).State = EntityState.Modified;
            _mapper.Map(cases, kullanicilar);
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
