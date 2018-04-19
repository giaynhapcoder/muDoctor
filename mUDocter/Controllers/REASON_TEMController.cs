using System.Web.Mvc;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
    public class REASON_TEMController : Controller
    {
        //
        // GET: /REASON_TEM/

        public ActionResult Index()
        {
            var data = REASON_TEMRepo.List();
            return View(data);
        }

        public ActionResult Add()
        {
            string id = Request.QueryString["Id"];

            REASON_TEM _o;
            _o = new REASON_TEM();
            _o.Status = (int)StatusGlobal.Activate;

            if (!string.IsNullOrWhiteSpace(id))
            {
                _o = REASON_TEMRepo.GetByID(int.Parse(id));
            }
            return View(_o);
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            REASON_TEM o = REASON_TEMRepo.GetByID(int.Parse(f["Id"])) ?? new REASON_TEM();

            TryUpdateModel(o, f.ToValueProvider());
            REASON_TEMRepo.Save(o);
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            REASON_TEMRepo.Delete(int.Parse(Request["id"]));

            return RedirectToAction("Index");
        }

    }
}
