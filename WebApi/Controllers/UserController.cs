using Application.Features.Mediator.Book.AddBook;
using Application.Features.Mediator.User.AddUser;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("");
        }
    }
}
