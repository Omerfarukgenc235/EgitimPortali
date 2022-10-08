using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;
using EgitimPortali.Request.Kullanicilar;

namespace EgitimPortali.Profiles
{
    public class KullaniciProfile : Profile
    {
        public KullaniciProfile()
        {
            CreateMap<Kullanicilar, KullaniciDto>();
            CreateMap<KullaniciDto, Kullanicilar>();
            CreateMap<Kullanicilar, KullanicilarUpdateRequest>();
            CreateMap<Kullanicilar, KullanicilarPostRequest>();
            CreateMap<KullanicilarPostRequest, Kullanicilar>();
        }
    }
}
