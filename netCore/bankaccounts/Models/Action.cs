using System;

namespace bankaccounts.Models
{

    public class Action{
        public int actionid {get; set;}
        public string type {get;set;}
        public int amount {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
        public int userid {get;set;}
        public User user {get;set;}

    }
}