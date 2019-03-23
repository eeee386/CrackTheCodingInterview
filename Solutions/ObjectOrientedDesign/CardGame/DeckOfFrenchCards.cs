using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Solutions.ObjectOrientedDesign
{
    public class DeckOfFrenchCards
    {
        public List<FrenchCard> ListOfCards;

        protected DeckOfFrenchCards(List<FrenchCard> listOfCards)
        {
            this.ListOfCards = listOfCards;
        }

        public List<FrenchCard> DealCardsToPlayer(int n)
        {
            List<FrenchCard> cards = new List<FrenchCard>();
            while(n > 0)
            {
                cards.Add(ListOfCards[0]);
                ListOfCards.RemoveAt(0);
                n--;
            }

            return cards;
        }

        public void Shuffle()
        {
            for (int i = 0; i < ListOfCards.Count; i++)
            {
                FrenchCard temp = ListOfCards[i];
                Random r = new Random();
                int j = r.Next(i, ListOfCards.Count);
                ListOfCards[i] = ListOfCards[j];
                ListOfCards[j] = temp;
            } 
        }

        public FrenchCard DrawCard()
        {
            FrenchCard card = ListOfCards[0];
            ListOfCards.RemoveAt(0);
            return card;
        }

        public void RegenerateCards(List<FrenchCard> cards)
        {
            if (ListOfCards.Count == 0)
            {
                ListOfCards = cards;
            }
            else
            {
                ListOfCards.AddRange(cards);
            }
        }

    }
}