using System.Web.Mvc;
using Kaio.Web.UI.Attributes;
using mUDocter.Business.Enums;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
    [RequiredAuthentication]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            var Data = BOOKING_UDRepo.List();

            int DAT_LICH = 0;
            int BS_NHAN_LICH = 0;
            int HOAN_THANH = 0;
            int BN_HUY_LICH = 0;

            foreach (var bk in Data)
            {
                if (bk.status == (int) BOOKING_STATUS.DAT_LICH)
                {
                    DAT_LICH++;
                }
                if (bk.status == (int)BOOKING_STATUS.BS_NHAN_LICH)
                {
                    BS_NHAN_LICH++;
                }
                if (bk.status == (int)BOOKING_STATUS.HOAN_THANH)
                {
                    HOAN_THANH++;
                }
                if (bk.status == (int)BOOKING_STATUS.BN_HUY_LICH)
                {
                    BN_HUY_LICH++;
                }
            }
            ViewBag.DAT_LICH = DAT_LICH;
            ViewBag.BS_NHAN_LICH = BS_NHAN_LICH;
            ViewBag.HOAN_THANH = HOAN_THANH;
            ViewBag.BN_HUY_LICH = BN_HUY_LICH;
            return View();
        }

    }
}
