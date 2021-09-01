using AutoMapper;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using Disney.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class GenresServices
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository<Genre> baseRepository;
        private readonly GenresRepository genreRepository;

        public GenresServices(IMapper mapper, IBaseRepository<Genre> baseRepository, GenresRepository genresRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
            this.genreRepository = genresRepository;
        }


    }
}
