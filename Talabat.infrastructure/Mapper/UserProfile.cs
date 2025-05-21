using AutoMapper;
using Talabat.Application.DTO;
using Talabat.Infrastructure.Data;

namespace Talabat.Infrastructure.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO,ApplicationUser>().ReverseMap();
            CreateMap<UserResponseDTO,ApplicationUser>().ReverseMap();
        }
    }
}
