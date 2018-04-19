using System;
using System.Configuration;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Repo;

namespace mUDocter.Business
{
    public static class IWebContext
    {
        public static HttpContext Context { get { return HttpContext.Current; } }

        public static string UploadUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["uploadURL"].Length > 0 ? ConfigurationManager.AppSettings["uploadURL"] : "";
            }
        }

        public static int PageSize
        {
            get
            {
                int pageSize = 20;
                if (ConfigurationManager.AppSettings["PageSize"].Length > 0)
                {
                    pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                }
                return pageSize;
            }
        }
 
        public static int PageIndex
        {
            get
            {
                int pageIndex;

                var p = Context.Request["P"] ?? Context.Request["pageIndex"];

                int.TryParse(p, out pageIndex);

                return pageIndex > 0 ? pageIndex : 1;
            }
        }

        #region PageRender


        public static string PageRender(string pageFormatString, double totalRows)
        {
            return PageRender(pageFormatString, PageIndex, PageSize, totalRows);
        }

        public static string PageRender(string pageFormatString, int pageIndex, int pageSize, double totalRows)
        {

            var totalPage = (int)Math.Ceiling(totalRows / pageSize);

            if (totalPage <= 1) return string.Empty;

            const int pageButtonCount = 3;
            int min = pageIndex - pageButtonCount;
            int max = pageIndex + pageButtonCount;

            if (max > totalPage)
                min -= max - totalPage;
            else if (min < 1)
                max += 1 - min;

            var sb = new StringBuilder(1000);
            bool needDiv = false;


            sb.Append("<div class=\"row\">");
            
            sb.Append("<div class=\"col-sm-4\">");
            sb.AppendFormat("<div class=\"dataTables_info\" id=\"dataTables-example_info\" role=\"status\" aria-live=\"polite\">Showing {0} to {1} of {2} entries</div>", ((pageIndex-1) * pageSize) + 1, pageIndex * pageSize, totalRows);
            sb.Append("</div>");
            sb.Append("<div class=\"col-sm-8\">");
            sb.Append("<div class=\"dataTables_paginate paging_simple_numbers\" id=\"dataTables-example_paginate\">");
            sb.Append("<ul class=\"pagination\">");

            string disabled = "";
            if (pageIndex == 1)
            {
                disabled = "disabled";
                
            }
            sb.AppendFormat(
                    "<li class=\"paginate_button previous {0}\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_previous\"><a href=\"{1}\">Previous</a></li>", disabled,
                    string.Format(pageFormatString, pageIndex - 1));

            for (int i = 1; i <= totalPage; i++)
            {
                if (i <= 2 || i > totalPage - 2 || (min <= i && i <= max))
                {

                    string className = (i == pageIndex) ? "active" : "";

                    sb.AppendFormat("<li class=\"paginate_button {1}\" aria-controls=\"dataTables-example\" tabindex=\"{2}\"><a href=\"{0}\">{2}</a></li>", string.Format(pageFormatString, i), className, i);
                    needDiv = true;
                }
                else if (needDiv)
                {
                    sb.Append("<li class=\"paginate_button\"><a>...</a></li>");
                    needDiv = false;
                }
            }
            disabled = "disabled";
            if (pageIndex < totalPage)
            {
                disabled = "";
            }
            sb.AppendFormat("<li class=\"paginate_button next {0}\" aria-controls=\"dataTables-example\" tabindex=\"0\" id=\"dataTables-example_next\"><a href=\"{1}\">Next</a></li>", disabled, string.Format(pageFormatString, pageIndex + 1));     

            sb.Append("</ul>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();

        }
        #endregion


        public static void SetAuthenticationCookie(string username, string password, bool isPersit)
        {
            var Authticket = new
                          FormsAuthenticationTicket(1,
                          username,
                          DateTime.Now,
                          DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                          true,
                          string.Format("{0};{1}", username, password),
                          FormsAuthentication.FormsCookiePath);

            string hash = FormsAuthentication.Encrypt(Authticket);

            var Authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash)
            {
                HttpOnly = true,
                Path = FormsAuthentication.FormsCookiePath,
                Domain = FormsAuthentication.CookieDomain
            };

            if (Authticket.IsPersistent) Authcookie.Expires = Authticket.Expiration;

            Context.Response.AppendCookie(Authcookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();

            HttpCookie cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.UtcNow.AddYears(-1);
                Context.Response.AppendCookie(cookie);
            }

            Context.Session.Abandon();

        }

        public static USER_UD UserInfo
        {
            get
            {
                var _u = (USER_UD)Context.Session[CacheKeys.USER_INFO];
                if (_u == null)
                {

                    HttpCookie _authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];

                    if (_authCookie != null)
                    {
                        FormsAuthenticationTicket _authTicket = FormsAuthentication.Decrypt(_authCookie.Value);
                        var _id = new FormsIdentity(_authTicket);
                        var _principal = new GenericPrincipal(_id, null);
                        Context.User = _principal;
                        if (_authTicket != null)
                        {
                            string[] _userData = _authTicket.UserData.Split(';');

                            _u = USER_UDRepo.LOGIN(_userData[0], _userData[1], (int)USER_STATUS.ACTIVED);
                        }
                        Context.Session[CacheKeys.USER_INFO] = _u;
                    }
                }
                return _u;
            }
        }
    }
}
