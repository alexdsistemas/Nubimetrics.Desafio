using ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using Services;

namespace EFCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ChallengeDataContext context;

        public UnitOfWork(ChallengeDataContext context)
        {
            this.context = context;
        }

        public async ValueTask<int> SaveChanges()
        {
            int Result;
            
            try
            {
                Result = await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new UpdateException(ex.InnerException?.Message ?? ex.Message, ex.Entries.Select(e => e.Entity.GetType().Name).ToList());
            }
            catch (Exception ex)
            {
         
                throw new GeneralException("Error al persistir los cambios", ex.Message);
            }
            return Result;
        }
    }
}
