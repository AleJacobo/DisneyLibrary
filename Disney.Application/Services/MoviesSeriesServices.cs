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
    public class MoviesSeriesServices
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository<MovieSerie> baseRepository;
        private readonly MoviesSeriesRepository moviesSeriesRepository;

        public MoviesSeriesServices(IMapper mapper, IBaseRepository<MovieSerie> baseRepository, MoviesSeriesRepository moviesSeriesRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
            this.moviesSeriesRepository = moviesSeriesRepository;
        }


    }
}
