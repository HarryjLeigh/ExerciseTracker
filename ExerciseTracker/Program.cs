using ExerciseTracker.Controllers;
using ExerciseTracker.Data;
using ExerciseTracker.Models;
using ExerciseTracker.Repository;
using ExerciseTracker.Services;
using ExerciseTracker.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
    .Build();

string connectionString = configuration.GetConnectionString("DatabasePath");

var services = new ServiceCollection()
    .AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString))
    .AddScoped(typeof(IRepository<>), typeof(ExerciseRepository<>))
    .AddScoped<IRepository<Exercise>, ExerciseRepository<Exercise>>()
    .AddScoped<IExerciseService, ExerciseService>()
    .AddScoped<IExerciseController, ExerciseController>()
    .AddScoped<ExerciseController>()
    .BuildServiceProvider();

 // var repository = services.GetService<IRepository<Exercise>>();

var controller = services.GetService<ExerciseController>();

if (controller != null)
{
    var userInterface = new UserInterface(controller);
    userInterface.Run();
}
else
{
    Console.WriteLine("Unable to initialise controller.");
}


