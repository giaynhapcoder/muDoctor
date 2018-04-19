using System.Web.Mvc;
using Kaio.Core;
using Kaio.Web.UI.Attributes;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Repo;

namespace mUDocter.Controllers
{
    [RequiredAuthentication]
    public class USERController : Controller
    {
        //
        // GET: /USER/

        public ActionResult Index()
        {
            var data = PATIENT_UDRepo.List();
            return View(data);
        }
        public ActionResult Delete()
        {
            int id = int.Parse(Request.QueryString["id"]);
            PATIENT_UDRepo.Delete(id);
            var data = PATIENT_UDRepo.List();
            return View(data);
        }
        public ActionResult Add()
        {
            string id = Request.QueryString["id"];
            int pr_id = 0;

            PATIENT_UD _o;
            _o = new PATIENT_UD();
            _o.status = (int)StatusGlobal.Activate;

            _o = PATIENT_UDRepo.GetByID(int.Parse(id));
            pr_id = (int)_o.province_id;
            if (_o.province_id != null)
            {
                var _list = PROVINCE_UDRepo.List();
                ViewBag.ListPROVINCE = new SelectList(_list, "id", "name", pr_id);
            }       
            return View(_o);
        }

        [HttpPost]
        public ActionResult Add(FormCollection f)
        {
            bool addnew = false;

            PATIENT_UD o = PATIENT_UDRepo.GetByID(int.Parse(f["Id"]));
            if (o == null)
            {
                addnew = true;
                o = new PATIENT_UD();
            }

            TryUpdateModel(o, f.ToValueProvider());


            //o.user_id = PATIENT_UDRepo.Save(o);

            // Add user
            USER_UD userUd = new USER_UD();


            // add new
            if (!addnew)
            {
                userUd = USER_UDRepo.GetByID(o.user_id);
                userUd.phone = f["phone"];
                //userUd.password = f["password"].Password();
                userUd.full_name = o.full_name;
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
                    userUd.full_name = o.full_name;
                    userUd.address = o.address;
                    o.user_id = USER_UDRepo.Save(userUd);
                    PATIENT_UDRepo.Save(o);
                }
                else
                {
                    ViewBag.Msg = "Email đã được đăng ký!";
                    return View();

                }

            }

            PATIENT_UDRepo.Save(o);

            return RedirectToAction("Index");
        }

    }
}
