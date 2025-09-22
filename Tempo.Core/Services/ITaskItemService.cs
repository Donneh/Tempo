using Tempo.Core.Models;
using Tempo.Core.Requests;
using Tempo.Core.Responses;

namespace Tempo.Core.Services;

public interface ITaskItemService
{
    Task<TaskResponse> CreateTask(CreateTaskRequest request);
    Task<TaskResponse?> GetTask(int id);
    Task<IEnumerable<TaskResponse>> GetAllTasks();
    Task<bool> DeleteTask(int id);
    Task<TaskResponse?> CompleteTask(int id);
    Task<TaskResponse?> UncompleteTask(int id);
}
