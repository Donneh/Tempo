using Tempo.Core.Models;
using Tempo.Core.Requests;
using Tempo.Core.Responses;

namespace Tempo.Core.Services;

public interface ITasItemService
{
    Task<TaskResponse> CreateTask(CreateTaskRequest request);
    Task<TaskResponse?> GetTask(int id);
    Task<IEnumerable<TaskResponse>> GetAllTasks();
    Task<TaskResponse?> CompleteTask(int id);
    Task<TaskResponse?> UncompleteTask(int id);
}
