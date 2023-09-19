using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
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

   protected override async Task OnInitializedAsync()
   {
      Goals = await Db.Goals.ToListAsync();
      DifficultyLevels = await Db.DifficultyLevels.ToListAsync();
      NewSchedule.Weeks = 10;
   }
}