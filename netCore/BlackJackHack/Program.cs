using System;

namespace BlackJackHack
{
    class Program
    {
        public struct value 
            { 
                public string cardName; 
                public int cardValue; 
                public value(string cn, int cv) 
                { 
                    this.cardName = cn; 
                    this.cardValue = cv; 
                } 

            } 
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            Player tester = new Player();
            Player dealer = new Player();
        
            bool playagain = false;
            Console.WriteLine("Do you want to play a hand of Blackjack? (y/n)");
            string response = Console.ReadLine();
            if (response.ToLower() == "y"){
                playagain = true;
            }
            if (playagain == true && tester.balance > 0){
                //place bet
                System.Console.WriteLine($"How much do you want to bet? You currently have ${tester.balance} dollars.");
                int betresponse = Convert.ToInt32(Console.ReadLine());
                if (betresponse > tester.balance){
                    System.Console.WriteLine("You don't have enough money for that bet!");
                }
                else {
                    tester.balance -= betresponse;
                }

                //deal hand
                System.Console.WriteLine($"Money:{tester.balance}");
                tester.DrawFrom(myDeck);
                dealer.DrawFrom(myDeck);
                tester.DrawFrom(myDeck);
                dealer.DrawFrom(myDeck);

                //display hand
                System.Console.WriteLine($"Here is the Dealer's card: {dealer.hand[0].stringVal} of {dealer.hand[0].suit} and {dealer.hand[1].stringVal} of {dealer.hand[1].suit}");
                System.Console.WriteLine($"Here are your two cards: {tester.hand[0].stringVal} of {tester.hand[0].suit} and {tester.hand[1].stringVal} of {tester.hand[1].suit}");
                
                // if (tester.hand[0].val == 13 || tester.hand[0].val == 12 || tester.hand[0].val == 11){
                //     tester.hand[0].val = 10;
                // }
                // if (tester.hand[1].val == 13 || tester.hand[0].val == 12 || tester.hand[0].val == 11){
                //     tester.hand[1].val = 10;
                // }
            
                tester.handVal = tester.hand[0].val + tester.hand[1].val;
                System.Console.WriteLine($"Your score is currently: {tester.handVal}");
                
                System.Console.WriteLine("Do you want to draw another card? (y/n)");
                string response2 = Console.ReadLine();
                if (response2.ToLower() == "y"){
                    playagain = true;
                    tester.DrawFrom(myDeck);
                    if (tester.handVal >=22){
                        System.Console.WriteLine("Bust! Dealer wins.");
                    }
                    System.Console.WriteLine($"Here are your three cards: {tester.hand[0].stringVal} of {tester.hand[0].suit} and {tester.hand[1].stringVal} of {tester.hand[1].suit} and {tester.hand[2].stringVal} of {tester.hand[2].suit}");
                    tester.handVal = tester.hand[0].val + tester.hand[1].val + tester.hand[2].val;
                    System.Console.WriteLine($"Your score is currently: {tester.handVal}");
                   
                }
                else {
                    playagain = true;
                    if (tester.handVal > dealer.handVal){
                        System.Console.WriteLine($"Your score is: {tester.handVal}");
                        System.Console.WriteLine($"The dealer score is: {dealer.handVal}");
                        System.Console.WriteLine("Congrats, you win!");
                        tester.balance += betresponse * 2;
                    }
                    else if (dealer.handVal > tester.handVal){
                        System.Console.WriteLine("The dealer won.");
                        System.Console.WriteLine($"Your score is: {tester.handVal}");
                        System.Console.WriteLine($"The dealer score is: {dealer.handVal}");
                    }
                    System.Console.WriteLine($"Your score is currently: {tester.handVal}");
                    System.Console.WriteLine($"The dealers score is: {dealer.handVal}, the Dealer's cards: {dealer.hand[0].stringVal} of {dealer.hand[0].suit} and {dealer.hand[1].stringVal} of {dealer.hand[1].suit}");
                }


            }
        }
    }
}
