namespace App.Services;

public class CasinoWagerService(IUnitOfWork unitOfWork) : ICasinoWagerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<PagedResponse<CasinoListDto>> GetCasinoWagersForPlayer(Guid playerId, PaginationParams paginationParams)
    {
        return await _unitOfWork.CasinoWagerRepository.GetCasinoWagersAsync(playerId, paginationParams);
    }

    public async Task<IEnumerable<TopSpendersDto>> GetTopSpendersAsync(int count)
    {
        return await _unitOfWork.CasinoWagerRepository.GetTopSpendersAsync(count);
    }

    public async Task<bool> AddCasinoWagerAsync(CasinoWagerDto casinoWager)
    {
        return await _unitOfWork.CasinoWagerRepository.AddCasinoWagerAsync(casinoWager);
    }
}
