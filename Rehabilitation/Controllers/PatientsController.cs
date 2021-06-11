using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rehabilitation.Filters;
using Rehabilitation.Models;

namespace Rehabilitation.Controllers
{
    [LoginFilter]
    public class PatientsController : Controller
    {
        private RehabilitationEntities db = new RehabilitationEntities();

        // GET: Patients
        [RoleFilter(Role = "Doctor")]
        public ActionResult Index(string search)
        {
            var patients = from m in db.Patients
                           select m;

            if (!String.IsNullOrEmpty(search))
            {
                patients = patients.Where(s => s.Name.Contains(search));
            }

            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (Session["Role"].ToString() == "Patient" && id != Session["Username"].ToString())
                return new HttpStatusCodeResult(401);
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        [RoleFilter(Role = "Doctor")]
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RoleFilter(Role = "Doctor")]
        public ActionResult Create([Bind(Include = "PatientId,Name,Birth,Sex,Job,Ethnicity,Adress,Workplace,FeeType,InsuranceId,InsuranceExpired,HospitalizedDate,Status,ReleasedOrDeath,Photo,DoctorId,Eating,Grooming,Bathing,DressingUpperBody,DressingLowerBody,Toileting,BladderManagement,BowelManagement,TransferBedChairWheelchair,TransferToilet,TransferTubShower,WalkOrWheelchair,Stairs,Compreshension,Expression,SocialInteraction,ProblemSolving,Memory")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.Created = DateTime.Now;
                patient.LastModified = DateTime.Now;
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", patient.DoctorId);
            return View(patient);
        }

        // GET: Patients/Edit/5
        [RoleFilter(Role = "Doctor")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", patient.DoctorId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RoleFilter(Role = "Doctor")]
        public ActionResult Edit([Bind(Include = "PatientId,Name,Birth,Sex,Job,Ethnicity,Adress,Workplace,FeeType,InsuranceId,InsuranceExpired,HospitalizedDate,Status,ReleasedOrDeath,Photo,DoctorId,Eating,Grooming,Bathing,DressingUpperBody,DressingLowerBody,Toileting,BladderManagement,BowelManagement,TransferBedChairWheelchair,TransferToilet,TransferTubShower,WalkOrWheelchair,Stairs,Compreshension,Expression,SocialInteraction,ProblemSolving,Memory,Created")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.LastModified = DateTime.Now;
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", patient.DoctorId);
            return View(patient);
        }

        [RoleFilter(Role = "Doctor")]
        public ActionResult EditFIM(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FIMModel model = new FIMModel();
            model.Patient = db.Patients.Find(id);
            if (model.Patient == null)
            {
                return HttpNotFound();
            }
            //ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", patient.DoctorId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RoleFilter(Role = "Doctor")]
        public ActionResult EditFIM(FIMModel model)
        {
            if (ModelState.IsValid)
            {
                Patient old = db.Patients.Find(model.Patient.PatientId);
                db.Entry(old).State = EntityState.Detached;

                model.Trace.PatientId = old.PatientId;
                model.Trace.Bathing_B = old.Bathing;
                model.Trace.Eating_B = old.Eating;
                model.Trace.Grooming_B = old.Grooming;
                model.Trace.DressingLowerBody_B = old.DressingLowerBody;
                model.Trace.DressingUpperBody_B = old.DressingUpperBody;
                model.Trace.Toileting_B = old.Toileting;
                model.Trace.BladderManagement_B = old.BladderManagement;
                model.Trace.BowelManagement_B = old.BowelManagement;
                model.Trace.TransferBedChairWheelchair_B = old.TransferBedChairWheelchair;
                model.Trace.TransferToilet_B = old.TransferToilet;
                model.Trace.TransferTubShower_B = old.TransferTubShower;
                model.Trace.WalkOrWheelchair_B = old.WalkOrWheelchair;
                model.Trace.Stairs_B = old.Stairs;
                model.Trace.Compreshension_B = old.Compreshension;
                model.Trace.Expression_B = old.Expression;
                model.Trace.SocialInteraction_B = old.SocialInteraction;
                model.Trace.ProblemSolving_B = old.ProblemSolving;
                model.Trace.Memory_B = old.Memory;

                model.Trace.Bathing_A = model.Patient.Bathing.Value;
                model.Trace.Eating_A = model.Patient.Eating.Value;
                model.Trace.Grooming_A = model.Patient.Grooming.Value;
                model.Trace.DressingLowerBody_A = model.Patient.DressingLowerBody.Value;
                model.Trace.DressingUpperBody_A = model.Patient.DressingUpperBody.Value;
                model.Trace.Toileting_A = model.Patient.Toileting.Value;
                model.Trace.BladderManagement_A = model.Patient.BladderManagement.Value;
                model.Trace.BowelManagement_A = model.Patient.BowelManagement.Value;
                model.Trace.TransferBedChairWheelchair_A = model.Patient.TransferBedChairWheelchair.Value;
                model.Trace.TransferToilet_A = model.Patient.TransferToilet.Value;
                model.Trace.TransferTubShower_A = model.Patient.TransferTubShower.Value;
                model.Trace.WalkOrWeelchair_A = model.Patient.WalkOrWheelchair.Value;
                model.Trace.Stairs_A = model.Patient.Stairs.Value;
                model.Trace.Compreshension_A = model.Patient.Compreshension.Value;
                model.Trace.Expression_A = model.Patient.Expression.Value;
                model.Trace.SocialInteraction_A = model.Patient.SocialInteraction.Value;
                model.Trace.ProblemSolving_A = model.Patient.ProblemSolving.Value;
                model.Trace.Memory_A = model.Patient.Memory.Value;

                model.Patient.LastModified = DateTime.Now;

                db.Entry(model.Patient).State = EntityState.Modified;
                //db.Entry(model.Trace).State = EntityState.Modified;
                db.Traces.Add(model.Trace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", model.Patient.DoctorId);
            return View(model);
            //if (ModelState.IsValid)
            //{
            //    db.Entry(patient).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", patient.DoctorId);
            //return View(patient);
        }

        // GET: Patients/Delete/5
        [RoleFilter(Role = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RoleFilter(Role = "Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                return new HttpStatusCodeResult(409);
            }
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
