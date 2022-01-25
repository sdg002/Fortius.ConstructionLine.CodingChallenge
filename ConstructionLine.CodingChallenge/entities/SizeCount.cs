using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionLine.CodingChallenge.entities
{
    public class SizeCount
    {
        public SizeCount(Size size, int count)
        {
            this.Size = size;
            this.Count = count;
        }

        public Size Size { get; protected set; }

        public int Count { get; protected set; }

        public override string ToString()
        {
            return $"Size={this.Size.Name} Count={Count}";
        }
    }
}