
using Microsoft.AspNetCore.Identity;
using Talabat.Application.DTO;
using Talabat.Application.Response;

namespace Talabat.Application.Repository.Interfaces
{
    public interface IUserRepository //: Generic<T>
    {
        Task<IdentityResult> AddUser(CreateUserDTO userDTO,List<string>? roles);

        Task<IdentityResult> AddUserRolesAsync(CreateUserDTO userDTO, List<string> roles);


        //public List<ApplicationUser> GetAll();

        //public UpdateUserDTO UpdateUser(UpdateUserDTO userDTO);
        //public bool DeleteUser(int id);

        //public ApplicationUser GetCurrentUser(int id);

    }
}
