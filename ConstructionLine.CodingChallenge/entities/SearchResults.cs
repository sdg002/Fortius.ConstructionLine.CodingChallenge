using ConstructionLine.CodingChallenge.entities;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class SearchResults
    {
        public SearchResults(List<Shirt> shirts, List<SizeCount> sizeCounts, List<ColorCount> colorCounts)
        {
            this.Shirts = shirts;
            this.SizeCounts = sizeCounts;
            this.ColorCounts = colorCounts;
        }

        public List<Shirt> Shirts { get; protected set; }

        public List<SizeCount> SizeCounts { get; protected set; }

        public List<ColorCount> ColorCounts { get; protected set; }
    }
}