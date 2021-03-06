using AutoMapper;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;

namespace Disney.Application.AutoMapper
{
    public class mapMovieSerie : Profile
    {
        public mapMovieSerie()
            => CreateMap<MovieSerie, MovieSerieDTO>().ReverseMap();
    }
}
