using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using LinqToExcel.Attributes;
using System.IO;
using System.Collections.Generic;
using System.Web.Mvc;
using Kaio.Core;
using mUDocter.Business.Enums;
using mUDocter.Business.Models;
using mUDocter.Business.Models.API;
using mUDocter.Business.Repo;
using mUDocter.Business.Repo.API;
using mUDocter.Business.Util;
using System.Net;
using System.IO;
using System.Net.Mail;
namespace mUDocter.Controllers
{
    public class ExcelController : Controller
    {
        //
        // GET: /Excel/
        public ActionResult index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload()
        {
            String str = "0";
            if (Request.Files.Count > 0)
            {
                //string subPath = "/Uploads/" + DateTime.Now.ToString("yyyyMMdd");
                string subPath = "/Uploads/ExcelFile/";
              
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

        public Boolean  createAccount (user data)
        {
            USER_UD userUd = new USER_UD();
            userUd.username = data.email;
            userUd.password ="123".Password();

            userUd.full_name = data.name;
            userUd.address = data.address;
            userUd.phone = data.phone;
            userUd.email = data.email;
            userUd.facebook_id = data.fbid;

 
            userUd.user_type = (int)USER_TYPE.DOCTER_UD;
            userUd.status = (int)USER_STATUS.ACTIVED;

            
         

            if (USER_UDRepo.GetByUsername(userUd.username) == null)
            {

                userUd.id = USER_UDRepo.Save(userUd);


                DOCTER_UD docterUd = new DOCTER_UD();
                docterUd.user_id = userUd.id;
                docterUd.name = userUd.full_name;
                docterUd.sex_id =data.gender;
                docterUd.address = userUd.address;
                docterUd.star = 5;
                docterUd.info_p = data.info;
                docterUd.hospital = data.workPlace;
                docterUd.latitude = data.lat;
                docterUd.longitude = data.lng;
                DOCTER_UDRepo.Save(docterUd);             
            }
            else
            {
                return false;

            }
            return true;
        }
    
    public ActionResult execute()
        {

            var file = Request["textfile"];
            if (file == null) return null;
            var path = Path.Combine(Server.MapPath(file));
            var excel = new ExcelQueryFactory(path);
            var workSheetrange = from c in excel.Worksheet() select c;
            
            var range = workSheetrange.ToList();
            List<user> list = new List<user>();
            List<user> listFailed = new List<user>();

            for (int i = 0; i < range.Count(); i++)
            {
                var temp = range[i];
                user a = new user();
                if (temp[0].ToString().Length < 3) continue;
                a.name = temp[0];
                a.workPlace = temp[1];
                a.info = temp[2];
                a.phone = (temp[3]);
                a.address = temp[4];
                a.setGender(temp[5]); // t them cai gioi tinh
                a.setEmail(temp[6]);
                /// dung try catch de tranh loi su ly toa do
                try {
                     a.lat = Double.Parse(temp[7]);
                     a.lng = Double.Parse(temp[8]);
                }catch (Exception e)
                {
                    // gap loi su ly toa do
                   

                }
                list.Add(a);

            }
            //### SEND TO QUYNH ##############
            // kieu foreach nay sau nay hoc nhe :3 cu dung cach for cu di :v 
            // khong loan day :)
            /* cach foreach cu 
                list.ForEach(delegate(user data){

                        
                })
             */

            // con cach nay la cach moi 
            
            list.ForEach((user data) =>
            {
                
               var success = this.createAccount(data);
                // kiem tra xem tao tai khoan thanh ko khong khong thi dua vao listFailed
                if (!success) listFailed.Add(data);

            });
            ViewBag.listFailed = listFailed;



            return View() ;
        }
        public class user
        {
            public string name { get; set; }
            public string workPlace { get; set; }
            public string info { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
            public double lat;
            public double lng;
            private int  _gender;
            private string _email;
            private string _fbid;

            ///  
            ///  cau ve doc them ve getter voi setter cua c# nhe.
            ///  
            public string fbid { get { return this._fbid; } }
            public string email { get { return this._email; } }

            public void setEmail(string input)
            {
                // ham su ly email 

                if (input.IndexOf("@")>0) // neu co @ thi do ko phai la fbid
                {
                    this._fbid = null;
                    this._email = input;
                }
                else // neu la fbid
                {
                    this._fbid = input;
                    this._email = input+"@facebook.com";
                }
            }

            public void setGender(string str)
            {
                if (str.ToLower().Equals("nam")) this._gender= 2; // chuyen gender tu string thanh int
                else this._gender = 1;
            }
            public int gender  {
               get {return this._gender; }
            }
        }

    }
}
