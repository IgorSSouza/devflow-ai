using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFlowAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Task endpoint funcionando");
        }
    }
}
