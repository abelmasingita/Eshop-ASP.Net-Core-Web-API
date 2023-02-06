using AutoMapper;
using eshopWebAPI.Dto;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshopWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
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
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
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
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userCreate)
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
    }
}
