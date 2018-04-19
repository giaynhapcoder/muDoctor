using System.Web.Mvc;
using Kaio.Core;
using Kaio.Core.Extensions;
using mUDocter.Business;
using mUDocter.Business.Enums;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        //
        // GET: /Login/

        public ActionResult Index()
        {
            ViewBag.ReturnUrl = Request.QueryString["ReturnUrl"];
            return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            var pwd = f["password"].Password();
            var user = f["email"];
            bool autoLogin = f["remember"].IsBoolean();

            var obj = USER_UDRepo.LOGIN(user, pwd, (int) USER_STATUS.ACTIVED);
            if (obj != null)
            {
                IWebContext.SetAuthenticationCookie(user, pwd, autoLogin);
                var returnUrl = f["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return Redirect("/");
            }
            ViewBag.Msg = "Username or password is incorrect!";
            return View();
        }
        public ActionResult logOut()
        {
            ViewBag.ReturnUrl = Request.QueryString["ReturnUrl"];
            IWebContext.SetAuthenticationCookie(null, null, false);
            return Redirect("/");
        }
    }
}
