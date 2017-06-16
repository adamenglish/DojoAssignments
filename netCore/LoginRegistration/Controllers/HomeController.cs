using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginRegistration.Models;
using System.Linq;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }

        [HttpGet]
        [Route("LoginPage")]
        public IActionResult LoginPage()
        {
            ViewBag.Errors = new List<string>();
            return View("LoginUser");
        }

        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser(string Email, string Password)
        {
            Dictionary<string, object> foo = DbConnector.Query($"SELECT * FROM users WHERE Email = '{Email}'").SingleOrDefault();
            if (foo != null){
                System.Console.WriteLine("1");
                if((string)foo["password"] == Password){
                    System.Console.WriteLine("2");
                    return RedirectToAction("Success");
                }
            }
            ViewBag.LoginErrors = "Login is invalid";
            return View("LoginUser");
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Registration(User NewUser)
        {   
            if (ModelState.IsValid){
                DbConnector.Execute($"INSERT INTO users (Name, Email, Password, created_at, updated_at ) VALUES ('{NewUser.Name}', '{NewUser.Email}', '{NewUser.Password}', NOW(), NOW());");
                return RedirectToAction("Success");
            }
            else {
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
            
        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success (){
            return View();
        }

    }
}
