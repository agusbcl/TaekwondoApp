using AutoMapper;
using Domain.Entities;
using DTOs.News;

namespace Mappings.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<UpdateNewsDto, News>().ReverseMap();
            CreateMap<News, GetNewsDto>();
        }
    }
}
