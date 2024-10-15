namespace App.Data.Interfaces;

public interface IUnitOfWork
{
    ICasinoWagerRepository CasinoWagerRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}
