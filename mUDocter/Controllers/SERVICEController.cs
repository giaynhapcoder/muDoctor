using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kaio.Web.UI.Attributes;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
     [RequiredAuthentication]
    public class SERVICEController : Controller
    {
        //
        // GET: /SERVICE/

        public ActionResult Index()
        {
            var data = SERVICE_UDRepo.List();
            return View(data);
        }

        public ActionResult Add()
        {
            string id = Request.QueryString["Id"];

            SERVICE_UD _o;
            _o = new SERVICE_UD();
            _o.status = (int)StatusGlobal.Activate;

            if (!string.IsNullOrWhiteSpace(id))
            {
                _o = SERVICE_UDRepo.GetByID(int.Parse(id));
            }
            return View(_o);
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            SERVICE_UD o = SERVICE_UDRepo.GetByID(int.Parse(f["Id"])) ?? new SERVICE_UD();

            TryUpdateModel(o, f.ToValueProvider());
            SERVICE_UDRepo.Save(o);
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            SERVICE_UDRepo.Delete(int.Parse(Request["id"]));

            return RedirectToAction("Index");
        }

    }
}
