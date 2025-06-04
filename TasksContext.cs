// using efCourse.Models;
using efCourse.Models;
using Microsoft.EntityFrameworkCore;

namespace efCourse;

public class TasksContext : DbContext
{
    public DbSet<Models.Category> Categories { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    // This method is protected because it is called by the framework
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(c => c.CategoryId);

            category.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            category.Property(c => c.Description);
        });

        modelBuilder.Entity<Models.Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(t => t.TaskId);

            task.HasOne(t => t.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CategoryId);

            task.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            task.Property(t => t.Description);
            task.Property(t => t.TaskPriority);

            task.Property(t => t.CreationDate);

            task.Ignore(t => t.Summary); // Ignore the Summary property, not mapped to the database
        });
    }
}