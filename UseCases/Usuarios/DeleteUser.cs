
using ExceptionHandler;
using Services;
using UseCases.Usuarios.Services;

namespace UseCases.Usuarios
{
    public class DeleteUser : IDeleteUserInputPort
    {
        readonly IUnitOfWork UnitOfWork;
        readonly IUserRepository Repository;
        readonly IDeleteUserOutputPort OutputPort;

        public DeleteUser(IUnitOfWork unitOfWork, IUserRepository repository, IDeleteUserOutputPort outputPort)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            OutputPort = outputPort;
        }

        public async ValueTask Handle(int id)
        {
            if (id < 1)
                throw new BadRequestException("Ingrese el id del usuario");

            var User = await Repository.GetUserById(id);
            if (User == null) 
                throw new BadRequestException("No se encontró el usuario en la base de datos.");
           
            Repository.DeleteUser(User);
            await UnitOfWork.SaveChanges();
            await  OutputPort.Handle();
        }
    }
}
