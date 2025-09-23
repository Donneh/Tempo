using Tempo.Core.Models;
using Tempo.Core.Repositories;
using Tempo.Core.Requests;
using Tempo.Core.Responses;

namespace Tempo.Core.Services;

public class TaskItemService(ITaskItemRepository taskItemRepository) : ITaskItemService
{
    public async Task<TaskResponse> CreateTask(CreateTaskRequest request)
    {
        var task = new TaskItem
        {
            Text = request.Text,
            Order = request.Order,
            CreatedAt = DateTime.UtcNow,
        };

        var createdTask = await taskItemRepository.CreateAsync(task);

        return new TaskResponse
        {
            Id = createdTask.Id,
            Text = createdTask.Text,
            Order = createdTask.Order,
            CreatedAt = createdTask.CreatedAt,
            UpdatedAt = createdTask.UpdatedAt,
            CompletedAt = createdTask.CompletedAt,
            IsCompleted = createdTask.IsCompleted,
        };
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

    public async Task<IEnumerable<TaskResponse>> GetAllTasks()
    {
        var tasks = await taskItemRepository.GetAllAsync();

        return tasks.Select(task => new TaskResponse
        {
            Id = task.Id,
            Text = task.Text,
            Order = task.Order,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt,
            CompletedAt = task.CompletedAt,
            IsCompleted = task.IsCompleted,
        });
    }

    public async Task<IEnumerable<TaskResponse>> GetTasksByDate(DateOnly date)
    {
        var tasks = await taskItemRepository.GetByDateAsync(date);

        return tasks.Select(task => new TaskResponse
        {
            Id = task.Id,
            Text = task.Text,
            Order = task.Order,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt,
            CompletedAt = task.CompletedAt,
            IsCompleted = task.IsCompleted,
        });
    }

    public async Task<IEnumerable<TaskResponse>> GetTasksByDateRange(DateOnly startDate, DateOnly endDate)
    {
        var tasks = await taskItemRepository.GetByDateRangeAsync(startDate, endDate);

        return tasks.Select(task => new TaskResponse
        {
            Id = task.Id,
            Text = task.Text,
            Order = task.Order,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt,
            CompletedAt = task.CompletedAt,
            IsCompleted = task.IsCompleted,
        });
    }

    public async Task<TaskResponse?> CompleteTask(int id)
    {
        var task = await taskItemRepository.GetByIdAsync(id);
        if (task == null)
            return null;

        task.CompletedAt = DateTime.UtcNow;
        task.UpdatedAt = DateTime.UtcNow;

        await taskItemRepository.UpdateAsync(task);

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

    public async Task<TaskResponse?> UncompleteTask(int id)
    {
        var task = await taskItemRepository.GetByIdAsync(id);
        if (task == null)
            return null;

        task.CompletedAt = null;
        task.UpdatedAt = DateTime.UtcNow;

        await taskItemRepository.UpdateAsync(task);

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

    public async Task<bool> DeleteTask(int id)
    {
        var task = await taskItemRepository.GetByIdAsync(id);
        if (task == null)
            return false;

        await taskItemRepository.DeleteAsync(id);
        return true;
    }
}
