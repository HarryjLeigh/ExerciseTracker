using ExerciseTracker.Models;

namespace ExerciseTracker.Controllers;

public interface IExerciseController
{
    internal void ViewAll();
    internal void Add();
    internal void Update(
        bool updateStart = false,
        bool updateFinish = false,
        bool updateComments = false
        );
    internal void Delete();
}