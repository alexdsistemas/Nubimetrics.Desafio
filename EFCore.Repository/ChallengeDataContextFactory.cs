using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore.Repository
{
    public class ChallengeDataContextFactory : IDesignTimeDbContextFactory<ChallengeDataContext>
    {
        //Se usa solamente en tiempo de diseño para crear rapidamente la base de datos local
        //Para crear una migracion
        //add-migration MigracionInicial -p EFCore.Repository -c ChallengeDataContext -o Migraciones -s EFCore.Repository
        //-p proyecto origen, -c el contexto, -o donde se guardaran las migraciones, -s donde están las herramientas de ef 
        //Para crear la base de datos
        //update-database -p EFCore.Repository -s EFCore.Repository
        public ChallengeDataContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<ChallengeDataContext>();
            OptionsBuilder.UseSqlServer("Persist Security Info=False;Server = localhost\\SQLEXPRESS; Database=ChallengeNubimetrics;User ID=alexTelCo;Password=alex2022;Trusted_Connection = False");
            return new ChallengeDataContext(OptionsBuilder.Options);
        }
    }
}
