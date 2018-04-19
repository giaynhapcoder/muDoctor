using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mUDocter.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /UploadController/

        [HttpPost]
        public ActionResult Index()
        {
            String fd = Request.QueryString["f"];
            String str = "0";
            if (Request.Files.Count > 0)
            {
                //string subPath = "/Uploads/" + DateTime.Now.ToString("yyyyMMdd");
                string subPath = "/Uploads/" + fd + "/" + DateTime.Now.ToString("yyyyMMdd");
                if (string.IsNullOrWhiteSpace(fd))
                {
                    subPath = "/Uploads/" + DateTime.Now.ToString("yyyyMMdd");
                }

                bool exists = Directory.Exists(Server.MapPath(subPath));

                if (!exists)
                    Directory.CreateDirectory(Server.MapPath(subPath));

                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {

                    string extension = Path.GetExtension(file.FileName);

                    var filename = DateTime.Now.ToString("yyyyMMddhhmmss") + extension;
                    var path = Path.Combine(Server.MapPath(subPath), filename);
                    file.SaveAs(path);

                    str = subPath + "/" + filename;

                }
            }

            return Json(str, JsonRequestBehavior.AllowGet);
        }

    }
}
