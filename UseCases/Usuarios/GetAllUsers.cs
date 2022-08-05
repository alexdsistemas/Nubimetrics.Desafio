using DTOs;
using Services;
using UseCases.Usuarios.Services;

namespace UseCases.Usuarios
{
    public class GetAllUsers : IGetAllUsersInputPort
    {
        readonly IUnitOfWork UnitOfWork;
        readonly IUserRepository Repository;
        readonly IGetAllUsersOutputPort OutputPort;

        public GetAllUsers(IUnitOfWork unitOfWork, IUserRepository repository, IGetAllUsersOutputPort outputPort)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
            OutputPort = outputPort;
        }

        public async ValueTask Handle()
        {
            var Users = await Repository.GetAllUsers();

            List<GetAllUserDto> ListDtos = new List<GetAllUserDto>();

            foreach (var user in Users)
            {
                ListDtos.Add((GetAllUserDto)user);
            }
            
             await ValueTask.FromResult(OutputPort.Handle(ListDtos));
        }
    }
}
