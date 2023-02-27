using AutoMapper;
using eshopWebAPI.Contracts;
using eshopWebAPI.Data.Dto.AppUser;
using eshopWebAPI.Data.Dto.Order;
using eshopWebAPI.Dto.Product;
using eshopWebAPI.Dto.User;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;
using eshopWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;



namespace eshopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly IAuthManager _authManager;
        private readonly IMapper _mapper;

        public UserManagerController(IAuthManager authManager,IMapper mapper)
        {
            _authManager = authManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            if (registerUserDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var errors = await _authManager.Register(registerUserDto);

            if (errors.Any())
            {
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok("User Created!");
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authManager.Login(loginDto);

            if (result is true)
            {
                return Ok("User Loged In!");
            }

            return Ok("User Not logged in!");
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AppUserDto>))]
        public IActionResult GetUsers()
        {
            var users = _authManager.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("userId")]
        [ProducesResponseType(200, Type = typeof(AppUserDto))]
        [ProducesResponseType(400, Type = typeof(AppUserDto))]
        [ProducesResponseType(404, Type = typeof(AppUserDto))]
        public async Task<IActionResult> GetUserById(string userId)
        {

            if (!await _authManager.Exists(userId))
            {
                return NotFound();
            }
            var user = await _authManager.GetAsync(userId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }


        [HttpPut("userId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateUserDto updateUserDto)
        {

            if (updateUserDto == null)
            {
                return BadRequest(ModelState);
            }

            if (userId != updateUserDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _authManager.Exists(userId))
            {
                return NotFound();
            }
            var user = await _authManager.GetAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
           // _mapper.Map(updateUserDto, user);
           var updatedUser =  await _authManager.UpdateAsync(updateUserDto);

            return Ok(updatedUser);
        }



        [HttpDelete("userId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(string userId)
        {

            if (!await _authManager.Exists(userId))
            {
                return NotFound();
            }
            await _authManager.DeleteAsync(userId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
