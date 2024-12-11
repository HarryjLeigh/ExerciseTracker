using ExerciseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Exercise> Exercises { get; set; }
}