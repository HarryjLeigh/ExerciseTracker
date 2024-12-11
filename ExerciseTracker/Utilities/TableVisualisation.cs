using ExerciseTracker.Models;
using Spectre.Console;

namespace ExerciseTracker.Views;

public static class TableVisualisation
{
    internal static void ShowTable(List<Exercise> exercises)
    {
        var table = new Table().AddColumns(
            "ID",
            "Start",
            "End",
            "Duration",
            "Comments");

        foreach (Exercise exercise in exercises)
        {
            table.AddRow(
                exercise.Id.ToString(),
                exercise.DateStart.ToString("yyyy-MM-dd HH:mm"),
                exercise.DateEnd.ToString("yyyy-MM-dd HH:mm"),
                exercise.Duration.ToString("hh\\:mm\\:ss"),
                exercise.Comments
            );
        }
        AnsiConsole.Write(table);
    }
}