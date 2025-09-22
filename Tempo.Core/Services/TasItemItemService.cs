using Tempo.Core.Models;
using Tempo.Core.Repositories;
using Tempo.Core.Requests;
using Tempo.Core.Responses;

namespace Tempo.Core.Services;

public class TasItemItemService(ITaskItemRepository taskItemRepository) : ITasItemService
{
    public Task<TaskResponse> CreateTask(CreateTaskRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<TaskResponse?> GetTask(int id)
    {
        var task = await taskItemRepository.GetByIdAsync(id);
        if (task == null)
            return null;

        return new TaskResponse
        {
            Id = task.Id,
            Text = task.Text,
            Order = task.Order,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt,
            CompletedAt = task.CompletedAt,
            IsCompleted = task.IsCompleted,
        };
    }

    public Task<IEnumerable<TaskResponse>> GetAllTasks()
    {
        throw new NotImplementedException();
    }

    public Task<TaskResponse?> CompleteTask(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TaskResponse?> UncompleteTask(int id)
    {
        throw new NotImplementedException();
    }
}
