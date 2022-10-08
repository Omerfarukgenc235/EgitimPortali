using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;

namespace EgitimPortali.Profiles
{
    public class SorularProfile : Profile
    {
        public SorularProfile()
        {
            CreateMap<Sorular, SorularDto>();
            CreateMap<SorularDto, Sorular>();
        }
    }
}
