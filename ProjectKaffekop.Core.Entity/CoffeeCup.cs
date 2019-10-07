namespace ProjectKaffekop.Core.Entity
{
    public class CoffeeCup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public double Volume { get; set; }
        public Material Material { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}