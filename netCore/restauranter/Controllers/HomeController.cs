using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using restauranter.Models;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {

        private RestaurantContext _context;

        public HomeController(RestaurantContext context){
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Process")]
        public IActionResult Process(Review NewReview)
        {   
            if (ModelState.IsValid){
                System.Console.WriteLine("Inside process");
                NewReview.created_at = DateTime.Now;
                _context.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");

            }
            else {
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
            
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
                // List<Review> AllReviews = _context.Restaurants.ToList();
                ViewBag.AllReviews = _context.Restaurants.OrderByDescending(dateorder => dateorder.created_at);
                return View("Reviews");
        }

        // public IActionResult Process()
        // {
        //     Review NewReview = new Review
        //     {   
        //         Reviewer = "Reviewer",
        //         Restaurant = "Restaurant",
        //         Reviews = "Review",
        //         Date = "Date",
        //         Stars = Convert.ToInt32("stars")
        //     };
            // _context.Add(NewReview);
            // _context.SaveChanges();
            //  return View("Success");
        // }
    }
}
