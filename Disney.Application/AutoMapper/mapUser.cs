using AutoMapper;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;
namespace Disney.Application.AutoMapper
{
    public class mapUser : Profile
    {
        public mapUser()
            => CreateMap<User, UserDTO>().ReverseMap();
    }
}
