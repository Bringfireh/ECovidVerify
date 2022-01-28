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
    public class PatientInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientInfoes
        public ActionResult Index()
        {
            return View(db.PatientInfo.ToList());
        }

        // GET: PatientInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInfo patientInfo = db.PatientInfo.Find(id);
            if (patientInfo == null)
            {
                return HttpNotFound();
            }
            return View(patientInfo);
        }

        // GET: PatientInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,MiddleName,DateOfBirth,Gender,PhoneNumber,Email,Address,City,Zip,Race,Ethnicity,HealthInsurance,CHName,CHDateOfBirth,CHEmployer,InsuranceCompany,MemberID,GroupNo,NameOfInsured,RelationshipToInsured")] PatientInfo patientInfo)
        {
            if (ModelState.IsValid)
            {
                patientInfo.Id = Guid.NewGuid().ToString();
                db.PatientInfo.Add(patientInfo);
                db.SaveChanges();
                return RedirectToAction("Summary");
            }

            return View(patientInfo);
        }
        public ActionResult Summary()
        {

            return View();
        }
        // GET: PatientInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInfo patientInfo = db.PatientInfo.Find(id);
            if (patientInfo == null)
            {
                return HttpNotFound();
            }
            return View(patientInfo);
        }

        // POST: PatientInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,MiddleName,DateOfBirth,Gender,PhoneNumber,Email,Address,City,Zip,Race,Ethnicity,HealthInsurance,CHName,CHDateOfBirth,CHEmployer,InsuranceCompany,MemberID,GroupNo,NameOfInsured,RelationshipToInsured")] PatientInfo patientInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientInfo);
        }

        // GET: PatientInfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientInfo patientInfo = db.PatientInfo.Find(id);
            if (patientInfo == null)
            {
                return HttpNotFound();
            }
            return View(patientInfo);
        }

        // POST: PatientInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PatientInfo patientInfo = db.PatientInfo.Find(id);
            db.PatientInfo.Remove(patientInfo);
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
