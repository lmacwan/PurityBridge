using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurityBridge
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            TempData["IsHomePage"] = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Equals("Home") 
                                        && filterContext.ActionDescriptor.ActionName.Equals("Index");
            base.OnActionExecuting(filterContext);
        }
    }
}
