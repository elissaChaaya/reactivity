using Application.Activities.Queries;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddCors(); //we added the service Cors, and bc of that we need to add middleware
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000","https://localhost:3000")); //x refers to options
app.MapControllers();

using var scope = app.Services.CreateScope(); //creating a service scope, make sure stuff gets disposed when we are finished with it 
var services = scope.ServiceProvider;
try
{
  
  var context = services.GetRequiredService<AppDbContext>();
  await context.Database.MigrateAsync(); //any pending migrations will be applied, note: migrations: adding, creating properties...
  await DbInitializer.SeedData(context);
}
catch(Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "an error occured during migration");
  throw;   
}
app.Run();
