namespace App.Services.Interfaces;

public interface ICasinoWagerService
{
    Task<PagedResponse<CasinoListDto>> GetCasinoWagersForPlayer(Guid playerId, PaginationParams paginationParams);
    Task<IEnumerable<TopSpendersDto>> GetTopSpendersAsync(int count);
    Task<bool> AddCasinoWagerAsync(CasinoWagerDto casinoWager);
}
