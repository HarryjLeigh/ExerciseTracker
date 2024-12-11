using System.Globalization;
using Spectre.Console;

namespace ExerciseTracker.Utilities;

public static class Util
{
    private const string DateFormat = "yyyy-MM-dd HH:mm";

    internal static DateTime ParseDateWithFormat(string date)
    {
        if (DateTime.TryParseExact(
                date,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime formattedDate)) 
            return formattedDate;

        return new DateTime();
    }

    internal static void AskUserToContinue()
    {
        AnsiConsole.Markup("Press any key to continue...");
        Console.ReadKey();
    }

    internal static bool ReturnToMenu()
    {
        AnsiConsole.MarkupLine("Type '[bold yellow]0[/]' to exit or any other key to continue...");
        var answer = Console.ReadLine();
        if (answer == "0") return true;
        return false;
    }
}