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

    [HttpGet("date/{date}")]
    public async Task<ActionResult<IEnumerable<TaskResponse>>> GetTasksByDate(DateOnly date)
    {
        var tasks = await taskItemService.GetTasksByDate(date);
        return Ok(tasks);
    }

    [HttpGet("date-range")]
    public async Task<ActionResult<IEnumerable<TaskResponse>>> GetTasksByDateRange(
        [FromQuery] DateOnly startDate, 
        [FromQuery] DateOnly endDate)
    {
        var tasks = await taskItemService.GetTasksByDateRange(startDate, endDate);
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

    [HttpPatch("{id:int}/complete")]
    public async Task<ActionResult<TaskResponse>> CompleteTask(int id)
    {
        var task = await taskItemService.CompleteTask(id);
        if (task == null)
            return NotFound();
        return Ok(task);
    }

    [HttpPatch("{id:int}/uncomplete")]
    public async Task<ActionResult<TaskResponse>> UncompleteTask(int id)
    {
        var task = await taskItemService.UncompleteTask(id);
        if (task == null)
            return NotFound();
        return Ok(task);
    }
}
