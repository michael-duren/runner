using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

public class TemplateRunEntryRunType
{
    [Key] public int Id { get; set; }
    [ForeignKey("TemplateRun")] public int TemplateRunId { get; set; }
    public TemplateRunEntry TemplateRunEntry { get; set; } = null!;
    [ForeignKey("RunType")] public int RunTypeId { get; set; }
    public RunType RunType { get; set; } = null!;
}