using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;

namespace EgitimPortali.Profiles
{
    public class DerslerProfile : Profile
    {
        public DerslerProfile()
        {
            CreateMap<Dersler, DerslerDto>();
            CreateMap<DerslerDto, Dersler>();
        }
    }
}
