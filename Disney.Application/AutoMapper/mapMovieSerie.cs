using AutoMapper;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.AutoMapper
{
    public class mapMovieSerie :Profile
    {
        public mapMovieSerie()
            => CreateMap<MovieSerie, MovieSerieDTO>().ReverseMap();
    }
}
