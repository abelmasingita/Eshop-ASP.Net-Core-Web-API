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

        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

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
        public IActionResult GetUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
            {
                return NotFound();
            }

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userId));

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] CreateUserDto userCreate)
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
            if (!_userRepository.UserCreate(userMap))
            {
                ModelState.AddModelError("", "Something Went wrong while creating a user");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Created a User");
        }

        [HttpPut("userId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userId, [FromBody] UpdateUserDto updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_userRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userMap = _mapper.Map<User>(updatedUser);
            if (!_userRepository.UserUpdate(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating user");
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return NoContent();
        }

        [HttpDelete("userId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if (!_userRepository.UserExists(userId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedUser = _userRepository.GetUser(userId);

            if (!_userRepository.UserDelete(deletedUser))
            {
                ModelState.AddModelError("", "Something went wrong while deleting a user");
                return StatusCode(500,ModelState);
            }

            return NoContent();
        }
    }
}
