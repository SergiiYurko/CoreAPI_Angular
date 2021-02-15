using System.Threading.Tasks;
using KnowledgeSystemAPI.Handlers.Handlers.Profile.GetUserInfo;
using KnowledgeSystemAPI.Handlers.Handlers.Profile.UpdateUserInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("userInfo")]
        public async Task<ActionResult<GetUserInfoModelResponse>> GetUserInfo([FromQuery] GetUserInfoModelRequest model)
        {
            return await _mediator.Send(model);
        }

        [HttpPost]
        public async Task<ActionResult<UpdateUserInfoModelResponse>> UpdateUserInfo(
            [FromBody] UpdateUserInfoModelRequest model)
        {
            return await _mediator.Send(model);
        }
    }
}