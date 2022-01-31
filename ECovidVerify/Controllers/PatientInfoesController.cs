using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECovidVerify.Models;
using QRCoder;

namespace ECovidVerify.Controllers
{
    public class PatientInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        public ActionResult Index()
        {
            return View(db.PatientInfo.ToList());
        }

       
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

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,MiddleName,DateOfBirth,Gender,PhoneNumber,Email,Address,City,Zip,Race,Ethnicity,HealthInsurance,CHName,CHDateOfBirth,CHEmployer,InsuranceCompany,MemberID,GroupNo,NameOfInsured,RelationshipToInsured")] PatientInfo patientInfo)
        {
            if (ModelState.IsValid)
            {
                patientInfo.Id = Guid.NewGuid().ToString();
                db.PatientInfo.Add(patientInfo);
                db.SaveChanges();
                string midinitial = (patientInfo.MiddleName != null) ? patientInfo.MiddleName.Substring(0, 1) : " ";
                string url = "Name: " + patientInfo.LastName +  " " + patientInfo.FirstName + " " + midinitial +  ", Vaccination Status: Vaccinated, " + "Vaccination No: "+ patientInfo.Id;
                GenerateQRCode(url);
                return RedirectToAction("Summary");
            }

            return View(patientInfo);
        }


        public EmptyResult GenerateQRCode(string urladd)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qg = new QRCodeGenerator();
                QRCodeData qrcodedata = qg.CreateQrCode(urladd, QRCodeGenerator.ECCLevel.Q);
                QRCode qR = new QRCode(qrcodedata);
                using(Bitmap b = qR.GetGraphic(20))
                {
                    b.Save(ms, ImageFormat.Png);
                    Session["QRCodeImage"] = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());

                }
            }
            return new EmptyResult();
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
