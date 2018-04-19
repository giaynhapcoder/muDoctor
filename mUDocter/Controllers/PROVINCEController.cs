using System.Web.Mvc;
using Kaio.Web.UI.Attributes;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
     [RequiredAuthentication]
    public class PROVINCEController : Controller
    {
        //
        // GET: /PROVINCE/

        public ActionResult Index()
        {
            var data = PROVINCE_UDRepo.List();
            return View(data);
        }

        public ActionResult Add()
        {
            string id = Request.QueryString["Id"];

            PROVINCE_UD _o;
            _o = new PROVINCE_UD();
            _o.status = (int)StatusGlobal.Activate;

            if (!string.IsNullOrWhiteSpace(id))
            {
                _o = PROVINCE_UDRepo.GetByID(int.Parse(id));
            }
            return View(_o);
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            PROVINCE_UD o = PROVINCE_UDRepo.GetByID(int.Parse(f["Id"])) ?? new PROVINCE_UD();

            TryUpdateModel(o, f.ToValueProvider());
            PROVINCE_UDRepo.Save(o);
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            PROVINCE_UDRepo.Delete(int.Parse(Request["id"]));

            return RedirectToAction("Index");
        }

    }
}
