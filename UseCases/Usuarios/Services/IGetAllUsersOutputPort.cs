using DTOs;
using Services;

namespace UseCases.Usuarios.Services
{
    public interface IGetAllUsersOutputPort : IPort<List<GetAllUserDto>>
    {
    }
}
