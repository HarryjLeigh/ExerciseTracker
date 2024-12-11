using System.Globalization;
using ExerciseTracker.Models;

namespace ExerciseTracker.Utilities;

public static class Validator
{
    private const string DateFormat = "yyyy-MM-dd HH:mm";
    internal static bool IsDateFormatValid(string date)
    {
        return DateTime.TryParseExact(
            date, 
            DateFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out _);
    }

    internal static bool IsIdValid(int input, List<Exercise> exercises) =>
        exercises.Any(exercise => exercise.Id == input);
    
    internal static bool IsStartDateValid(DateTime startDate, DateTime endDate) 
        => startDate < endDate;

    internal static bool IsEndDateValid(DateTime startDate, DateTime endDate)
        => endDate > startDate;

    internal static bool IsDateDurationValid(DateTime startDate, DateTime endDate)
    {
        TimeSpan duration = ExerciseExtensions.CalculateDuration(startDate, endDate);
        return duration.TotalHours < 24;
    }
}
