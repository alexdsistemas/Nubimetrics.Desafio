using Microsoft.AspNetCore.Mvc;

namespace Presenters.Exceptions
{
    public interface IExceptionHandler<TipoExepcion>
    {
        //ProblemDetails reporta problemas de peticiones http
        ValueTask<ProblemDetails> Handle(TipoExepcion exepcion);
    }
}
