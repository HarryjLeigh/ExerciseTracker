using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;
using Spectre.Console;

namespace ExerciseTracker.Views;

public class UserInterface(IExerciseController controller)
{
    private readonly IExerciseController _exerciseController = controller;
    private readonly HistoryView _historyView = new HistoryView(controller);

    internal void Run()
    {
        bool endMainMenu = false;
        while (!endMainMenu)
        {
            Console.Clear();
            var selectedEnum = ViewExtensions.GetViewChoice<MainMenuOptions>();
               
            switch (selectedEnum)
            {
                case MainMenuOptions.Add:
                    _exerciseController.Add();
                    break;
                case MainMenuOptions.History:
                    _historyView.Run(selectedEnum);
                    break;
                case MainMenuOptions.Exit:
                    endMainMenu = true;
                    break;
            }
        }
    }
}