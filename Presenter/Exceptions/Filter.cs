
using Microsoft.AspNetCore.Mvc;

namespace Presenters.Exceptions
{
    public static class Filter
    {
        public static void Register(MvcOptions options)
        {
            options.Filters.Add(new ApiFiltroExepcionAttribute(new ServiceException()));
        }
    }
}
