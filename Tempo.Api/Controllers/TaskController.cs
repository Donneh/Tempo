using Microsoft.AspNetCore.Mvc;
using Tempo.Core.Requests;
using Tempo.Core.Responses;
using Tempo.Core.Services;

namespace Tempo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(ITaskItemService taskItemService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TaskResponse>> CreateTask(CreateTaskRequest request)
    {
        var task = await taskItemService.CreateTask(request);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskResponse>> GetTask(int id)
    {
        var task = await taskItemService.GetTask(id);
        if (task == null)
            return NotFound();
        return Ok(task);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskResponse>>> GetTasks()
    {
        var tasks = await taskItemService.GetAllTasks();
        return Ok(tasks);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteTask(int id)
    {
        var deleted = await taskItemService.DeleteTask(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
