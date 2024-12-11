using Spectre.Console;

namespace ExerciseTracker.Utilities;

public static class ViewExtensions
{
    internal static TEnum GetViewChoice<TEnum>() where TEnum : struct, Enum
    {
        var enumValues = Enum.GetValues<TEnum>().ToList();
        var displayNames = enumValues
            .Select(e => EnumExtensions.GetEnumDisplayName(e))
            .ToList();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What would you like to do?")
                .AddChoices(displayNames));

        return enumValues.FirstOrDefault(
            e => EnumExtensions.GetEnumDisplayName(e) == choice);
    }

    internal static void GetEnumDescription(Enum enumValue)
    {
        var menuChoice = EnumExtensions.GetEnumDisplayName(enumValue);
        AnsiConsole.MarkupLine($"You selected: [green]{menuChoice}[/]");
    }
}