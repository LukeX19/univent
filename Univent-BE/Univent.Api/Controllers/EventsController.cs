using Microsoft.AspNetCore.Mvc;
using Univent.Domain.Models;

namespace Univent.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByID(int id)
        {
            var getEvent = new Event { Id = id, Description = "Hello World!" };
            return Ok(getEvent);
        }
    }
}
