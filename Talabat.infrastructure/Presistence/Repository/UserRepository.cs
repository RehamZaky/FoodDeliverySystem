using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using Talabat.Application.DTO;
using Talabat.Application.Repository.Interfaces;
using Talabat.Application.Response;
using Talabat.Infrastructure.Data;

namespace Talabat.Infrastructure.Presistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDBContext dbContext, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            context = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserResponseDTO> AddUserWithRole(CreateUserDTO userDTO, string role)
        {
            var appUser = _mapper.Map<ApplicationUser>(userDTO);
            IdentityResult user = await _userManager.CreateAsync(appUser, userDTO.Password);
            var userWithRole = await _userManager.AddToRoleAsync(appUser, role);
            return _mapper.Map<UserResponseDTO>(userWithRole);
        }

        //public async Task<ApiResponse<UserResponseDTO>> AddUser(CreateUserDTO userDTO, List<string>? roles)
        //{
        //    // map userDTO to ApplicationUser
        //    var appUser = _mapper.Map<ApplicationUser>(userDTO);
        //    appUser.UserName = appUser.FirstName + appUser.LastName;
        //    appUser.CreateAt = DateTime.Now;

        //    IdentityResult user = await _userManager.CreateAsync(appUser, userDTO.Password);
        //    if(user.Errors.ToList().Count >0)
        //    {
        //        List<string> errors = new List<string>();
        //        user.Errors.ToList().ForEach(error => {
        //            errors.Add(error.Description);
        //        });
        //        var response = new ApiResponse<UserResponseDTO>(errors,"");
        //        return response;
        //    }
        //    if (roles != null)
        //    {
        //        user = await _userManager.AddToRolesAsync(appUser, roles);
        //    }

        //    var userResponseDto = _mapper.Map<UserResponseDTO>(appUser);
        //    return new ApiResponse<UserResponseDTO>( userResponseDto,"200") ;

        //}

        public async Task<IdentityResult> AddUser(CreateUserDTO userDTO, List<string>? roles)
        {
            var user = _mapper.Map<ApplicationUser>(userDTO);
            user.UserName = user.FirstName + user.LastName;

            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if(result.Succeeded)
            {
                if (roles != null)
                {
                    var userRoleResult = await _userManager.AddToRolesAsync(user, roles);
                    return userRoleResult;
                }
            }
            return result;
        }

        public async Task<IdentityResult> AddUserRolesAsync(CreateUserDTO userDTO, List<string> roles)
        {
            var user = _mapper.Map<ApplicationUser>(userDTO);
            return await _userManager.AddToRolesAsync(user, roles);
        }

        public async Task<bool> AddUserClaims(CreateUserDTO userDTO,List<Claim> claims)
        {
            var appUser = _mapper.Map<ApplicationUser>(userDTO);

            var user = await _userManager.AddClaimsAsync(appUser, claims);
            if (user == null)
                return false;
            else
                return true;


        }
    }
}
