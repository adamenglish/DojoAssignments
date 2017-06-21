using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using bankaccounts.Models;
using System.Linq;

namespace bankaccounts.Controllers
{
    public class LoginController : Controller
    {
        private BankContext _context;

        public LoginController(BankContext context){
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            User CurrUser = _context.Users.Where(e => e.email == email).SingleOrDefault();
             if (CurrUser != null){
                if (password == CurrUser.password){
                    HttpContext.Session.SetInt32("CurrUserId", CurrUser.userid);
                    return RedirectToAction("Account");  
                }
             }
             ViewBag.LoginError = "Invalid combination. Please provide a valid username/password.";
             return View("Index");              
        } 

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }


        [HttpPost]
        [Route("process")]
        public IActionResult Process(RegisterViewModel model)
        {
            ViewBag.Errors = new List<string>();
            System.Console.WriteLine("In register route");
            if (ModelState.IsValid){
                User NewUser = new User{
                    firstname = model.firstname,
                    lastname = model.lastname,
                    email = model.email,
                    password = model.password,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                _context.Add(NewUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("CurrUserId", NewUser.userid);
                return RedirectToAction("Account");
            } else {
                System.Console.WriteLine("Something failed...");
                ViewBag.Errors = ModelState.Values;
                return View ("register");
            }           
        }
        [HttpGet]
        [Route("Account")]
        public IActionResult Account()
        {
            ViewBag.Errors = new List<string>();
            ViewBag.CurrUser = _context.Users.SingleOrDefault( u => u.userid == 
                HttpContext.Session.GetInt32("CurrUserId"));
            if(HttpContext.Session.GetString("NoMoneyError") == null){

                ViewBag.NoMoneyError = "";
            }
            else{
                ViewBag.NoMoneyError = HttpContext.Session.GetString("NoMoneyError");
            }
            ViewBag.AllMyActions = _context.Actions.Where(action => action.userid == HttpContext.Session.GetInt32("CurrUserId")); 
            return View();
        }

    }
}
