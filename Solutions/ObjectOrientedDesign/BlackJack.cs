using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Solutions.ObjectOrientedDesign
{
    public class BlackJack: IFrenchCardGame
    {

        public string Name { get; set; }
        public DeckOfFrenchCards DeckOfFrenchCards { get; set; }
        public List<Player> players { get; set; } 
        
        public BlackJack(DeckOfFrenchCards cards)
        {
            DeckOfFrenchCards = cards;
        }

        public void StartGame()
        {
            DeckOfFrenchCards.Shuffle();
            foreach (var player in players)
            {
                player.RecieveCards(DeckOfFrenchCards.DealCardsToPlayer(2));
            }
        }

        public void EndGame()
        {
            foreach (var player in players)
            {
                DeckOfFrenchCards.RegenerateCards(player.SendBackCards());
            }
        }

    }
}