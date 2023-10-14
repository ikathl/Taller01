using JazaniTaller.Api.Exceptions;
using JazaniTaller.Application.Admins.Dtos.Users;
using JazaniTaller.Application.Admins.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniTaller.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }



        // POST api/values
        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserSecurityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<BadRequest, Ok<UserSecurityDto>>> Post([FromBody] UserAuthDto userAuth)
        {
            UserSecurityDto userSecurity = await _userService.LoginAsync(userAuth);

            return TypedResults.Ok(userSecurity);
        }
    }
}
