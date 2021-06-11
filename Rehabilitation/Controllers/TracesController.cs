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
    public class TracesController : Controller
    {
        private RehabilitationEntities db = new RehabilitationEntities();

        // GET: Traces
        [RoleFilter(Role = "Admin")]
        public ActionResult Index()
        {
            var traces = db.Traces.Include(t => t.Patient);
            return View(traces.ToList());
        }

        public ActionResult TrainingHistory(string id)
        {
            var traces = db.Traces.Where(p => p.PatientId == id).Include(p => p.Patient).OrderByDescending(p => p.Time);
            return View(traces.ToList());
        }

        // GET: Traces/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trace trace = db.Traces.Find(id);
            if (trace == null)
            {
                return HttpNotFound();
            }
            return View(trace);
        }

        // GET: Traces/Create
        [RoleFilter(Role = "Admin")]
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name");
            return View();
        }

        // POST: Traces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RoleFilter(Role = "Admin")]
        public ActionResult Create([Bind(Include = "TraceId,PatientId,Exercise,Time,Eating_B,Eating_A,Grooming_B,Grooming_A,Bathing_B,Bathing_A,DressingUpperBody_B,DressingUpperBody_A,DressingLowerBody_B,DressingLowerBody_A,Toileting_B,Toileting_A,BladderManagement_B,BladderManagement_A,BowelManagement_B,BowelManagement_A,TransferBedChairWheelchair_B,TransferBedChairWheelchair_A,TransferToilet_B,TransferToilet_A,TransferTubShower_B,TransferTubShower_A,WalkOrWheelchair_B,WalkOrWeelchair_A,Stairs_B,Stairs_A,Compreshension_B,Compreshension_A,Expression_B,Expression_A,SocialInteraction_B,SocialInteraction_A,ProblemSolving_B,ProblemSolving_A,Memory_B,Memory_A")] Trace trace)
        {
            if (ModelState.IsValid)
            {
                db.Traces.Add(trace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", trace.PatientId);
            return View(trace);
        }

        // GET: Traces/Edit/5
        [RoleFilter(Role = "Admin")]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trace trace = db.Traces.Find(id);
            if (trace == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", trace.PatientId);
            return View(trace);
        }

        // POST: Traces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RoleFilter(Role = "Admin")]
        public ActionResult Edit([Bind(Include = "TraceId,PatientId,Exercise,Time,Eating_B,Eating_A,Grooming_B,Grooming_A,Bathing_B,Bathing_A,DressingUpperBody_B,DressingUpperBody_A,DressingLowerBody_B,DressingLowerBody_A,Toileting_B,Toileting_A,BladderManagement_B,BladderManagement_A,BowelManagement_B,BowelManagement_A,TransferBedChairWheelchair_B,TransferBedChairWheelchair_A,TransferToilet_B,TransferToilet_A,TransferTubShower_B,TransferTubShower_A,WalkOrWheelchair_B,WalkOrWeelchair_A,Stairs_B,Stairs_A,Compreshension_B,Compreshension_A,Expression_B,Expression_A,SocialInteraction_B,SocialInteraction_A,ProblemSolving_B,ProblemSolving_A,Memory_B,Memory_A")] Trace trace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "Name", trace.PatientId);
            return View(trace);
        }

        // GET: Traces/Delete/5
        [RoleFilter(Role = "Admin")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trace trace = db.Traces.Find(id);
            if (trace == null)
            {
                return HttpNotFound();
            }
            return View(trace);
        }

        // POST: Traces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RoleFilter(Role = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Trace trace = db.Traces.Find(id);
            db.Traces.Remove(trace);
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
