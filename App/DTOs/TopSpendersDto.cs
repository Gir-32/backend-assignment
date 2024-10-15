using System.ComponentModel.DataAnnotations;

namespace App.DTOs;

public class TopSpendersDto
{
    [Required]
    public Guid AccountId { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public decimal TotalAmountSpend { get; set; }
}
