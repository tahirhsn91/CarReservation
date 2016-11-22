using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using CarReservation.Common.Helper;

namespace CarReservation.Common.Attributes
{
    public sealed class ValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            foreach (var item in actionContext.ActionArguments)
            {
                item.Value.IsValid();
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
