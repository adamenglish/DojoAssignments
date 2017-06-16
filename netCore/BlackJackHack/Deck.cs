using System;
using System.Collections.Generic;

namespace BlackJackHack
{
    public class Deck{
        public List<Card> cards;
        public Deck(){
            cards = new List<Card>();
            BuildDeck();
            Shuffle();
        }

        // public Deck Reset() {
        //     cards = new List<Card>();
        //     string[] suits = new string[4] {"Hearts","Clubs","Spades","Diamonds"};
        //     foreach(string suit in suits) {
        //         for(int val = 1; val <= 13; val++) {
        //             cards.Add(new Card(suit, val));
        //         }
        //     }
        //     return this;
        // }

        public void BuildDeck(){
        string[] Suits = {"Hearts", "Spades", "Diamonds", "Clubs"};
        string[] Values = {"Bob", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        for(int suit=0; suit<Suits.Length; suit++)
        {
            for(int val=1; val<Values.Length; val++)
            {
                if (val >= 11)
                {
                    cards.Add(new Card(Values[val], Suits[suit], val));
                }
                else {
                    cards.Add(new Card(Values[val], Suits[suit], val));
                }
            }
        }
        }

        public Card Deal(){
            Card temp = cards[0];
            cards.RemoveAt(0);
            return temp;
        }

        public Deck Shuffle() {
            Random rand = new Random();
            for(int idx = cards.Count - 1; idx > 0; idx--) {
                int randIdx = rand.Next(idx);
                Card temp = cards[randIdx];
                cards[randIdx] = cards[idx];
                cards[idx] = temp;
            }
        return this;
        }

        public override string ToString() {
            string info = "";
            foreach(Card card in cards) {
                info += card + "\n";
            }
        return info;
        }
    }
}