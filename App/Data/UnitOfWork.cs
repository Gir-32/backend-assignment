namespace App.Data;

public class UnitOfWork(DataContext context, IMapper mapper) : IUnitOfWork
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public ICasinoWagerRepository CasinoWagerRepository => new CasinoWagerRepository(_context, _mapper);

    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
        _context.ChangeTracker.DetectChanges();
        var changes = _context.ChangeTracker.HasChanges();

        return changes;
    }
}
