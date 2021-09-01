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
    public class CharactersServices
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository<Genres> baseRepository;
        private readonly CharactersRepository charactersRepository;

        public CharactersServices(IMapper mapper, IBaseRepository<Genres> baseRepository, CharactersRepository charactersRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
            this.charactersRepository = charactersRepository;
        }




    }
}
