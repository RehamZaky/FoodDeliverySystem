
using Talabat.Application.DTO;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.Repository.Interfaces;
using AutoMapper;
using Talabat.Application.Response;

namespace Talabat.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository ;
        private readonly IMapper _mapper ;
        public UserService(IUserRepository userRepository,IMapper mapper) {
            _userRepository = userRepository ;
            _mapper = mapper ;
        }
        public async Task<ApiResponse<UserResponseDTO>> AddUser(CreateUserDTO userDTO,List<string>? roles)
        {
          var userResult = await  _userRepository.AddUser(userDTO,roles);

            if (userResult.Errors.ToList().Count > 0)
            {
                List<string> errors = new List<string>();
                userResult.Errors.ToList().ForEach(error =>
                {
                    errors.Add(error.Description);
                });
                var response = new ApiResponse<UserResponseDTO>(errors, "");
                return response;
            }
           var userResponseDTO = _mapper.Map<UserResponseDTO>(userResult);
            return new ApiResponse<UserResponseDTO>(userResponseDTO!,"200","Success");
        }

        public async Task<bool> AddUserRoles(CreateUserDTO userDTO, List<string> roles)
        {
            var userResult = await _userRepository.AddUserRolesAsync(userDTO, roles);
            if(userResult.Errors.ToList().Count > 0) { return false; }
            return true;
        }

    }
}
