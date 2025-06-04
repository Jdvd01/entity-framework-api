// using efCourse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace efCourse;

public class TasksContext : DbContext
{
    public DbSet<Models.Category> Categories { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    // This method is protected because it is called by the framework
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Models.Category> categoriesInit =
        [
            new Models.Category()
            {
                CategoryId = Guid.Parse("4ab33fe8-1ee4-48bb-8a98-c82989ec2745"),
                Name = "Work",
                Description = "Tasks related to work",
                WorkLoad = 20
            },
            new Models.Category()
            {
                CategoryId = Guid.Parse("4ab33fe8-1ee4-48bb-8a98-c82989ec2746"),
                Name = "Personal",
                Description = "Tasks related to personal life",
                WorkLoad = 50
            },
        ];


        modelBuilder.Entity<Models.Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(c => c.CategoryId);

            category.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            category.Property(c => c.Description)
                .IsRequired(false);

            category.Property(c => c.WorkLoad);

            category.HasData(categoriesInit); // Seed initial data
        });

        List<Models.Task> tasksInit = [
            new Models.Task()
            {
                TaskId = Guid.Parse("4ab33fe8-1ee4-48bb-8a98-c82989ec2333"),
                CategoryId = Guid.Parse("4ab33fe8-1ee4-48bb-8a98-c82989ec2745"),
                Title = "Develop new feature",
                Description = "Implement the landing page for the new product",
                TaskPriority = Models.Priority.High,
                CreationDate = DateTime.Now.Date,
                Deadline = DateTime.Now.Date.AddDays(7),
                Summary = "Develop the landing page for the new product launch"
            },
            new Models.Task()
            {
                TaskId = Guid.Parse("4ab33fe8-1ee4-48bb-8a98-c82989ec2334"),
                CategoryId = Guid.Parse("4ab33fe8-1ee4-48bb-8a98-c82989ec2746"),
                Title = "Shopping",
                Description = "Buy groceries for the week",
                TaskPriority = Models.Priority.Medium,
                CreationDate = DateTime.Now.Date,
                Deadline = DateTime.Now.Date.AddDays(3),
                Summary = "Develop the landing page for the new product launch"
            },
        ];

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

            task.Property(t => t.Description)
                .IsRequired(false);

            task.Property(t => t.TaskPriority);

            task.Property(t => t.CreationDate);
            task.Property(t => t.Deadline);

            task.Ignore(t => t.Summary); // Ignore the Summary property, not mapped to the database

            task.HasData(tasksInit); // Seed initial data
        });
    }
}