using System.Runtime.InteropServices.JavaScript;
using ExerciseTracker.Models;
using ExerciseTracker.Services;
using ExerciseTracker.Utilities;
using ExerciseTracker.Views;

namespace ExerciseTracker.Controllers;

public class ExerciseController(IExerciseService exerciseService) : IExerciseController
{
    private readonly IExerciseService _exerciseService = exerciseService;

    public void ViewAll()
    {
        var exercises = _exerciseService.GetAllExercises();
        TableVisualisation.ShowTable(exercises);
    }

    public void Add()
    {
        if (Util.ReturnToMenu()) return;
        Exercise exercise =  ExerciseExtensions.CreateExercise();
        _exerciseService.AddExercise(exercise);
    }

    public void Update(
        bool updateStart = false,
        bool updateFinish = false,
        bool updateComments = false
        )
    {
        if (Util.ReturnToMenu()) return;
        ViewAll();
        int exerciseId = UserInput.IdPrompt(
            _exerciseService.GetAllExercises());

        Exercise exerciseToUpdate = _exerciseService.GetById(exerciseId);
        
        if (updateStart) exerciseToUpdate.DateStart = ExerciseExtensions.GetExerciseStart(exerciseToUpdate.DateEnd,true);
        if (updateFinish) exerciseToUpdate.DateEnd = ExerciseExtensions.GetExerciseEnd(exerciseToUpdate.DateStart);
        if (updateComments) exerciseToUpdate.Comments = ExerciseExtensions.GetExerciseComments();

        if (updateStart || updateFinish)
             exerciseToUpdate.Duration = ExerciseExtensions.CalculateDuration(
                exerciseToUpdate.DateStart,
                exerciseToUpdate.DateEnd);
        
        _exerciseService.UpdateExercise(exerciseToUpdate);
    }

    public void Delete()
    {
        if (Util.ReturnToMenu()) return;
        ViewAll();
        int exerciseId = UserInput.IdPrompt(
            _exerciseService.GetAllExercises());
        _exerciseService.DeleteExercise(exerciseId);
    }
    
}