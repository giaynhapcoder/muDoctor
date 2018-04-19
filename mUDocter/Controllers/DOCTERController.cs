using System.Web.Mvc;
using Kaio.Core;
using Kaio.Web.UI.Attributes;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
     [RequiredAuthentication]
    public class DOCTERController : Controller
    {
        //
        // GET: /DOCTER/

        public ActionResult Index()
        {
            var data = DOCTER_UDRepo.List();
            return View(data);
        }

        public ActionResult Delete()
        {
            int id = int.Parse(Request.QueryString["id"]);
            DOCTER_UDRepo.Delete(id);
            var data = DOCTER_UDRepo.List();
            return View(data);
        }
        public ActionResult Add()
        {
            string id = Request.QueryString["Id"];
            int pr_id = 0;

            DOCTER_UD _o;
            _o = new DOCTER_UD();
            _o.status = (int)StatusGlobal.Activate;

            if (!string.IsNullOrWhiteSpace(id))
            {
                _o = DOCTER_UDRepo.GetByID(int.Parse(id));
                pr_id = _o.province_id;


                ViewBag.LSTIN_SERVICE = DOCTER_IN_SER_UDRepo.List(_o.id);
            }

            var _list = PROVINCE_UDRepo.List();
            ViewBag.ListPROVINCE = new SelectList(_list, "id", "name", pr_id);


            ViewBag.ListSERVICE = SERVICE_UDRepo.List();

            return View(_o);
        }

        [HttpPost]
        public ActionResult Add(FormCollection f)
        {
            bool addnew = false;

            DOCTER_UD o = DOCTER_UDRepo.GetByID(int.Parse(f["Id"]));
            if (o == null)
            {
                addnew = true;
                o = new DOCTER_UD();
            }

            TryUpdateModel(o, f.ToValueProvider());


            //o.user_id = DOCTER_UDRepo.Save(o);

            // Add user
            USER_UD userUd = new USER_UD();
            

            // add new
            if (!addnew)
            {
                userUd = USER_UDRepo.GetByID(o.user_id);
                userUd.phone = f["phone"];
                //userUd.password = f["password"].Password();
                userUd.full_name = o.name;
                userUd.address = o.address;
                USER_UDRepo.Save(userUd);
                
            }
            else
            {
                if (USER_UDRepo.GetByUsername(userUd.username) == null)
                {
                    userUd.username = f["email"];
                    userUd.phone = f["phone"];
                    userUd.password = f["password"].Password();
                    userUd.full_name = o.name;
                    userUd.address = o.address;
                    o.user_id = USER_UDRepo.Save(userUd);
                    DOCTER_UDRepo.Save(o);
                }
                else
                {
                    ViewBag.Msg = "Email đã được đăng ký!";
                    return View();

                }
                
            }

            DOCTER_UDRepo.Save(o);

            DOCTER_IN_SER_UDRepo.Delete(o.id);
            if (!string.IsNullOrWhiteSpace(f["service_ids"]))
            {
                // Add service
                var item_id = f["service_ids"].Split(',');
                foreach (var a_id in item_id)
                {
                    DOCTER_IN_SER_UD at = new DOCTER_IN_SER_UD();
                    at.price = int.Parse(f["price_" + o.id]);
                    at.service_id = int.Parse(a_id);
                    at.docter_id = o.id;
                    DOCTER_IN_SER_UDRepo.Save(at);
                }
            }

            return RedirectToAction("Index");
        }

    }
}
