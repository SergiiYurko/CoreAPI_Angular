using System.Threading.Tasks;
using KnowledgeSystemAPI.Handlers.Handlers.Account.LogIn;
using KnowledgeSystemAPI.Handlers.Handlers.Home;
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

        [Route("getUser")]
        [HttpGet]
        public async Task<ActionResult<UserResponseModel>> GetUser([FromQuery] UserRequestModel user)
        {
            var result = await _mediator.Send(user);

            if (result == null)
                return NotFound(user);

            return result;
        }

        [Route("logIn")]
        [HttpPost]
        public async Task<ActionResult<LogInModelResponse>> LogIn([FromBody] LogInModelRequest user)
        {
            var result = await _mediator.Send(user);
            return result;
        }
    }
}