using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Form_Submission.Models;

namespace Form_Submission.Controllers
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

        [HttpPost]
        [Route("success")]
        public IActionResult Success(string FirstName, string LastName, string Email, int Age, string Password)
        {
            User NewUser = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Age = Age,
                Password = Password

            };
            TryValidateModel(NewUser);
            ViewBag.Errors = ModelState.Values;
            System.Console.WriteLine("******************************************************************************************************");
            System.Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid){
                DbConnector.Execute($"INSERT INTO users (firstname, lastname, Email, Age, Password, created_at, updated_at ) VALUES ('{FirstName}', '{LastName}', '{Email}', {Age},'{Password}', NOW(), NOW());");
                return View();
            }
            else {
                return View("Index");
            }
            
        }
    }
}
