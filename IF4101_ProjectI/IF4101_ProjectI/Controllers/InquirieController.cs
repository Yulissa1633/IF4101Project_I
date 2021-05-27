using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IF4101_ProjectI.Models;
using IF4101_ProjectI.Models.Data;
using IF4101_ProjectI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IF4101_ProjectI.Controllers
{
    public class InquirieController : Controller
    {
        private readonly IF4101_B91472_B92299Context _context;
        InquirieDAO inquirieDAO;
        public InquirieController(IF4101_B91472_B92299Context context)
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
            inquirieDAO = new InquirieDAO(_context);
            return Ok(inquirieDAO.GetCoursesEF());
        }

        public IActionResult Insert([FromBody] Inquirie inq)
        {
            inquirieDAO = new InquirieDAO(_context);
                int resultToReturn = inquirieDAO.Insert(inq);

                return Ok(resultToReturn); //retornamos el 1 o el 0 ala vista
            
        }
       
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        public IActionResult DeleteP(int value)
        {

            inquirieDAO = new InquirieDAO(_context);
            int resultToReturn = inquirieDAO.Delete(value);

            return Ok(resultToReturn); //retornamos el 1 o el 0 ala vista

        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
