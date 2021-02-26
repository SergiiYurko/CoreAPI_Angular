using KnowledgeSystemAPI.Handlers.Handlers.Profile.GetUserInfo;
using KnowledgeSystemAPI.Handlers.Handlers.Profile.UpdateUserInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace KnowledgeSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetUserInfoModelResponse>> GetUserInfo([FromQuery] GetUserInfoModelRequest model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<ActionResult<UpdateUserInfoModelResponse>> UpdateUserInfo(
            [FromBody] UpdateUserInfoModelRequest model)
        {
            var response = await _mediator.Send(model);

            if (response == null)
                return BadRequest("The user does not exist.");

            return new ObjectResult(response);
        }
    }
}