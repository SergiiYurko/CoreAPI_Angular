using KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn;
using KnowledgeSystemAPI.Handlers.Handlers.Account.SignUp;
using KnowledgeSystemAPI.Handlers.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var userModel = await _mediator.Send(user);

            if (userModel == null)
                return BadRequest("A user with such credentials doesn't exist.");

            return Ok(new {Token = AuthOptions.GenerateToken(userModel.Name, userModel.RoleType), Model = userModel});
        }

        [Route("signUp")]
        [HttpPost]
        public async Task<ActionResult<SignUpModelResponse>> SignUp([FromBody] SignUpModelRequest user)
        {
            var userModel = await _mediator.Send(user);

            if (userModel == null)
                return BadRequest("User is already exist.");

            return Ok("Successfully registered.");
        }
    }
}