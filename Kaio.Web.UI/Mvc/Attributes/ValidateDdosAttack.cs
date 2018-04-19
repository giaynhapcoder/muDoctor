using System;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace Kaio.Web.UI.Attributes
{
    public class ValidateDdosAttack : ActionFilterAttribute
    {

        private HttpContextBase _context;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _context = filterContext.HttpContext;

            if (!IsValid())
            {

                throw new HttpException("Too many requests to the server.");
            }

            //   base.OnActionExecuting(filterContext);
        }

        private bool IsValid()
        {

            var _level = 2;// Convert.ToInt32(ConfigurationManager.AppSettings["AntiDdosLevel"]);
            /*  if (_level <= 0)
                  return true;

              if (_context.Request.Browser.Crawler ) return true;*/

            string _key = _level + HttpContext.Current.Request.UserHostAddress;

            var _hit = Convert.ToInt32(HttpContext.Current.Cache[_key]);

            if (_hit > _level)
                return false;
            _hit++;

           if (_hit == 1)
                HttpContext.Current.Cache.Add(_key, _hit, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);

            return true;
        }

    }
}
