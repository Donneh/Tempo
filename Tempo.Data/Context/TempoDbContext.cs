using Microsoft.EntityFrameworkCore;
using Tempo.Core.Models;

namespace Tempo.Data.Context;

public class TempoDbContext(DbContextOptions<TempoDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Text).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Order).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
            entity.Property(e => e.CompletedAt);

            entity.HasIndex(e => e.Order);
            entity.HasIndex(e => e.CreatedAt);
            entity.HasIndex(e => e.CompletedAt);
        });
    }
}
