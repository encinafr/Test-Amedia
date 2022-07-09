

using ApiTest.Dtos;
using ApiTest.EF.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("account/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var result = await _userRepository.Login(loginDto.User, loginDto.Password);

            if (result == null)
            {
                return BadRequest("Usuario/Contraseña/Cuit Inválidos.");
            }

            return _mapper.Map<UserDto>(result);
        }
    }
}
