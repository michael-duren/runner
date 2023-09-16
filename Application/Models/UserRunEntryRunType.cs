using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

public class UserRunEntryRunType
{
    public int Id { get; set; }
    public int UserRunEntryId { get; set; }
    public UserRunEntry UserRunEntry { get; set; } = null!;

    public int RunTypeId { get; set; }
    public RunType RunType { get; set; } = null!;
}