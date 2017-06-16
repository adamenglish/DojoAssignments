using System;
using System.Collections.Generic;

namespace BlackJackHack
{
        public class Card
        {
            public string stringVal{get; set;}
        
            public string suit{get; set;}
            public int val{get; set;}
            public Card(string Stringval, string Suit, int Val) 
            {
                stringVal = Stringval;
                suit = Suit;
                val = Val;
            }
        }
}