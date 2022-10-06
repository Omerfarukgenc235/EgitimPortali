using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;

namespace EgitimPortali.Profiles
{
    public class KategoriProfile : Profile
    {
        public KategoriProfile()
        {
            CreateMap<Kategoriler, KategoriDto>();
            CreateMap<KategoriDto, Kategoriler>();       
        }
    }
}
