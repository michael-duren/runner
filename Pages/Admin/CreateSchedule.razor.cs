using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Runner.Application.Database;
using Runner.Application.Models;

namespace Runner.Pages.Admin;

public partial class CreateSchedule
{
    [Inject] private DatabaseContext Db { get; set; } = null!;

    private TemplateSchedule NewSchedule { get; set; } = new TemplateSchedule();
    private List<Goal> Goals { get; set; } = new List<Goal>();
    private List<DifficultyLevel> DifficultyLevels { get; set; } = new List<DifficultyLevel>();
    private List<TemplateRunEntry> TemplateRuns { get; set; } = new List<TemplateRunEntry>();

    private List<SchedulePhase> SchedulePhases { get; set; } = new List<SchedulePhase>();

    private List<RunType> RunTypes { get; set; } = new List<RunType>();

    public int SelectedWeekNumber = 0;
    public int SelectedDayNumber = 0;
    public bool IsOpen = false;

    private void OpenModal(int weekNumber, int dayNumber)
    {
        SelectedWeekNumber = weekNumber;
        SelectedDayNumber = dayNumber;
        IsOpen = true;
        JSRuntime.InvokeVoidAsync("openModal", "add_run_modal");
    }

    private void AddToList(TemplateRunEntry newTemplateRunEntry)
    {
        newTemplateRunEntry.WeekNumber = SelectedWeekNumber;
        newTemplateRunEntry.DayNumber = SelectedDayNumber;

        TemplateRuns.Add(newTemplateRunEntry);
        IsOpen = false;
    }

    private static string GetWeekRow(int weekNum)
    {
        return weekNum % 4 == 0 ? "mb-4" : "";
    }


    protected override async Task OnInitializedAsync()
    {
        Goals = await Db.Goals.ToListAsync();
        DifficultyLevels = await Db.DifficultyLevels.ToListAsync();
        NewSchedule.Weeks = 10;
        SchedulePhases = await Db.SchedulePhases.ToListAsync();
        RunTypes = await Db.RunTypes.ToListAsync();
    }
}