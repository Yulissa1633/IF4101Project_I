using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models;
using IF4101_ProjectI.Models.Data;
using IF4101_ProjectI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IF4101_ProjectI.Controllers
{
    public class CourseController : Controller
    {
        private readonly IF4101_B91472_B92299Context _context;
        CourseDAO courseDAO;

        public CourseController(IF4101_B91472_B92299Context context)
        {
            _context = context;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEF()
        {
            courseDAO = new CourseDAO(_context);
            return Ok(courseDAO.GetCoursesEF());
        }

        public IActionResult Insert([FromBody] Course course)
        {
            if (course.Id == "" || course.Name == "" || course.Schedule == "" || course.Semester == "" || course.Description == "")
            {
                return Error();
            }
            else
            {
                courseDAO = new CourseDAO(_context);
                int resultToReturn = courseDAO.Insert(course);

                return Ok(resultToReturn); //retornamos el 1 o el 0 ala vista
            }
        }



        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/DeleteP/5
        public IActionResult DeleteP(string value)
        {
         
                courseDAO = new CourseDAO(_context);
                int resultToReturn = courseDAO.Delete(value);

                return Ok(resultToReturn); //retornamos el 1 o el 0 ala vista
           
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
