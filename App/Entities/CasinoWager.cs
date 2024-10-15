namespace App.Entities;

public class CasinoWager
{
    public required Guid Id { get; set; }
    public required Provider Provider { get; set; }
    public required Game Game { get; set; }
    public required Guid TransactionId { get; set; }
    public required Guid BrandId { get; set; }
    public required Player Player { get; set; }
    public required Guid ExternalReferenceId { get; set; }
    public required Guid TransactionTypeId { get; set; }
    public required decimal Amount { get; set; }
    public required DateTime CreatedDatetime { get; set; }
    public required int NumberOfBets { get; set; }
    public required string CountryCode { get; set; }
    public required string SessionData { get; set; }
    public required long Duration { get; set; }
}
