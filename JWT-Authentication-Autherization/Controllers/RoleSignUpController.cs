using JWT_Authentication_Autherization.CustomFiles;
using JWT_Authentication_Autherization.Models;
using JWT_Authentication_Autherization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace JWT_Authentication_Autherization.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class RoleSignUpController : ControllerBase
    {
        private readonly LoginService _loginService;

        public RoleSignUpController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("GetAllRoles")]
        public IActionResult Get()
        {
            try
            {
                var roles = _loginService.GetAllRole();
                if (roles == null)
                {
                    return NotFound();
                }
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateRoles")]
        public IActionResult CreateRoles(CreateRoleDTO role)
        {
            try
            {
                var roles = _loginService.CreateRole(role);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _loginService.GetAllLogin();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateUsers")]
        public IActionResult CreateUsers([FromBody] CreateUserDTO userDTO)
        {
            try
            {
                var users = _loginService.CreateUser(userDTO);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
