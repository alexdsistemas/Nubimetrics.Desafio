using UseCases.Usuarios.Services;

namespace Presenters
{
    public class DeleteUserPresenter : IDeleteUserOutputPort
    {
        public ValueTask Handle()
        {
            return ValueTask.CompletedTask;
        }
    }
}
