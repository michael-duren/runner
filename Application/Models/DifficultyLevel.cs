using System.ComponentModel.DataAnnotations;

namespace Runner.Application.Models;

public class DifficultyLevel
{
    [Key] public int Id { get; set; }
    public string Difficulty { get; set; } = null!;
}