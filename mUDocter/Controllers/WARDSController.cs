using System.Web.Mvc;
using Kaio.Web.UI.Attributes;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
     [RequiredAuthentication]
    public class WARDSController : Controller
    {
        //
        // GET: /WARDS/

        public ActionResult Index()
        {

            string dictrct_id = Request.QueryString["dictrct_id"];
            var _list = DICTRCT_UDRepo.List();

            if (string.IsNullOrWhiteSpace(dictrct_id))
            {
                dictrct_id = _list[0].id.ToString();
            }

            ViewBag.ListDICTRCT = new SelectList(_list, "id", "name", int.Parse(dictrct_id));

            var dictrct = DICTRCT_UDRepo.GetByID(int.Parse(dictrct_id));
            ViewBag.dictrct_id = dictrct.id;
            ViewBag.dictrct_Name = dictrct.name;

            int totalRows;
            var data = WARDS_UDRepo.List(int.Parse(dictrct_id));

            return View(data);
        }

        public ActionResult Add()
        {
            string id = Request.QueryString["Id"];
            string dictrct_id = Request.QueryString["dictrct_id"];
            int pr_id = string.IsNullOrWhiteSpace(dictrct_id) ? 1 : int.Parse(dictrct_id);

            WARDS_UD _o;
            _o = new WARDS_UD();
            _o.status = (int)StatusGlobal.Activate;

            if (!string.IsNullOrWhiteSpace(id))
            {
                _o = WARDS_UDRepo.GetByID(int.Parse(id));
                pr_id = _o.dictrct_id;
            }

            var dictrct = DICTRCT_UDRepo.GetByID(pr_id);

            var _list = DICTRCT_UDRepo.List(dictrct.province_id);
            ViewBag.ListDICTRCT = new SelectList(_list, "id", "name", pr_id);

            return View(_o);
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            WARDS_UD o = WARDS_UDRepo.GetByID(int.Parse(f["Id"])) ?? new WARDS_UD();

            TryUpdateModel(o, f.ToValueProvider());
            WARDS_UDRepo.Save(o);
            return RedirectToAction("Index", "WARDS", new { @dictrct_id = o.dictrct_id });
        }

        public ActionResult Delete()
        {
            WARDS_UD o = WARDS_UDRepo.GetByID(int.Parse(Request["id"]));
            WARDS_UDRepo.Delete(int.Parse(Request["id"]));

            return RedirectToAction("Index", "WARDS", new { @dictrct_id = o.dictrct_id });
        }

    }
}
