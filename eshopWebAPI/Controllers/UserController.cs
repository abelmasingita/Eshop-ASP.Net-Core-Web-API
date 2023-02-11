using AutoMapper;
using eshopWebAPI.Dto.User;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshopWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(400, Type = typeof(IEnumerable<UserDto>))]

        public async Task<IActionResult> GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(await _userRepository.GetAllAsync());

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(users);
        }

        [HttpGet("userId")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400, Type = typeof(UserDto))]
        [ProducesResponseType(404, Type = typeof(UserDto))]
        public async Task<IActionResult> GetUser(int userId)
        {
            if (!await _userRepository.Exists(userId))
            {
                return NotFound();
            }

            var user = _mapper.Map<UserDto>(await _userRepository.GetAsync(userId));

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateUserDto))]
        [ProducesResponseType(400, Type = typeof(CreateUserDto))]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userMap = _mapper.Map<User>(userCreate);
           
            return Ok(await _userRepository.AddAsync(userMap));
        }

        [HttpPut("userId")]
        [ProducesResponseType(204, Type = typeof(UpdateUserDto))]
        [ProducesResponseType(400, Type = typeof(UpdateUserDto))]
        [ProducesResponseType(404, Type = typeof(UpdateUserDto))]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserDto updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest(ModelState);
            }

            if (userId != updatedUser.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userRepository.Exists(userId))
            {
                return NotFound();
            }
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            _mapper.Map(updatedUser,user);
            await _userRepository.UpdateAsync(user);
    
            return NoContent();
        }

        [HttpDelete("userId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (!await _userRepository.Exists(userId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.DeleteAsync(userId);
    
            return NoContent();
        }
    }
}
