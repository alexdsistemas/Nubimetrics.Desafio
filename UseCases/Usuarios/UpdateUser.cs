using DTOs;
using Entities;
using ExceptionHandler;
using Services;
using System.Text;
using UseCases.Usuarios.Services;

namespace UseCases.Usuarios
{
    public class UpdateUser : IUpdateUserInputPort
    {
        readonly IUnitOfWork UnitOfWork;
        readonly IUserRepository Repository;
        readonly IUpdateUserOutputPort OutputPort;

        public UpdateUser(IUnitOfWork unitOfWork, IUserRepository repository, IUpdateUserOutputPort outputPort)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            OutputPort = outputPort;
        }

        public async ValueTask Handle(UpdateUserDto dto)
        {
            var UserExists =  await Repository.UserExists(dto.Id);
            if (!UserExists)
                throw new BadRequestException("No se encontró el usuario en la base de datos.");
            
            //TODO si hay tiempo hay que hacer con esta logica sea unica para crear y modificar
            //Paso la contraseña a base64 para no quedar expuesta
            dto.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(dto.Password));
            //Algo de regla de negocio para ejemplificar se debe guardar el nombre en letras mayusculas.
            dto.Nombre = dto.Nombre.ToUpper();
            dto.Apellido = dto.Apellido.ToUpper();

            Repository.UpdateUser((User) dto);
            await UnitOfWork.SaveChanges();
            await OutputPort.Handle();
        }
    }
}
