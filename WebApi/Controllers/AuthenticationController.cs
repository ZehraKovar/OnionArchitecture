using Application.Features.Mediator.Authentication.CheckUser;
using Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(CheckUserQuery query)
        {
            var value =await _mediator.Send(query);
            if (value.IsExist)
            {
                return Created("", JwtTokenGenerator.GeneratorToken(value));
            }
            else
            {
                return BadRequest("Kullanıcı veya şifre hatalı!");
            }
        }
    }
}
