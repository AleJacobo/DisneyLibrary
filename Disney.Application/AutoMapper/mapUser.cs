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
    public class mapUser : Profile
    {
        public mapUser()
            => CreateMap<User, UserDTO>().ReverseMap();
    }
}
