using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Services;
using ExerciseTracker.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExerciseTracker.Views;

public class UpdateView(IExerciseController exerciseController)
{
    private readonly IExerciseController _exerciseController = exerciseController;
    internal void Run(Enum SelectedEnum)
    {
        bool endUpdate = false;

        while (!endUpdate)
        {
            Console.Clear();
            ViewExtensions.GetEnumDescription(SelectedEnum);
            var selectedEnum = ViewExtensions.GetViewChoice<UpdateOptions>();

            switch (selectedEnum)
            {
                case UpdateOptions.Start:
                    _exerciseController.Update(updateStart : true);
                    break;
                case UpdateOptions.Finish:
                    _exerciseController.Update(updateFinish: true);
                    break;
                case UpdateOptions.Comments:
                    _exerciseController.Update(updateComments: true);
                    break;
                case UpdateOptions.All:
                    _exerciseController.Update(
                        updateStart: true,
                        updateFinish: true,
                        updateComments: true
                        );
                    break;
                case UpdateOptions.Exit:
                    endUpdate = true;
                    break;
            }
        }
    }
}