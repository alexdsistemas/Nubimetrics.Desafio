using ExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presenters.Exceptions
{
    internal class IUpdateExceptionHandler : IExceptionHandler<UpdateException>
    {
        public ValueTask<ProblemDetails> Handle(UpdateException exepcion)
        {
            Dictionary<string, string> Extensiones = new Dictionary<string, string>
            {
                {"entities", string.Join(",", exepcion.Entries) }
            };

            var Problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Error de actualización",
                Detail = exepcion.Message
            };
            Problem.Extensions.Add("invalid-params", Extensiones);
            return ValueTask.FromResult(Problem);
        }
    }
}
