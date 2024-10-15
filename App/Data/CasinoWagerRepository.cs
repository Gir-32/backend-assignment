using AutoMapper.QueryableExtensions;

namespace App.Data;

public class CasinoWagerRepository(DataContext context, IMapper mapper) : ICasinoWagerRepository
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PagedResponse<CasinoListDto>> GetCasinoWagersAsync(Guid playerId, PaginationParams paginationParams)
    {
        var query = _context.CasinoWagers
            .OrderByDescending(x => x.CreatedDatetime)
            .AsQueryable();

        query = query.Where(x => x.Player.Id == playerId);

        return await PagedResponse<CasinoListDto>
            .CreateAsync(
                query.ProjectTo<CasinoListDto>(_mapper.ConfigurationProvider)
                    .AsNoTracking(),
                paginationParams.PageNumber,
                paginationParams.PageSize);
    }

    public async Task<IEnumerable<TopSpendersDto>> GetTopSpendersAsync(int count)
    {
        return await _context.CasinoWagers
            .GroupBy(x => x.Player.Id)
            .Select(g => new TopSpendersDto
            {
                AccountId = g.Key,
                Username = g.First().Player.Username,
                TotalAmountSpend = g.Sum(y => y.Amount)
            })
            .OrderByDescending(x => x.TotalAmountSpend)
            .Take(count)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> AddCasinoWagerAsync(CasinoWagerDto casinoWagerDto)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == casinoWagerDto.AccountId);

                if (player == null)
                {
                    player = new Player
                    {
                        Id = casinoWagerDto.AccountId,
                        Username = casinoWagerDto.Username
                    };

                    await _context.Players.AddAsync(player);
                }

                var provider = await _context.Providers.Include(x => x.Games).FirstOrDefaultAsync(p => p.Name == casinoWagerDto.Provider);

                if (provider == null)
                {
                    provider = new Provider
                    {
                        Name = casinoWagerDto.Provider,
                        Games = []
                    };

                    await _context.Players.AddAsync(player);
                }

                var game = provider.Games?.FirstOrDefault(g => g.Name == casinoWagerDto.GameName);

                if (game == null)
                {
                    game = new Game
                    {
                        Name = casinoWagerDto.GameName,
                        Theme = casinoWagerDto.Theme
                    };

                    provider.Games?.Add(game);
                }

                var casinoWager = new CasinoWager
                {
                    Id = casinoWagerDto.WagerId,
                    Provider = provider,
                    Game = game,
                    TransactionId = casinoWagerDto.TransactionId,
                    BrandId = casinoWagerDto.BrandId,
                    Player = player,
                    ExternalReferenceId = casinoWagerDto.ExternalReferenceId,
                    TransactionTypeId = casinoWagerDto.TransactionTypeId,
                    Amount = casinoWagerDto.Amount,
                    CreatedDatetime = casinoWagerDto.CreatedDatetime,
                    NumberOfBets = casinoWagerDto.NumberOfBets,
                    CountryCode = casinoWagerDto.CountryCode,
                    SessionData = casinoWagerDto.SessionData,
                    Duration = casinoWagerDto.Duration
                };

                await _context.CasinoWagers.AddAsync(casinoWager);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                //TODO: _logger.LogError($"Error adding casino wager: {ex.Message}");
                return false;
            }
        }
    }
}
