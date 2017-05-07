using HSIME.Infrastructure.CommonMethods;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HSIME.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Logger logger = LogHandler.LoggerInstance();

            if (filterContext.ExceptionHandled)
            {
                logger.Log(LogLevel.Error, filterContext.Exception);

                return;
            }
            logger.Log(LogLevel.Error, filterContext.Exception);
            filterContext.Result = new ViewResult
            {
                ViewName = "error-page"
            };
            filterContext.ExceptionHandled = true;

        }


    }
}