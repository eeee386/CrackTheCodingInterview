using System.Collections.Generic;
using System.Security.Cryptography;

namespace Solutions.ObjectOrientedDesign
{
    public interface IFrenchCardGame
    {
        string Name { get; set; }
        DeckOfFrenchCards DeckOfFrenchCards { get; set; }
        List<Player> players { get; set; }
    }
}