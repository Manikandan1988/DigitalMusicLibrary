using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalMusicLibrary.Filters
{
    public class AdminRoleValidateFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsValidUser(filterContext))
            {
                // Unauthorized!
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        private bool IsValidUser(AuthorizationContext context)
        {
            if (!string.IsNullOrWhiteSpace(Convert.ToString(context.HttpContext.Session["RoleID"]))
                 && !string.IsNullOrWhiteSpace(Convert.ToString(context.HttpContext.Session["UserName"]))
                 && Convert.ToString(context.HttpContext.Session["RoleID"]) == "1")
                return true;
            else
                return false;

        }
    }
}