using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionLine.CodingChallenge.entities
{
    public class ColorCount
    {
        public ColorCount(Color color, int count)
        {
            this.Color = color;
            this.Count = count;
        }

        public Color Color { get; protected set; }

        public int Count { get; protected set; }

        public override string ToString()
        {
            return $"Color={this.Color.Id} Count={this.Count}";
        }
    }
}