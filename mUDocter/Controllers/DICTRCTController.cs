using System.Web.Mvc;
using Kaio.Web.UI.Attributes;
using mUDocter.Business;
using mUDocter.Business.Enums;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
     [RequiredAuthentication]
    public class DICTRCTController : Controller
    {
        //
        // GET: /DICTRCT/

        public ActionResult Index()
        {

            string province_id = Request.QueryString["province_id"];

            var _list = PROVINCE_UDRepo.List();

            if (string.IsNullOrWhiteSpace(province_id))
            {
                province_id = _list[0].id.ToString();
            }

            ViewBag.ListPROVINCE = new SelectList(_list, "id", "name", int.Parse(province_id));

            var province = PROVINCE_UDRepo.GetByID(int.Parse(province_id));
            ViewBag.province_id = province.id;
            ViewBag.province_Name = province.name;

            int totalRows;
            var data = DICTRCT_UDRepo.List(int.Parse(province_id), IWebContext.PageIndex, IWebContext.PageSize, out totalRows);

            string url = "/DICTRCT/?province_id=" + province_id + "&P={0}";

            ViewBag.Paging = IWebContext.PageRender(url, totalRows);
            return View(data);
        }

        public ActionResult Add()
        {
            string id = Request.QueryString["Id"];
            string province_id = Request.QueryString["province_id"];
            int pr_id = string.IsNullOrWhiteSpace(province_id) ? 1 : int.Parse(province_id);

            DICTRCT_UD _o;
            _o = new DICTRCT_UD();
            _o.status = (int)StatusGlobal.Activate;

            if (!string.IsNullOrWhiteSpace(id))
            {
                _o = DICTRCT_UDRepo.GetByID(int.Parse(id));
                pr_id = _o.province_id;
            }

            var _list = PROVINCE_UDRepo.List();
            ViewBag.ListPROVINCE = new SelectList(_list, "id", "name", pr_id);

            return View(_o);
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            DICTRCT_UD o = DICTRCT_UDRepo.GetByID(int.Parse(f["Id"])) ?? new DICTRCT_UD();

            TryUpdateModel(o, f.ToValueProvider());
            DICTRCT_UDRepo.Save(o);
            return RedirectToAction("Index", "DICTRCT", new { @province_id = o.province_id });
        }

        public ActionResult Delete()
        {
            DICTRCT_UD o = DICTRCT_UDRepo.GetByID(int.Parse(Request["id"]));
            DICTRCT_UDRepo.Delete(int.Parse(Request["id"]));

            return RedirectToAction("Index", "DICTRCT", new { @province_id = o.province_id });
        }

    }
}
