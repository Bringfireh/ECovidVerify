using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECovidVerify.Models;

namespace ECovidVerify.Controllers
{
    public class VaccineInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VaccineInfoes
        public ActionResult Index()
        {
            var vaccineInfo = db.VaccineInfo.Include(v => v.PatientInfo);
            return View(vaccineInfo.ToList());
        }

        // GET: VaccineInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineInfo vaccineInfo = db.VaccineInfo.Find(id);
            if (vaccineInfo == null)
            {
                return HttpNotFound();
            }
            return View(vaccineInfo);
        }

        // GET: VaccineInfoes/Create
        public ActionResult Create()
        {
            ViewBag.PatientInfoId = new SelectList(db.PatientInfo, "Id", "FirstName");
            return View();
        }

        // POST: VaccineInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientInfoId,DateOfVaccination,VaccineType,Jab")] VaccineInfo vaccineInfo)
        {
            if (ModelState.IsValid)
            {
                db.VaccineInfo.Add(vaccineInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientInfoId = new SelectList(db.PatientInfo, "Id", "FirstName", vaccineInfo.PatientInfoId);
            return View(vaccineInfo);
        }

        // GET: VaccineInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineInfo vaccineInfo = db.VaccineInfo.Find(id);
            if (vaccineInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientInfoId = new SelectList(db.PatientInfo, "Id", "FirstName", vaccineInfo.PatientInfoId);
            return View(vaccineInfo);
        }

        // POST: VaccineInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientInfoId,DateOfVaccination,VaccineType,Jab")] VaccineInfo vaccineInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccineInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientInfoId = new SelectList(db.PatientInfo, "Id", "FirstName", vaccineInfo.PatientInfoId);
            return View(vaccineInfo);
        }

        // GET: VaccineInfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineInfo vaccineInfo = db.VaccineInfo.Find(id);
            if (vaccineInfo == null)
            {
                return HttpNotFound();
            }
            return View(vaccineInfo);
        }

        // POST: VaccineInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VaccineInfo vaccineInfo = db.VaccineInfo.Find(id);
            db.VaccineInfo.Remove(vaccineInfo);
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
