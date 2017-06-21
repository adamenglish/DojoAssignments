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
    public class ActionsController : Controller
    {
        private BankContext _context;

        public ActionsController(BankContext context){
            _context = context;
        }

        [HttpPost]
        [Route("render")]
        public IActionResult render(int Amount){
            System.Console.WriteLine("We're in the render route!");
            string mytype = "Deposit";
            bankaccounts.Models.Action NewAction = new bankaccounts.Models.Action{
                amount = Amount,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
                userid = (int)HttpContext.Session.GetInt32("CurrUserId")
            };
            User ThisUser = _context.Users.SingleOrDefault( u => u.userid == 
                HttpContext.Session.GetInt32("CurrUserId"));
            if(Amount < 0 ){
                mytype = "Withdrawal";
                if((-1 * Amount) > ThisUser.money){
                    HttpContext.Session.SetString("NoMoneyError", "Not enough money. :(");
                    return RedirectToAction("Account", "Login");
                }
            }
            
            NewAction.type = mytype; 
            ThisUser.money += Amount; 
            _context.Add(NewAction);
            _context.SaveChanges();
            
            return RedirectToAction("Account", "Login");
        }
    } 

}

        
