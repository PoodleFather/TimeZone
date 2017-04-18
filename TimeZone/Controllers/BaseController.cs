using TimeZoneRepository;
using TimeZoneRepository.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeZone.Controllers
{
    public class BaseController : Controller
    {
        private Stopwatch timer;
        [Inject]
        public IUnitOfWork UW { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();

            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();
            string ControllerNActionName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "_" + filterContext.ActionDescriptor.ActionName;
            UW.PerformanceRepository.Insert(new Performance()
            {
                CurrentMethod = ControllerNActionName,
                DurationTime = timer.Elapsed.TotalSeconds
            });
            UW.PerformanceRepository.Save();
            base.OnActionExecuted(filterContext);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();

            UW.ErrorRepository.Insert(new Error()
            {
                ErrorMothod = controllerName + "_" + actionName,
                ErrorMessage = filterContext.Exception.Message
            });
            UW.ErrorRepository.Save();
            base.OnException(filterContext);
        }
    }
}