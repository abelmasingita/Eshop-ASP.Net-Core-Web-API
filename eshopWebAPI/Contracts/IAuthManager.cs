using eshopWebAPI.Data.Dto.AppUser;
using eshopWebAPI.Dto.User;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace eshopWebAPI.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(RegisterUserDto registerUserDto);
        Task<bool> Login(LoginDto loginDto);

        List<AppUserDto> GetAllAsync();
        Task<AppUserDto> GetAsync(string? Id);
   
        Task<UpdateUserDto> UpdateAsync(UpdateUserDto updateUserDto);
        Task DeleteAsync(string? Id);
        Task<bool> Exists(string? Id);
    }
}
