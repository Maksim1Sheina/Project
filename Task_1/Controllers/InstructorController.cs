using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_1.Data_Access_Layer;
using Task_1.Models;
using Task_1.ViewModels;

namespace Task_1.Controllers
{
    public class InstructorController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Instructor
        public ActionResult Index(int? id, int? CourseID)
        {
            var viewModel = new InstructorIndexData();
            // Using eager loading.
            viewModel.Instructors = db.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses.Select(c => c.Department))
                .OrderBy(i => i.LastName);

            if(id != null)
            {
                ViewBag.InstructorID = id.Value;

                // Also, we can use .Single(s => s.ID == id.Value). It's correct, too.
                viewModel.Courses = viewModel.Instructors.Where(
                    s => s.ID == id.Value).Single().Courses;
                
            }

            if(CourseID != null)
            {
                ViewBag.CourseID = CourseID.Value;
                // Explicit loading.
                var selectedCourse = viewModel.Courses.Where(x => x.CourseID == CourseID).Single();
                db.Entry(selectedCourse).Collection(x => x.Enrollments).Load();
                foreach(Enrollment e in selectedCourse.Enrollments)
                {
                    db.Entry(e).Reference(x => x.Student).Load();
                }

                viewModel.Enrollments = selectedCourse.Enrollments;
            }

            /*if (CourseID != null)
            {
                ViewBag.CourseID = CourseID.Value;
                // Lazy loading.
                viewModel.Enrollments = viewModel.Courses.Where(
                    s => s.CourseID == CourseID.Value).Single().Enrollments;
            }*/
            
            //var instructors = db.Instructors.Include(i => i.OfficeAssignment);

            return View(viewModel);
        }

        // GET: Instructor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.OfficeAssigments, "InstructorID", "Location");
            return View();
        }

        // POST: Instructor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstMidName,HireDate")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.OfficeAssigments, "InstructorID", "Location", instructor.ID);
            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.OfficeAssigments, "InstructorID", "Location", instructor.ID);
            return View(instructor);
        }

        // POST: Instructor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstMidName,HireDate")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.OfficeAssigments, "InstructorID", "Location", instructor.ID);
            return View(instructor);
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
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
