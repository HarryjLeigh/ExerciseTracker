using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExerciseTracker.Enums;

internal enum MainMenuOptions
{
    [Display(Name = "Add Exercise")] Add,
    [Display(Name = "Exercise History")] History,
    [Display(Name = "Exit")] Exit
}

internal enum HistoryOptions
{
    [Display(Name = "View all")] View,
    [Display(Name = "Update")] Update,
    [Display(Name = "Delete")] Delete,
    [Display(Name = "Exit")] Exit
}

internal enum UpdateOptions
{
    [Display(Name = "Start")] Start,
    [Display(Name = "Finish")] Finish,
    [Display(Name = "Comments")] Comments,
    [Display(Name = "All")] All,
    [Display(Name = "Exit")] Exit,
}