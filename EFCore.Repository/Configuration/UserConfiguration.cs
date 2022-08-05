using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        //Aunque no se define un tamaño maximo para los campos de string es una buena practica limitarlos
        //El password no se limito porque se suele encriptar si tengo tiempo lo encriptaré.
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.Property(e => e.Nombre)
              .IsRequired().HasMaxLength(150);
            entity.Property(e => e.Apellido)
            .IsRequired().HasMaxLength(150);
            entity.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(350);
            entity.Property(e => e.Password)
            .IsRequired();
            entity.HasIndex(e => new {e.Nombre, e.Apellido, e.Email}).HasDatabaseName("UC_UserNombreApellidoEmail").IsUnique();

        }
    }
}
