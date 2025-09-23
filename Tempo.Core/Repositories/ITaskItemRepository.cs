using Tempo.Core.Models;

namespace Tempo.Core.Repositories;

public interface ITaskItemRepository
{
    Task<TaskItem> CreateAsync(TaskItem task);
    Task<TaskItem?> GetByIdAsync(int id);
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<IEnumerable<TaskItem>> GetByDateAsync(DateOnly date);
    Task<IEnumerable<TaskItem>> GetByDateRangeAsync(DateOnly startDate, DateOnly endDate);
    Task DeleteAsync(int id);
    Task<TaskItem> UpdateAsync(TaskItem task);
}
