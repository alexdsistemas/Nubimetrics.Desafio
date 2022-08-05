using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presenters.Exceptions
{
    public class ApiFiltroExepcionAttribute : ExceptionFilterAttribute
    {
        readonly ServiceException Servicio;

        public ApiFiltroExepcionAttribute(ServiceException servicio)
        {
            Servicio = servicio;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var ProblemDetails = await Servicio.Handle(context.Exception);
            context.Result = new ObjectResult(ProblemDetails)
            {
                StatusCode = ProblemDetails.Status
            };
            context.ExceptionHandled = true;

            await base.OnExceptionAsync(context);
        }
    }
}
