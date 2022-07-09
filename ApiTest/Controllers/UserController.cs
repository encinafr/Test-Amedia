using ApiTest.Dtos;
using ApiTest.EF.Interfaces;
using ApiTest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAll();

            var results = _mapper.Map<List<UserDto>>(users);

            return Ok(results);
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userRepository.GetById(id);

            var result = _mapper.Map<UserDto>(user);

            return Ok(result);
        }

        [HttpPost]  
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            if (user == null)
                return BadRequest();    

            var userToAdd = _mapper.Map<User>(user);

             var result = await _userRepository.Add(userToAdd);

            return result >= 0 ? Ok() : BadRequest();
        }
        
        [HttpPost("{id}")]  
        public async Task<IActionResult> Post(int id, [FromBody] UserDto user)
        {
            if (user == null)
                return BadRequest();    

            var userToAdd = _mapper.Map<User>(user);

            _userRepository.Update(id, userToAdd);

            return Ok();
        }

    }
}
