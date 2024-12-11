using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;
using Spectre.Console;

namespace ExerciseTracker.Views;

public class HistoryView(IExerciseController exerciseController)
{
    private readonly IExerciseController _exerciseController = exerciseController;
    private readonly UpdateView _updateView = new UpdateView(exerciseController);
    internal void Run(MainMenuOptions selected)
    {
        bool endMainMenu = false;
        while (!endMainMenu)
        {
            Console.Clear();
            ViewExtensions.GetEnumDescription(selected);
            var selectedEnum = ViewExtensions.GetViewChoice<HistoryOptions>();
            switch (selectedEnum)
            {
                case HistoryOptions.View:
                    Console.Clear();
                    _exerciseController.ViewAll();
                    Util.AskUserToContinue();
                    break;
                case HistoryOptions.Update:
                    _updateView.Run(selectedEnum);
                    break;
                case HistoryOptions.Delete:
                    Console.Clear();
                    ViewExtensions.GetEnumDescription(selectedEnum);
                    _exerciseController.Delete();
                    break;
                case HistoryOptions.Exit:
                    endMainMenu = true;
                    break;
            }
        }
    }
}