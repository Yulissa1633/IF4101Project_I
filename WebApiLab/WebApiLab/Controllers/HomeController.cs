using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLab.Models.Entities;

namespace WebApiLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IF4101_B91472_B92299_APIContext _context;

        public HomeController()
        {
            _context = new IF4101_B91472_B92299_APIContext();
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: api/Home
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return await _context.News.ToListAsync();
        }

        // PUT: api/Home/5
        [Route("[action]")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Home
        [Route("api/PostNew")]
        [HttpPost]
        public async Task<ActionResult<News>> PostNew(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNew", new { id = news.Id }, news);
        }

        // DELETE: api/Home/5
        [Route("api/DeleteStudent")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteStudent(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return news;
        }

        private bool NewExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
