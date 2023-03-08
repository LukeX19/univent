using Microsoft.AspNetCore.Mvc;

namespace Univent.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok();
        }
    }
}
