using System.Threading.Tasks;
using KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn;
using KnowledgeSystemAPI.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("logIn")]
        [HttpPost]
        public async Task<ActionResult<LogInModelResponse>> LogIn([FromBody] LogInModelRequest user)
        {
            if (user == null)
                return BadRequest("Incorrect data input.");

            var userModel = await _mediator.Send(user);

            if (userModel == null)
                return Unauthorized(user);

            return Ok(new {Token = AuthOptions.GenerateToken(), Model = userModel});
        }
    }
}