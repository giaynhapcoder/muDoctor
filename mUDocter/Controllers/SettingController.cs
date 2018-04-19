using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kaio.Core.Extensions;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
    public class SettingController : Controller
    {
        //
        // GET: /Setting/

        public ActionResult Index()
        {
            var data = SETTING_UDRepo.List();
            return View(data);
        }

        public ActionResult Add()
        {
            string id = Request.QueryString["Id"];

            SETTING_UD _o;
            _o = new SETTING_UD();

            if (!string.IsNullOrWhiteSpace(id))
            {
                _o = SETTING_UDRepo.GetByID(id);
            }
            return View(_o);
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            SETTING_UD o = SETTING_UDRepo.GetByID(f["Id"]);
            int up = 1;
            if (o == null)
            {
                o = new SETTING_UD();
                up = 0;

            }

            TryUpdateModel(o, f.ToValueProvider());
            SETTING_UDRepo.Save(o, up);
            return RedirectToAction("Index");
        }

        //public ActionResult Delete()
        //{
        //    SETTING_UDRepo.Delete(Request["id"]);

        //    return RedirectToAction("Index");
        //}

    }
}
