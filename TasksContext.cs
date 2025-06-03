// using efCourse.Models;
using Microsoft.EntityFrameworkCore;

namespace efCourse;

public class TasksContext : DbContext
{
    public DbSet<Models.Category> Categories { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
}