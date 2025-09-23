using Microsoft.EntityFrameworkCore;
using Tempo.Core.Models;
using Tempo.Core.Repositories;
using Tempo.Data.Context;

namespace Tempo.Data.Repositories;

public class TaskItemRepository(TempoDbContext context) : ITaskItemRepository
{
    public async Task<TaskItem> CreateAsync(TaskItem task)
    {
        context.Tasks.Add(task);
        await context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await context.Tasks.FindAsync(id);
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await context.Tasks.OrderBy(t => t.Order).ToListAsync();
    }

    public async Task<IEnumerable<TaskItem>> GetByDateAsync(DateOnly date)
    {
        var startOfDay = date.ToDateTime(TimeOnly.MinValue);
        var endOfDay = date.ToDateTime(TimeOnly.MaxValue);
        
        return await context.Tasks
            .Where(t => t.CreatedAt >= startOfDay && t.CreatedAt <= endOfDay)
            .OrderBy(t => t.Order)
            .ToListAsync();
    }

    public async Task<IEnumerable<TaskItem>> GetByDateRangeAsync(DateOnly startDate, DateOnly endDate)
    {
        var startDateTime = startDate.ToDateTime(TimeOnly.MinValue);
        var endDateTime = endDate.ToDateTime(TimeOnly.MaxValue);
        
        return await context.Tasks
            .Where(t => t.CreatedAt >= startDateTime && t.CreatedAt <= endDateTime)
            .OrderBy(t => t.CreatedAt)
            .ThenBy(t => t.Order)
            .ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = await context.Tasks.FindAsync(id);
        if (task != null)
        {
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
        }
    }

    public async Task<TaskItem> UpdateAsync(TaskItem task)
    {
        context.Tasks.Update(task);
        await context.SaveChangesAsync();
        return task;
    }
}
