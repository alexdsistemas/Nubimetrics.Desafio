using DTOs;
using Services;
using UseCases.Usuarios.Services;
using ViewModels;
#nullable disable

namespace Presenters
{
    public class GetAllUserPresenter : IGetAllUsersOutputPort, IPresenter<GetAllUserViewModel>
    {
        public GetAllUserViewModel Content { get; private set; }

        public ValueTask Handle(List<GetAllUserDto> users)
        {
            Content = new GetAllUserViewModel(users);
            return ValueTask.CompletedTask;
        }
    }
}
