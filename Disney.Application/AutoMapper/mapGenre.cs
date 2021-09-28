using AutoMapper;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;

namespace Disney.Application.AutoMapper
{
    public class mapGenre : Profile
    {
        public mapGenre()
            => CreateMap<Genre, GenreDTO>().ReverseMap();
    }
}
