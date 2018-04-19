using System.Web.Security;

namespace System.Web.Mvc
{
    public class SessionAuthentication : AuthorizeAttribute
    {
        public string SessionId { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            /* var _context = _filterContext.HttpContext;

             //redirect if not authenticated
             if (!_context.Request.IsAuthenticated || (!string.IsNullOrWhiteSpace(SessionId) && _context.Session[SessionId] == null))
             {
                 //use the current url for the redirect
                 if (_context.Request.Url != null)
                 {
                     string _redirectOnSuccess = _context.Server.UrlEncode(_context.Request.Url.ToString());
                     //send them off to the login page
                     string _redirectUrl = string.Format("?ReturnUrl={0}", _redirectOnSuccess);
                     string _loginUrl = System.Configuration.ConfigurationManager.AppSettings["LoginUrl"];
                     _loginUrl = (!string.IsNullOrWhiteSpace(_loginUrl) ? _loginUrl : FormsAuthentication.LoginUrl) + _redirectUrl;

                     _context.Response.Redirect(_loginUrl, true);
                 }
             }*/
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
                throw new InvalidOperationException("Authorize Attribute Cannot Use Within Child Action Cache");
            ActionDescriptor actionDescriptor = filterContext.ActionDescriptor;
            bool flag1 = true;
            Type attributeType1 = typeof(AllowAnonymousAttribute);
            int num1 = flag1 ? 1 : 0;
            int num2;
            if (!actionDescriptor.IsDefined(attributeType1, num1 != 0))
            {
                ControllerDescriptor controllerDescriptor = filterContext.ActionDescriptor.ControllerDescriptor;
                bool flag2 = true;
                Type attributeType2 = typeof(AllowAnonymousAttribute);
                int num3 = flag2 ? 1 : 0;
                num2 = controllerDescriptor.IsDefined(attributeType2, num3 != 0) ? 1 : 0;
            }
            else
                num2 = 1;
            if (num2 != 0)
                return;
            /* if (AuthorizeCore(filterContext.HttpContext))
             {
                 HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
                 cache.SetProxyMaxAge(new TimeSpan(0L));
                 throw new NotImplementedException();
             }
             HandleUnauthorizedRequest(filterContext);*/

            var _context = filterContext.HttpContext;

            if (!_context.Request.IsAuthenticated || (!string.IsNullOrWhiteSpace(SessionId) && _context.Session[SessionId] == null))
            {
                //use the current url for the redirect
                if (_context.Request.Url != null)
                {
                    string _redirectOnSuccess = _context.Server.UrlEncode(_context.Request.Url.ToString());
                    //send them off to the login page
                    string _redirectUrl = string.Format("?ReturnUrl={0}", _redirectOnSuccess);
                    string _loginUrl = System.Configuration.ConfigurationManager.AppSettings["LoginUrl"];
                    _loginUrl = (!string.IsNullOrWhiteSpace(_loginUrl) ? _loginUrl : FormsAuthentication.LoginUrl) + _redirectUrl;

                    _context.Response.Redirect(_loginUrl, true);
                }
            }
        }
    }
}
