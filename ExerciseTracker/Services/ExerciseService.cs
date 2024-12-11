using ExerciseTracker.Models;
using ExerciseTracker.Repository;

namespace ExerciseTracker.Services;

public class ExerciseService(IRepository<Exercise> exerciseRepository) : IExerciseService
{
    private readonly IRepository<Exercise> _exerciseRepository = exerciseRepository;

    public Exercise GetById(int id) => _exerciseRepository.GetById(id);
    public List<Exercise> GetAllExercises() => _exerciseRepository.GetAll().ToList();
    
    public void AddExercise(Exercise exercise) => _exerciseRepository.Add(exercise);

    public void UpdateExercise(Exercise exercise) => _exerciseRepository.Update(exercise);
    
    public void DeleteExercise(int id)
    {
        Exercise exerciseToDelete = _exerciseRepository.GetById(id);
        _exerciseRepository.Delete(exerciseToDelete.Id);
    }
}