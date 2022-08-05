using DTOs;
using Entities;
using Services;
using System.Text;
using UseCases.Usuarios.Services;

namespace UseCases.Usuarios
{
    public class CreateUser : ICreateUserInputPort
    {
        readonly IUnitOfWork UnitOfWork;
        readonly IUserRepository Repository;
        readonly ICreateUserOutputPort OutputPort;

        public CreateUser(IUnitOfWork unitOfWork, ICreateUserOutputPort outputPort, IUserRepository repository)
        {
            UnitOfWork = unitOfWork;
            OutputPort = outputPort;
            Repository = repository;
        }

        public async ValueTask Handle(CreateUserDto dto)
        {
            //Paso la contraseña a base64 para no quedar expuesta
            dto.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(dto.Password));
            //Algo de regla de negocio para ejemplificar se debe guardar el nombre en letras mayusculas.
            dto.Nombre = dto.Nombre.ToUpper();
            dto.Apellido = dto.Apellido.ToUpper();

            var User = Repository.CreateUser((User) dto);
            
            await UnitOfWork.SaveChanges();
            
            await OutputPort.Handle(User.Id);
        }
    }
}
