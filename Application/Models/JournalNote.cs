using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

public class JournalNote
{
    [Key] public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Note { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    [ForeignKey("User")] public int UserId { get; set; }
    public User User { get; set; } = null!;
    
}