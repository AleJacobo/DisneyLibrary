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
    public class mapGenre : Profile
    {
        public mapGenre()
            => CreateMap<Genre, GenreDTO>().ReverseMap();
    }
}
