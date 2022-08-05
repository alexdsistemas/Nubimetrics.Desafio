using Services;
using UseCases.Usuarios.Services;
using ViewModels;

#nullable disable
namespace Presenters
{
    public class CreateUserPresenter : ICreateUserOutputPort, IPresenter<CreateUserViewModel>
    {
        public CreateUserViewModel Content {get; private set;}

        public ValueTask Handle(int userId)
        {
            Content = new CreateUserViewModel(userId);
            return ValueTask.CompletedTask;
        }
    }
}
