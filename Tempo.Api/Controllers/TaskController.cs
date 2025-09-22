using Microsoft.AspNetCore.Mvc;
using Tempo.Core.Requests;
using Tempo.Core.Responses;
using Tempo.Core.Services;

namespace Tempo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITasItemService _tasItemService;

    public TaskController(ITasItemService tasItemService)
    {
        _tasItemService = tasItemService;
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> CreateTask(CreateTaskRequest request)
    {
        var task = await _tasItemService.CreateTask(request);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskResponse>> GetTask(int id)
    {
        var task = await _tasItemService.GetTask(id);
        if (task == null)
            return NotFound();
        return Ok(task);
    }
}
