using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TopGym_System.Models;

namespace TopGym_System.Controllers
{
    public class GenderTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GenderTypes
        public ActionResult Index()
        {
            return View(db.GenderTypes.ToList());
        }

        // GET: GenderTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderType genderType = db.GenderTypes.Find(id);
            if (genderType == null)
            {
                return HttpNotFound();
            }
            return View(genderType);
        }

        // GET: GenderTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenderTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GenderName")] GenderType genderType)
        {
            if (ModelState.IsValid)
            {
                db.GenderTypes.Add(genderType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genderType);
        }

        // GET: GenderTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderType genderType = db.GenderTypes.Find(id);
            if (genderType == null)
            {
                return HttpNotFound();
            }
            return View(genderType);
        }

        // POST: GenderTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GenderName")] GenderType genderType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genderType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genderType);
        }

        // GET: GenderTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderType genderType = db.GenderTypes.Find(id);
            if (genderType == null)
            {
                return HttpNotFound();
            }
            return View(genderType);
        }

        // POST: GenderTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenderType genderType = db.GenderTypes.Find(id);
            db.GenderTypes.Remove(genderType);
            db.SaveChanges();
            return RedirectToAction("Index");
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
