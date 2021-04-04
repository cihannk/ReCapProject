using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDTO userForLoginDTO)
        {
            var userToLogin = _authService.Login(userForLoginDTO);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            } 
            var result = _authService.CreateAccessToken(userToLogin.Data);

            if (result.Success)
            {
                return Ok(result);
            } 
            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDTO userForRegister)
        {
            var user = _authService.Register(userForRegister, userForRegister.Password);
            if (!user.Success)
            {
                return BadRequest(user.Message);
            }

            var result = _authService.CreateAccessToken(user.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Data);

            
        }

    }
}
