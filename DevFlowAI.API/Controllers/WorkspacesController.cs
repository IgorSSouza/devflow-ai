using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/workspaces")]
public class WorkspacesController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok("Workspace endpoint funcionando");
    }
}