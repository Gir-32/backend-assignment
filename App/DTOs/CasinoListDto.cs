using System.ComponentModel.DataAnnotations;

namespace App.DTOs;

public class CasinoListDto
{
    [Required]
    public Guid WagerId { get; set; }
    [Required]
    public string? Game { get; set; }
    [Required]
    public string? Provider { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
}
