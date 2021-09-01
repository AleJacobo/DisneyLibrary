using AutoMapper;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class UsersServices
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository<User> baseRepository;
        public UsersServices(IMapper mapper, IBaseRepository<User> baseRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
        }


    }
}
