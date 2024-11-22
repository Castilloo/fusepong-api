using FusepongAPI.Helpers;
using FusepongAPI.Models;
using FusepongAPI.Models.Dtos;
using FusepongAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FusepongAPI.Controllers
{
    [Route("fusepong")]
    [ApiController]
    public class AuthController : Controller
    {
        public readonly IUserRepository  _repository;
        public readonly IFusepongPMRepository _fusepongRepo;
        public readonly JWTService _jwtService;

        public AuthController(IUserRepository repository, JWTService jwtService, IFusepongPMRepository fusepongRepo)
        {
            _jwtService = jwtService;
            _repository = repository;
            _fusepongRepo = fusepongRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                var companyId = await _repository.GetCompanyIdByName(dto.Company ?? "");
                var user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    CompanyId = companyId,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                };
                var newUser = await _repository.Create(user);
                return Created("Success", newUser);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex);
            }
        }

        [HttpPost("login")]
        public async Task <IActionResult> Login(LoginDto dto)
        {
            try
            {
                var user = await _repository.GetByEmail(dto.Email ?? "");

                if (user == null) return BadRequest(new { message = "Invalid credentials" });

                if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password)) return BadRequest(new { message = "Invalid credentials" });

                var jwt = _jwtService.Generate(user.UserId);

                Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true });



                return Ok(new { message = "success", jwt });                
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex);
            }
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt ?? "");

                int userId = int.Parse(token.Issuer);

                var user = await _repository.GetUserById(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            try 
            {
                Response.Cookies.Delete("jwt");
                return Ok(new { message = "success" });
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex);
            }
        }
    }
} 