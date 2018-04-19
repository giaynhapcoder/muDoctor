using mUDocter.Business.Repo.API;
using System.Web.Mvc;
using Kaio.Web.UI.Attributes;
using mUDocter.Business.Models.API;
using System.Collections.Generic;

namespace mUDocter.Controllers
{
     [RequiredAuthentication]
    public class BookingController : Controller
    {
        //
        // GET: /Booking/

        public ActionResult Index()
        {
            int id = int.Parse(Request["id"]);
            int usertype = int.Parse(Request["usertype"]);
            List<BOOKING_INFO> data;
            if (usertype == 0)
             data = BOOKING_INFORepo.GetByDID(id); 
            else 
             data = BOOKING_INFORepo.GetByPID(id);
            return View(data);
        }

    }
}
