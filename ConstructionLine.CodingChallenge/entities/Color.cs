using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ConstructionLine.CodingChallenge
{
    public class Color
    {
        public Guid Id { get; }

        public string Name { get; }

        private Color(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static readonly Color Red = new Color(Guid.NewGuid(), "Red");
        public static readonly Color Blue = new Color(Guid.NewGuid(), "Blue");
        public static readonly Color Yellow = new Color(Guid.NewGuid(), "Yellow");
        public static readonly Color White = new Color(Guid.NewGuid(), "White");
        public static readonly Color Black = new Color(Guid.NewGuid(), "Black");

        public static readonly ImmutableList<Color> All =
            ImmutableList.Create<Color>(new Color[]
            {
                Red,
                Blue,
                Yellow,
                White,
                Black
            });

        public override string ToString()
        {
            return $"Id={this.Id}   Name={this.Name}";
        }
    }
}