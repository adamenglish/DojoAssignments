using System;
using System.Collections.Generic;

namespace BlackJackHack
{
   public class Player{
        public int balance = 100;
        public List<Card> hand;

        public int handVal = 0;

        public Player() {
            hand = new List<Card>();
            balance = 100; 
        }
        public Card DrawFrom(Deck currentDeck) {
            Card DrawnCard = currentDeck.Deal();
            if ( DrawnCard.val == 1 && this.HandValue() <= 10){
                DrawnCard.val = 11;
            }
            hand.Add(DrawnCard);
            return DrawnCard;
        }
        
        public int HandValue(){
            int sum = 0;
            for (int idx = 0; idx< hand.Count; idx++){
                 sum += hand[idx].val;
                 handVal = sum;
            }
            return handVal;           
        }
        public Card Discard(int idx) {
            Card temp = hand[idx];
            hand.RemoveAt(idx);
            return temp;
        }
    }
}