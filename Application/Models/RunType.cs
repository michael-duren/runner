using System.ComponentModel.DataAnnotations;

namespace Runner.Application.Models;

public class RunType
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    // navigation property    
    public ICollection<TemplateRunEntryRunType> TemplateRunEntryRunTypes { get; set; } = new List<TemplateRunEntryRunType>();
    public ICollection<UserRunEntryRunType> UserRunEntryRunTypes { get; set; } = new List<UserRunEntryRunType>();
}