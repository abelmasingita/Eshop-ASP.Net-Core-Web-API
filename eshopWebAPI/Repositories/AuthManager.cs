using AutoMapper;
using eshopWebAPI.Contracts;
using eshopWebAPI.Data.Dto.AppUser;
using eshopWebAPI.Dto.User;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eshopWebAPI.Repositories
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthManager(UserManager<AppUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task DeleteAsync(string? Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            IdentityResult result = await _userManager.DeleteAsync(user);
            //return result;
        }

        public async Task<bool> Exists(string? Id)
        {
            var entity = await GetAsync(Id);
            return entity != null;
        }

        public List<AppUserDto> GetAllAsync()
        {
            var users = _mapper.Map<List<AppUserDto>>( _userManager.Users);
            return users;
        }

        public async Task<AppUserDto> GetAsync(string? Id)
        {
            if (Id == null)
            {
                return null;
            }
            var user = _mapper.Map<AppUserDto>(await _userManager.FindByIdAsync(Id));
            return user;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (isValidUser)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<IdentityError>> Register(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<AppUser>(registerUserDto);
            user.UserName = registerUserDto.Email;

            var result = await _userManager.CreateAsync(user, registerUserDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }

        public async Task<UpdateUserDto> UpdateAsync(UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<AppUser>(updateUserDto);

            IdentityResult result = await _userManager.UpdateAsync(user);

            return updateUserDto;
        }
    }
}
