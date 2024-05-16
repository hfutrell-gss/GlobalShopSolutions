namespace AccountsReceivable.Application.Persistence;

public interface IUnitOfWork
{
    public void Commit();
}