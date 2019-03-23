using Solutions.ObjectOrientedDesign.CardGame;

namespace Solutions.ObjectOrientedDesign
{
    public class FrenchCard: ICard
    {
        public string Name { get; set; }
        public Suit Suit { get; set; }
        public Ranking Ranking { get; set; }

        public FrenchCard(string name, Suit suit, Ranking ranking)
        {
            Name = name;
            this.Suit = suit;
            this.Ranking = ranking;
        }
    }
}