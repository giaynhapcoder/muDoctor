using System;
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
    public class ApiController : Controller
    {
        //
        // GET: /Api/

        public ActionResult getSetting()
        {

            object data = SETTING_UDRepo.ListAPI();

            ResultData result = new ResultData();
            result.DATA = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getDictrct()
        {

            object data = DICTRCT_UDRepo.ListActive();
         
            ResultData result = new ResultData();
            result.DATA = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getWards()
        {
            int district_id = int.Parse(Request["district"]);
            object data = WARDS_UDRepo.List(district_id);
            ResultData result = new ResultData();
            result.DATA = data;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult getReason()
        {

            object data = REASON_TEMRepo.List((int)StatusGlobal.Activate);

            ResultData result = new ResultData();
            result.DATA = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult getBooking()
        {

            object data = null;
            if (!string.IsNullOrWhiteSpace(Request["d_id"]))
            {
                int d_id = int.Parse(Request["d_id"]);
                data = BOOKING_INFORepo.GetByDID(d_id);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Request["p_id"]))
                {
                    int p_id = int.Parse(Request["p_id"]);
                    data = BOOKING_INFORepo.GetByPID(p_id);
                }
            }
            ResultData result = new ResultData();
            result.DATA = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getOneBooking()
        {
            //var data Book
            int id = int.Parse(Request["id"]);
            int type = 0;
            if (!string.IsNullOrWhiteSpace(Request["t"]))
            {
                type = int.Parse(Request["t"]);
            }

            var data = BOOKING_INFORepo.GetByID(id);
            if (type > 0)
            {
                var doc = DOCTER_UDRepo.GetByID(data.docter_id);
                data.latitude = doc.latitude;
                data.longitude = doc.longitude;

            }

            ResultData result = new ResultData();
            result.DATA = data;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult rateBooking()
        {
            int id = int.Parse(Request["id"]);
            double r = double.Parse(Request["r"]);
            //string text = Request["t"];



            BOOKING_UD bookingUd = BOOKING_UDRepo.GetByID(id);
            //bookingUd.updated = DateTime.Now;
            bookingUd.rate = r;

            BOOKING_UDRepo.Save(bookingUd);

            ResultData result = new ResultData();
            result.Message = "Gửi đánh giá thành công trân trọng !";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult bookingStatus()
        {
            int id = int.Parse(Request["id"]);
            int stt = int.Parse(Request["stt"]);
            string text = Request["t"];
           


            BOOKING_UD bookingUd = BOOKING_UDRepo.GetByID(id);
            //bookingUd.updated = DateTime.Now;
            bookingUd.status = stt;
            if (!string.IsNullOrWhiteSpace(text))
            {
                bookingUd.comment = text;
            }
            
            BOOKING_UDRepo.Save(bookingUd);

            ResultData result = new ResultData();
            result.Message = "Cập nhập thành công !";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult booking()
        {
            int p_id = int.Parse(Request["p_id"]);
            
           int d_id = int.Parse(Request["d_id"]);

         int tam = int.Parse(Request["tam"]);
         int vs = int.Parse(Request["vs"]);


         double log = double.Parse(Request["log"]);
         double lat = double.Parse(Request["lat"]);
        
         string sdt = Request["sdt"];
         string text1 = Request["text"];
         string dt = Request["dt"];
          
     PATIENT_UD patientUd = PATIENT_UDRepo.GetByID(p_id);
 
  patientUd.phone = sdt;
  PATIENT_UDRepo.Save(patientUd);


  USER_UD userUd = USER_UDRepo.GetByID(patientUd.user_id);
  userUd.phone = sdt;
  USER_UDRepo.Save(userUd);


  BOOKING_UD bookingUd = new BOOKING_UD();
  bookingUd.docter_id = d_id;
  bookingUd.patient_id = p_id;
  bookingUd.comment = text1;
  bookingUd.tam_date = tam;
  bookingUd.vs_date = vs;
  bookingUd.longitude = log;
  bookingUd.latitude = lat;
  bookingUd.date_time = dt;

  int newid = BOOKING_UDRepo.Save(bookingUd);


            ResultData result = new ResultData();
        
            result.Message = "Đặt lịch thành công !";
            result.DATA = patientUd;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDocterDetail()
        {
            int u_id = int.Parse(Request["d_id"]);
            DOCTER_INFO docterInfo = DOCTER_INFORepo.GetByID(u_id);

            if (string.IsNullOrWhiteSpace(docterInfo.avartar))
            {
              
                string fb = USER_UDRepo.GetByID(docterInfo.user_id).facebook_id;
                if(!string.IsNullOrWhiteSpace(fb))
                    docterInfo.avartar = "https://graph.facebook.com/"+fb+"/picture?type=square";
            }

            docterInfo.SERVICE = SERVICERepo.List(docterInfo.id);

            ResultData result = new ResultData();
            result.DATA = docterInfo;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getAllDocter()
        {
            List<DOCTER_INFO> data = DOCTER_INFORepo.List((int)USER_STATUS.ACTIVED);
            ResultData result = new ResultData();
            result.DATA = data;

            return Json(result, JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult SavePatient()
        {
            int u_id = int.Parse(Request["u_id"]);
            PATIENT_UD patientUd = PATIENT_UDRepo.GetByUID(u_id);

            patientUd.full_name = Request["name"];
            patientUd.dob = Request["dob"];
            patientUd.info_p = Request["info"];
            patientUd.address = Request["addr"];
            patientUd.phone = Request["phone"];
            if (!string.IsNullOrWhiteSpace(Request["sex"]))
                patientUd.sex_id = int.Parse(Request["sex"]);
            if (!string.IsNullOrWhiteSpace(Request["lat"]))
                patientUd.latitude = float.Parse(Request["lat"]);
            if (!string.IsNullOrWhiteSpace(Request["lon"]))
                patientUd.longitude = float.Parse(Request["lon"]);

            PATIENT_UDRepo.Save(patientUd);

            var obj = USER_UDRepo.GetByID(patientUd.user_id);
            obj.address = patientUd.address;
            obj.phone = patientUd.phone;
            USER_UDRepo.Save(obj);

            ResultData result = new ResultData();
            result.ERR_CODE = 0;
            result.Message = "Cập nhập thông tin thành công !";
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult SaveDocter()
        {
            int u_id = int.Parse(Request["d_id"]);
            DOCTER_UD docterUd = DOCTER_UDRepo.GetByID(u_id);

            docterUd.name = Request["name"];
            docterUd.dob = Request["dob"];
            docterUd.info_p = Request["info"];
            docterUd.hospital = Request["hosp"];
            docterUd.address = Request["addr"];

            if (!string.IsNullOrWhiteSpace(Request["ya"]))
                docterUd.year = int.Parse(Request["ya"]);
            if (!string.IsNullOrWhiteSpace(Request["sex"]))
                docterUd.sex_id = int.Parse(Request["sex"]);
            if (!string.IsNullOrWhiteSpace(Request["lat"]))
                docterUd.latitude = float.Parse(Request["lat"]);
            if (!string.IsNullOrWhiteSpace(Request["lon"]))
                docterUd.longitude = float.Parse(Request["lon"]);

            DOCTER_UDRepo.Save(docterUd);

            ResultData result = new ResultData();
            result.ERR_CODE = 0;
            result.Message = "Cập nhập thông tin thành công !";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDocter()
        {
            int u_id = int.Parse(Request["u_id"]);
            DOCTER_INFO docterInfo = DOCTER_INFORepo.GetByUID(u_id);
            ResultData result = new ResultData();
          

            result.ERR_CODE = 0;
            result.Message = "";
            result.DATA = docterInfo;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getPatient()
        {
            int u_id = int.Parse(Request["u_id"]);
            PATIENT_INFO docterInfo = PATIENT_INFORepo.GetByUID(u_id);
            ResultData result = new ResultData();
            result.ERR_CODE = 0;
            result.Message = "";
            result.DATA = docterInfo;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

        public ActionResult SignIn()
        {
            USER_UD userUd = new USER_UD();
            userUd.username = Request["u"];
            userUd.password = Request["p"].Password();

            ResultData result = new ResultData();
            result.ERR_CODE = 1;
            result.TotalPages = 1;
            result.Message = "Tên đăng nhập hoặc mật khẩu không đúng !";

            var obj = USER_UDRepo.LOGIN_API(userUd.username, userUd.password, (int)USER_STATUS.ACTIVED);
            if (obj != null)
            {
                if (obj.user_type == (int)USER_TYPE.PATIENT_UD)
                {
                    var pobj = PATIENT_INFORepo.GetByUID(obj.id);
                    obj.p_id = pobj.id;
                    obj.latitude = pobj.latitude;
                    obj.longitude = pobj.longitude;
                }
                if (obj.user_type == (int)USER_TYPE.DOCTER_UD)
                {
                    var dobj = DOCTER_UDRepo.GetByUID(obj.id);
                    obj.d_id = dobj.id;
                    obj.latitude = dobj.latitude;
                    obj.longitude = dobj.longitude;
                }
                result.ERR_CODE = 0;
                result.Message = obj.id +"";
                result.DATA = obj;

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        string DictoJson(System.Collections.Specialized.NameObjectCollectionBase.KeysCollection key)
        {
            String str= "";
            foreach ( var entry in key)
            {
                str += entry.ToString();
            }
            return str;
        }
        public ActionResult FBLogin()
        {
          //  return Json(this.DictoJson(Request.Params.Keys), JsonRequestBehavior.AllowGet);

            String fb_id = Request["id"];
            String first_name = Request["first_name"];
            String email = Request["email"];

          
            ResultData result = new ResultData();
            result.ERR_CODE = 1;
            result.TotalPages = 1;
            var obj = USER_UDRepo.LOGIN_API(fb_id);



            string subPath = "/Uploads/FBAvartar";
            string extension = ".jpg";
            String str = "0";
            var filename = fb_id + extension;
            var path = Path.Combine(Server.MapPath(subPath), filename);
            str = subPath + "/" + filename;

            if (!System.IO.File.Exists(path))
            {

                bool exists = Directory.Exists(Server.MapPath(subPath));
                if (!exists)
                    Directory.CreateDirectory(Server.MapPath(subPath));

                using (WebClient client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri("http://graph.facebook.com/" + fb_id + "/picture?type=large"), path);
                }
            }

            if (obj == null)
            {
                USER_UD userUd = new USER_UD();
                userUd.facebook_id = fb_id;
                userUd.username = email;
                userUd.password = "123".Password();
                userUd.address = "Hà nội";
                userUd.full_name = first_name;
                userUd.email = email;
              
                userUd.status = (int) USER_STATUS.ACTIVED;

                obj = new USER_INFO();
                obj.id = userUd.id;
                obj.full_name = userUd.full_name;
                obj.username = userUd.username;
                obj.user_type = 0;
                 
                /// download facebook avartar
                /// 




  
                userUd.avartar = str;
                
                userUd.id = USER_UDRepo.Save(userUd);
            }
            else
            {
                if (obj.user_type == (int)USER_TYPE.PATIENT_UD)
                {
                    PATIENT_INFO pobj = PATIENT_INFORepo.GetByUID(obj.id);
                    obj.p_id = pobj.id;
                    obj.latitude = pobj.latitude;
                    obj.longitude = pobj.longitude;
                 

                }
                if (obj.user_type == (int)USER_TYPE.DOCTER_UD)
                {


                    DOCTER_UD dobj = DOCTER_UDRepo.GetByUID(obj.id);

                    if (dobj==null)
                    {
                     
                        dobj = new DOCTER_UD();
                        dobj.user_id = obj.id;
                        dobj.name = obj.full_name;
                        dobj.sex_id = 1;
                        dobj.address = obj.address;
                        dobj.dob = "";
                        dobj.star = 5;
                        DOCTER_UDRepo.Save(dobj);
                    }
                    obj.d_id = dobj.id;
                    obj.latitude = dobj.latitude;
                    obj.longitude = dobj.longitude;
                    dobj.avartar = str;




                }

            }
            result.ERR_CODE = 0;
            result.Message = obj.id + "";
            result.DATA = obj;
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateAvatar()
        {


            int id = int.Parse(Request["id"]);
            string avartar = Request["avartar"];
            var obj = USER_UDRepo.LOGIN_API_BY_ID(id);

 
            

            if (obj.user_type == (int)USER_TYPE.DOCTER_UD)
            {
                DOCTER_UD docterUd = DOCTER_UDRepo.GetByUID(id);
                docterUd.avartar = avartar;
                DOCTER_UDRepo.Save(docterUd);
         
            }
            ResultData result = new ResultData();
            result.ERR_CODE = 1;
            result.TotalPages = 1;
            result.ERR_CODE = 0;
            result.Message = obj.id + "";
            result.DATA = obj;



            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateUType()
        {
            int id = int.Parse(Request["id"]);
            int type = int.Parse(Request["t"]);
            var obj = USER_UDRepo.LOGIN_API_BY_ID(id);
            
            if (obj != null  )
            {

                var update = USER_UDRepo.GetByID(id);
                update.user_type = type;
             

                var userUd = USER_UDRepo.GetByID(id);
                if (type == (int)USER_TYPE.DOCTER_UD)
                {
                    USER_UDRepo.Save(update);
                    DOCTER_UD docterUd = new DOCTER_UD();
                    docterUd.user_id = userUd.id;
                    docterUd.name = userUd.full_name;
                    docterUd.sex_id = 1;
                    docterUd.address = userUd.address;
                    docterUd.dob = "";
                    docterUd.star = 5;
                    DOCTER_UDRepo.Save(docterUd);

                }
                else if (type == (int)USER_TYPE.PATIENT_UD)
                {
                    USER_UDRepo.Save(update);
                    PATIENT_UD patientUd = new PATIENT_UD();
                    patientUd.user_id = userUd.id;
                    patientUd.full_name = userUd.full_name;
                    patientUd.sex_id = 1;
                    patientUd.address = userUd.address;
                    PATIENT_UDRepo.Save(patientUd);
                }
            }
            obj = USER_UDRepo.LOGIN_API_BY_ID(id);
            if (obj!=null)
            {
                if (obj.user_type == (int)USER_TYPE.PATIENT_UD)
                {
                    var pobj = PATIENT_INFORepo.GetByUID(obj.id);
                    obj.p_id = pobj.id;
                    obj.latitude = pobj.latitude;
                    obj.longitude = pobj.longitude;
                }
                if (obj.user_type == (int)USER_TYPE.DOCTER_UD)
                {
                    var dobj = DOCTER_UDRepo.GetByUID(obj.id);
                    obj.p_id = dobj.id;
                    obj.latitude = dobj.latitude;
                    obj.longitude = dobj.longitude;
                }
            }
            
            ResultData result = new ResultData();
            result.ERR_CODE = 1;
            result.TotalPages = 1;
            result.ERR_CODE = 0;
            result.Message = obj.id + "";
            result.DATA = obj;

            return Json(result, JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult SignUp()
        {
            USER_UD userUd = new USER_UD();
            userUd.username = Request["username"];
            userUd.password = Request["password"].Password();
            userUd.full_name = Request["full_name"];
            userUd.address = Request["address"];
            userUd.phone = Request["phone"];
            userUd.email = Request["email"];
            if (!string.IsNullOrWhiteSpace(Request["user_type"]))
                userUd.user_type =int.Parse(Request["user_type"]);
            userUd.status = (int) USER_STATUS.ACTIVED;

            ResultData result = new ResultData();
            result.ERR_CODE = 1;
            result.TotalPages = 1;
            
            if (USER_UDRepo.GetByUsername(userUd.username) == null)
            {
                userUd.id = USER_UDRepo.Save(userUd);
                if (userUd.user_type == (int) USER_TYPE.DOCTER_UD)
                {
                    DOCTER_UD docterUd = new DOCTER_UD();
                    docterUd.user_id = userUd.id;
                    docterUd.name = userUd.full_name;
                    docterUd.sex_id = int.Parse(Request["gender"]);
                    docterUd.address = userUd.address;
                    docterUd.star = 5;
                    DOCTER_UDRepo.Save(docterUd);
                }
                else
                {
                    PATIENT_UD patientUd = new PATIENT_UD();
                    patientUd.user_id = userUd.id;
                    patientUd.full_name = userUd.full_name;
                    patientUd.sex_id = int.Parse(Request["gender"]);
                    patientUd.address = userUd.address;
                    PATIENT_UDRepo.Save(patientUd);
                }

                result.ERR_CODE = 0;
                result.Message = MessageTemplate.RegisterSuccess;
            }
            else
            {
                result.Message = "Địa chỉ email đã được sử dụng !";

            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult sendMail()
        {
            string mail = (Request["mail"]);
            string body = Request["body"];
            if (mail == null) return null;
            USER_UD user = null;
            user = USER_UDRepo.GetByUsername(mail);
            ResultData result = new ResultData();

            if (user == null)
            {
                result.ERR_CODE = 1;
                result.Message = "Không tìm thấy tài khoản người dùng trong cơ sở dữ liệu.";
                goto Done;

            }
            else result.ERR_CODE = 0;
            result.DATA = user;


            var fromAddress = new MailAddress("kmavnteam@gmail.com", "Bệnh Viện Phụ Sản Hà Nội");
            var toAddress = new MailAddress(mail, "");
            const string fromPassword = "khongmatkhau";
            const string subject = "Bệnh Viện Phụ Sản Hà Nội";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        Done:
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult changePass()
        {
            int u_id = int.Parse(Request["id"]);
            ResultData result = new ResultData();
            result.ERR_CODE = 1;
            USER_UD userUd = USER_UDRepo.GetByID(u_id);
            if (userUd != null)
            {
                userUd.password = Request["pass"].Password();
                USER_UDRepo.Save(userUd);
                result.ERR_CODE = 0;
            }
            result.Message = "Cập nhật thông tin thành công";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test()
        {       
            string mail = (Request["mail"]);
            if (mail == null) return null;
            USER_UD user = null;
            user = USER_UDRepo.GetByUsername(mail);           
            ResultData result = new ResultData();
            if (user==null) { result.ERR_CODE=1; }
            else result.ERR_CODE = 0;
            result.Message = "";
            result.DATA = user.email;            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
