using System;
using System.Collections.Generic;

namespace bankaccounts.Models
{
    public class User
    {
        public int userid {get; set;}
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime created_at {get; set;}
        public DateTime updated_at {get; set;}
        public int money {get;set;}
        public List<Action> Actions {get;set;}
        public User(){
            Actions = new List<Action>();
            money = 0;
        }
    }
}