using UseCases.Usuarios.Services;

namespace Presenters
{
    public class UpdateUserPresenter : IUpdateUserOutputPort
    {
        public ValueTask Handle()
        {
            return ValueTask.CompletedTask;
        }
    }
}
