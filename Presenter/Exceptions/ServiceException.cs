using ExceptionHandler;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Presenters.Exceptions
{
    public class ServiceException
    {
        readonly Dictionary<Type, Type> ManejadoresExepciones = new();

        public ServiceException()
        {
            Type[] Types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in Types)
            {
                var Handlers = type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));
                foreach (var handler in Handlers)
                {
                    var TipoExepcion = handler.GetGenericArguments()[0];
                    ManejadoresExepciones.TryAdd(TipoExepcion, type);
                }
            }

        }

        public ValueTask<ProblemDetails> Handle(Exception exception)
        {
            ValueTask<ProblemDetails> Result;

            if (ManejadoresExepciones.TryGetValue(exception.GetType(), out Type HandlerType))
            {
                var Handler = Activator.CreateInstance(HandlerType);
                Result = (ValueTask<ProblemDetails>)HandlerType.GetMethod("Handle").Invoke(Handler, new object[] { exception });
            }
            else
            {
                Result = new IGeneralExceptionHandler().Handle(new GeneralException("ha ocurrido un error al procesar la respuesta", "consulte al administrador del sistema"));
            }
            return Result;
        }
    }
}
