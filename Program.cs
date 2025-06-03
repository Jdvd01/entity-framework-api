using efCourse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure dbcontext with in-memory database
// This is useful for testing and development purposes
builder.Services.AddDbContext<TasksContext>(opt => opt.UseInMemoryDatabase("TasksDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    string dbStatus = dbContext.Database.IsInMemory() ? "In-Memory Database" : "Not In-Memory";
    return Results.Ok($"Database connection status: {dbStatus}");
});

app.Run();
