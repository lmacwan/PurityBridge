using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace PurityBridge.Live
{
    public class TreatmentsController : RenderMvcController
    {
        public override ActionResult Index(Umbraco.Web.Models.RenderModel model)
        {
            return base.Index(model);
        }
    }
}
