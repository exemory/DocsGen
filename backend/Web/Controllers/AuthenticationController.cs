using Core.DTOs;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/auth")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticates user
        /// </summary>
        /// <param name="credentials">Credentials</param>
        /// <returns>Token</returns>
        /// <response code="200">Returns the token</response>
        /// <response code="401">Credentials is not valid</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<TokenDTO> Authenticate([FromBody, Required]CredentialsDTO credentials)
        {
            try
            {
                return _authService.Authenticate(credentials);
            }
            catch (InvalidCredentialsException)
            {
                return Unauthorized();
            }
        }
    }
}
