using System.Web.Services.Description;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using TopGym_System.Models;
using System.IO;

namespace TopGym_System.Controllers
{
    public static class BitmapExtention
    {
        public static byte[] ConvertBitmapToByteArray(this Bitmap bitmap) 
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        public JsonResult getItemUnitPrice(int itemId, int itemId2 )
        {
            var x = db.categories.SingleOrDefault(a => a.Id == itemId2).Id;
            if (x == 1)
            {
                decimal? Price = db.Subscriptions.Single(model => model.Id == itemId).PricePerGym;
                return Json(Price, JsonRequestBehavior.AllowGet);
            }
            else if (x== 2){
                decimal? Price = db.Subscriptions.Single(model => model.Id == itemId).PricePerGymAndCardio;
                return Json(Price, JsonRequestBehavior.AllowGet);
            }
            else {
                decimal? Price = db.Subscriptions.Single(model => model.Id == itemId).PricePerGymAndCardio;
                return Json(Price, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult List(Members members)
        {
           
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.PrintMembers().Where(a=>a.IsDelete ==false ).ToList(),JsonRequestBehavior.AllowGet);

        }
        public JsonResult Add(Members members)
        {
            members.Start_Date = DateTime.Now;
            if (members.SubscriptionId == 1 || members.SubscriptionId == 11)
            {
                members.End_Date = DateTime.Now.AddDays(29);

            }
            else if (members.SubscriptionId == 2)
            {
                members.End_Date = DateTime.Now.AddDays(14);
            }
            else if (members.SubscriptionId == 3 || members.SubscriptionId == 8)
            {
                members.End_Date = DateTime.Now.AddDays(88);
            }
            else if (members.SubscriptionId == 4 || members.SubscriptionId == 9)
            {
                members.End_Date = DateTime.Now.AddDays(177);
            }
            else if (members.SubscriptionId == 5 || members.SubscriptionId == 10)
            {
                members.End_Date = DateTime.Now.AddDays(359);
            }
            else if (members.SubscriptionId == 7)
            {
                members.End_Date = DateTime.Now.AddDays(58);

            }
       

         
            db.members.Add(members);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return Json(db.members.FirstOrDefault(x => x.Id == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Members members)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.members.FirstOrDefault(x => x.Id == members.Id);
            if (data != null)
            {

                data.Start_Date = db.members.FirstOrDefault(a=>a.Id == members.Id).Start_Date ;
                if (members.SubscriptionId == 1 || members.SubscriptionId == 11)
                {
                    members.End_Date = data.Start_Date.AddDays(29);

                }
                else if (members.SubscriptionId == 2)
                {
                    members.End_Date = data.Start_Date.AddDays(14);
                }
                else if (members.SubscriptionId == 3 || members.SubscriptionId == 8)
                {
                    members.End_Date = data.Start_Date.AddDays(88);
                }
                else if (members.SubscriptionId == 4 || members.SubscriptionId == 9)
                {
                    members.End_Date = data.Start_Date.AddDays(177);
                }
                else if (members.SubscriptionId == 5 || members.SubscriptionId == 10)

                {
                    members.End_Date = data.Start_Date.AddDays(359);
                }
                else if (members.SubscriptionId == 7)

                {
                    members.End_Date = data.Start_Date.AddDays(58);
                }
                data.End_Date = members.End_Date;
                data.MemberName = members.MemberName;
                data.Height = members.Height;

                data.MemberWeight = members.MemberWeight;
                data.PhoneNumber = members.PhoneNumber;


                data.CategoryId = members.CategoryId;
                data.GenderTypeId = members.GenderTypeId;

                data.SubscriptionId = members.SubscriptionId;
                data.SubscriptionPrice = members.SubscriptionPrice;
                data.SubscriptionPriceDiscount = members.SubscriptionPriceDiscount;
                data.Paid = members.Paid;



                data.Notes = members.Notes;
                db.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }     
        public bool Remove(int id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.members.FirstOrDefault(m => m.Id == id);
                    if (q != null)
                    {
                        q.IsDelete = true;
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public JsonResult Delete(int ID)
        {


            return Json(Remove(ID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
          

            ViewBag.CategoryId = new SelectList(db.categories, "Id", "CategoryName");
            ViewBag.SubscriptionId = new SelectList(db.Subscriptions, "Id", "SubscriptionName");
            ViewBag.GendertypeId = new SelectList(db.GenderTypes, "Id", "GenderName");

          
            var members = db.members.Include(m => m.Category).Include(m => m.Subscription);
            return View(members.ToList());



        }
        [HttpPost]
        public ActionResult PrintMembersData()
        {
            var list = db.PrintMembers().Where(a => a.IsDelete == false);

      
            string DataSet = "General";
            string Path = "~/Reporting/RDLC/MembersReport.rdlc";
            Session["Path"] = Path;
            Session["DataSet"] = DataSet;
            Session["DataResult"] = list;
            return Redirect("~/Reporting/Forms/MembersForm.aspx");


        }
        [HttpPost]
        public ActionResult PrintDataRDLCById(int id)
        {
            var list = db.PrintMembers().Where(a => a.IsDelete == false && a.Id == id);

        
            string DataSet = "General";
            string Path = "~/Reporting/RDLC/MembersReport.rdlc";
            Session["Path"] = Path;
            Session["DataSet"] = DataSet;
            Session["DataResult"] = list;
            return Redirect("~/Reporting/Forms/MembersForm.aspx");


        }

        [HttpGet]
        public ActionResult CreateQrCode() 
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateQrCode(QRCodeModel myQRCode)
        {
            using (QRCodeGenerator qRCodeGenerator = new QRCodeGenerator())
            using (QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(
              myQRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qRCode = new QRCode(qRCodeData))

            {
                Bitmap QrCodeImage = qRCode.GetGraphic(20);
                byte[] bitmapArray = QrCodeImage.ConvertBitmapToByteArray();
                string url = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(bitmapArray));
                ViewBag.QrCode = url;
                Session["QR"] = ViewBag.QrCode;
            }
                return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
