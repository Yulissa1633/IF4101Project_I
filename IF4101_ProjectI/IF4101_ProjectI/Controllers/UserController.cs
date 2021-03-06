using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models;
using IF4101_ProjectI.Models.Data;
using IF4101_ProjectI.Models.Entities;
using LabMVC_15042021.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IF4101_ProjectI.Controllers
{
    public class UserController : Controller
    {
        private readonly IF4101_B91472_B92299Context _context;
        UserDAO userDAO;

        public UserController(IF4101_B91472_B92299Context context)
        {
            _context = context;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEF()
        {
            userDAO = new UserDAO(_context);
            return Ok(userDAO.GetUsersEF());
        }

        public UserProfile GetUserProfile([FromBody] Param userp)
        {
            userDAO = new UserDAO(_context);
            return userDAO.GetUserProfile(userp);
        }

        public IActionResult Insert([FromBody] UserProfile user)
        {
            if (user.Email == "" || user.Name == "" || user.User == "" || !(user.Email.Contains("@")))
            {
                return Error();
            }
            else
            {
                userDAO = new UserDAO(_context);
                int resultToReturn = userDAO.Insert(user);

                return Ok(resultToReturn); //retornamos el 1 o el 0 ala vista
            }                      
        }

        public IActionResult Update([FromBody] UserProfile userp2)
        {
            if (userp2.Email == "" || userp2.Name == "" || userp2.User == "" || !(userp2.Email.Contains("@")))
            {
                return Error();
            }
            else
            {
                userDAO = new UserDAO(_context);
                int resultToReturn = userDAO.Update(userp2);

                return Ok(resultToReturn); //retornamos el 1 o el 0 ala vista
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
