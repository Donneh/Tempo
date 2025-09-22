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
