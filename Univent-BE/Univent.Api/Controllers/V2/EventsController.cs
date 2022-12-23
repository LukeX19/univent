using Microsoft.AspNetCore.Mvc;
using Univent.Domain.Models;

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
            var getEvent = new Event { Id = id, Description = "Hello World2!" };
            return Ok(getEvent);
        }
    }
}
