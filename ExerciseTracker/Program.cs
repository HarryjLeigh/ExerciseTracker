using Microsoft.Extensions.Configuration;
using System.Data;
using ExerciseTracker.Controllers;
using ExerciseTracker.Models;
using ExerciseTracker.Repository;
using ExerciseTracker.Services;
using ExerciseTracker.Utilities;
using ExerciseTracker.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationManager();
configuration.SetBasePath(AppContext.BaseDirectory);
configuration.AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);


string connectionString = configuration.GetConnectionString("DatabasePath");
var services = new ServiceCollection()
    .AddScoped<IDbConnection>(_ =>
        new SqlConnection(connectionString))
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


