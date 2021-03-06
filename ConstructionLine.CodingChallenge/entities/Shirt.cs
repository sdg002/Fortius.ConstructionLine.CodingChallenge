using System;

namespace ConstructionLine.CodingChallenge
{
    public class Shirt
    {
        public Guid Id { get; }

        public string Name { get; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        public Shirt(Guid id, string name, Size size, Color color)
        {
            Id = id;
            Name = name;
            Size = size;
            Color = color;
        }

        public override string ToString()
        {
            return $"Name={this.Name} Size={this.Size.Name} Color={this.Color.Name}";
        }
    }
}