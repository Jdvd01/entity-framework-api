using efCourse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Configure dbcontext with in-memory database
// This is useful for testing and development purposes
// builder.Services.AddDbContext<TasksContext>(opt => opt.UseInMemoryDatabase("TasksDb"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    string dbStatus = dbContext.Database.IsInMemory() ? "In-Memory Database" : "Not In-Memory";
    return Results.Ok($"Database connection status: {dbStatus}");
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
    // return Results.Ok(dbContext.Tasks.Where(t => t.TaskPriority == efCourse.Models.Priority.High));
    return Results.Ok(dbContext.Tasks.Include(t => t.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] efCourse.Models.Task task) =>
{
    task.TaskId = Guid.NewGuid(); // Generate a new TaskId
    task.CreationDate = DateTime.Now.Date;
    task.Deadline = DateTime.Now.Date.AddDays(3);

    // await dbContext.Tasks.AddAsync(task);
    await dbContext.AddAsync(task);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/api/tasks/{task.TaskId}", task);
});

app.MapPut("/api/tasks/{id}", async (
    [FromServices] TasksContext dbContext,
    [FromBody] efCourse.Models.Task task,
    [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);
    var category = dbContext.Categories.Find(task.CategoryId);

    if (currentTask == null) return Results.BadRequest($"TaskId not found: {id}");
    if (category == null) return Results.NotFound($"CategoryId not found: {task.CategoryId}");

    if (task.TaskId != id) return Results.BadRequest("TaskId in body does not match TaskId in route");
    if (task.Deadline < DateTime.Now.Date) return Results.BadRequest("Deadline cannot be in the past");
    if (task.TaskPriority < efCourse.Models.Priority.Low || task.TaskPriority > efCourse.Models.Priority.High) return Results.BadRequest("Invalid TaskPriority value, should be between Low(0) and High(2)");

    currentTask.CategoryId = task.CategoryId;
    currentTask.Title = task.Title ?? currentTask.Title;
    currentTask.Description = task.Description ?? currentTask.Description;
    currentTask.TaskPriority = task.TaskPriority;
    currentTask.Deadline = task.Deadline;
    currentTask.Summary = task.Summary;

    await dbContext.SaveChangesAsync();

    return Results.Ok(currentTask);
});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);

    if (currentTask == null) return Results.NotFound($"task not found: {id}");

    dbContext.Remove(currentTask);
    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});

app.MapGet("/api/categories", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Categories);
});

app.Run();
