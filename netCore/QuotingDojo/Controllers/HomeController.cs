using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            return View();
        }

        // GET: /Result/
        [HttpPost]
        [Route("result")]
        public IActionResult Result(string Name, string Quote)
        {
            // ViewBag.Name = Name;
            // ViewBag.Quote = Quote;
            DbConnector.Execute($"INSERT INTO quotes (name, content, created_at, updated_at) VALUES ('{Name}', '{Quote}', NOW(), NOW());");
            ViewBag.AllQuotes = DbConnector.Query($"SELECT * FROM quotes;");
            return View();
        }
    }
}
