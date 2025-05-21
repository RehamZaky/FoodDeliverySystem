

using Talabat.Application.DTO;
using Talabat.Application.Response;

namespace Talabat.Application.Contracts.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<UserResponseDTO>> AddUser(CreateUserDTO userDTO,List<string>? roles = null);

     //   Task<UserResponseDTO> AddUserWithRole(CreateUserDTO userDTO, string role);

        Task<bool> AddUserRoles(CreateUserDTO userDTO, List<string> roles);

    }
}
