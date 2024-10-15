using System.ComponentModel.DataAnnotations;

namespace App.DTOs;

public class PlayerDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string? Username { get; set; }
}
