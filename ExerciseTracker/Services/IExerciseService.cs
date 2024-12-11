using ExerciseTracker.Models;
using ExerciseTracker.Repository;

namespace ExerciseTracker.Services;

public interface IExerciseService
{
    internal Exercise GetById(int id);
    internal List<Exercise> GetAllExercises();
    internal void AddExercise(Exercise exercise);
    internal void UpdateExercise(Exercise exercise);
    internal void DeleteExercise(int id);
}