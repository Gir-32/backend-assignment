namespace App.Data.Interfaces;

public interface ICasinoWagerRepository
{
    Task<PagedResponse<CasinoListDto>> GetCasinoWagersAsync(Guid playerId, PaginationParams paginationParams);
    Task<IEnumerable<TopSpendersDto>> GetTopSpendersAsync(int count);
    Task<bool> AddCasinoWagerAsync(CasinoWagerDto casinoWagerDto);
}
