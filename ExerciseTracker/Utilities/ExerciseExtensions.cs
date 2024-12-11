using ExerciseTracker.Models;

namespace ExerciseTracker.Utilities;

public static class ExerciseExtensions
{
    internal static Exercise CreateExercise()
    {
        DateTime start = GetExerciseStart();
        DateTime end = GetExerciseEnd(start);
        return new Exercise
        {
            DateStart = start,
            DateEnd = end,
            Duration = CalculateDuration(start, end),
            Comments = GetExerciseComments()
        };
    }

    internal static DateTime GetExerciseEnd(DateTime start) => UserInput.DatePrompt("end", start);

    internal static TimeSpan CalculateDuration(DateTime dateStart, DateTime dateEnd) => dateEnd - dateStart;

    internal static string GetExerciseComments() => UserInput.CommentsPrompt();

    internal static DateTime GetExerciseStart(DateTime end = new DateTime(), bool update = false)
    {
        if (update)
        {
            return UserInput.DatePrompt("start", end);
        }

        return DateTime.Now;
    }
}