using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IF4101_ProjectI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IF4101_ProjectI.Controllers
{
    public class NewController : Controller
    {
        private readonly IF4101_B91472_B92299Context _context;
        HttpClientHandler _clientHandler = new HttpClientHandler();
        New _oNew = new New();
        List<New> _oNews = new List<New>();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<New>> GetAllNews()
        {
            _oNews = new List<New>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44309/api/Home"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oNews = JsonConvert.DeserializeObject<List<New>>(apiResponse);

                }
            }

            return _oNews;
        }
    }
}
