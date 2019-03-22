namespace Solutions.ObjectOrientedDesign
{
    public class FrenchCard: ICard
    {
        public string Name { get; set; }
        public int Value { get; set; }
        
        public FrenchCard(string name, int value)
        {
            this.Name = name;
            Value = value;
        }
    }
}