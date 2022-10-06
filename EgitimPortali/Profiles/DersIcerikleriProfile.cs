using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;

namespace EgitimPortali.Profiles
{
    public class DersIcerikleriProfile : Profile
    {
        public DersIcerikleriProfile()
        {
            CreateMap<DersIcerikleri, DersIcerikleriDto>();
            CreateMap<DersIcerikleriDto, DersIcerikleri>();
        }
    }
}
