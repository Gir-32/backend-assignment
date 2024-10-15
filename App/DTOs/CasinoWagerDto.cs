using System.ComponentModel.DataAnnotations;

namespace App.DTOs;

public class CasinoWagerDto
{
    [Required]
    public required Guid WagerId { get; set; }
    [Required]
    public required string Theme { get; set; }
    [Required]
    public required string Provider { get; set; }
    [Required]
    public required string GameName { get; set; }
    [Required]
    public required Guid TransactionId { get; set; }
    [Required]
    public required Guid BrandId { get; set; }
    [Required]
    public required Guid AccountId { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    public required Guid ExternalReferenceId { get; set; }
    [Required]
    public required Guid TransactionTypeId { get; set; }
    [Required]
    public required decimal Amount { get; set; }
    [Required]
    public required DateTime CreatedDatetime { get; set; }
    [Required]
    public required int NumberOfBets { get; set; }
    [Required]
    public required string CountryCode { get; set; }
    [Required]
    public required string SessionData { get; set; }
    [Required]
    public long Duration { get; set; }

}
