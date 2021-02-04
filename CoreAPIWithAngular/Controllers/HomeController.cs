using System.Threading.Tasks;
using KnowledgeSystemAPI.Handlers.Handlers.Home;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController: ControllerBase
    {
        private readonly IMediator _mediator;
        
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("getUser")]
        [HttpGet]
        public async Task<ActionResult<UserResponseModel>> GetUser([FromQuery]UserRequestModel user)
        {
            var result = await _mediator.Send(user);
           
            if (result == null)
                return NotFound(user);

            return result;
        }
    }
}