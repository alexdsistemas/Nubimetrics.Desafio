using ExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presenters.Exceptions
{
    public class IGeneralExceptionHandler : IExceptionHandler<GeneralException>
    {
        public ValueTask<ProblemDetails> Handle(GeneralException exepcion)
        {
            var Problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = exepcion.Message,
                Detail = exepcion.Detail
            };
            return ValueTask.FromResult(Problem);
        }
    }
}
