using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models.Data;
using IF4101_ProjectI.Models.Entities;
using LabMVC_15042021.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IF4101_ProjectI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IF4101_B91472_B92299Context _context;
        StudentDAO studentDAO;

        public StudentController(IF4101_B91472_B92299Context context)
        {
            _context = context;
        }

        // GET: StudentController
        public IActionResult Index(String param)
        {
            //llamar a la API para saber si el student existe
            if (GetParamToAuthenticate(param) != false)
            {
                //TODO: para el proyecto esto debe ser basado en el role, no en el email
                HttpContext.Session.SetString("user", param);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private bool GetParamToAuthenticate(String param)
        {
            studentDAO = new StudentDAO(_context);
            return param == "Yulissa1633";
        }

        public ActionResult GetEF()
        {
            studentDAO = new StudentDAO(_context);
            return Ok(studentDAO.GetStudentsEF());
        }          

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
