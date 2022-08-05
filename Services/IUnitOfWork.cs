namespace Services
{
    public interface IUnitOfWork
    {
        ValueTask<int> SaveChanges();
    }
}