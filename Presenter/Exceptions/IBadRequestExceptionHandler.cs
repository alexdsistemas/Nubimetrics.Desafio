using ExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presenters.Exceptions
{
    internal class IBadRequestExceptionHandler : IExceptionHandler<BadRequestException>
    {
        public ValueTask<ProblemDetails> Handle(BadRequestException exepcion)
        {
            var Problem = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                Title = exepcion.Message,
                Detail = exepcion.Detail
            };
            return ValueTask.FromResult(Problem);
        }
    }
}
