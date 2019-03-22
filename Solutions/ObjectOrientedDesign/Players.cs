using System.Collections.Generic;

namespace Solutions.ObjectOrientedDesign
{
    public class Player
    {
        public string name;
        public List<FrenchCard> cardsInHand;

        public Player(string name, BlackJack game, List<FrenchCard> cardsInHand)
        {
            this.name = name;
            this.cardsInHand = cardsInHand;
        }

        public void DrawCard(FrenchCard card)
        {
            cardsInHand.Add(card);
        }

        public FrenchCard UseCard(int n)
        {
            FrenchCard card = cardsInHand[n];
            cardsInHand.RemoveAt(n);
            return card;
        }

        public void RecieveCards(List<FrenchCard> cards)
        {
            cardsInHand.AddRange(cards);
        }

        public List<FrenchCard> SendBackCards()
        {
            List<FrenchCard> cardsToSendBack = new List<FrenchCard>(cardsInHand);
            cardsInHand.Clear();
            return cardsToSendBack;
        }
    }
}