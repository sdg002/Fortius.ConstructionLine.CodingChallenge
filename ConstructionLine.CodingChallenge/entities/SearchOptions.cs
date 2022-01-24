using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    //TODO add constructor and make properties protected

    public class SearchOptions
    {
        public List<Size> Sizes { get; set; } = new List<Size>();

        public List<Color> Colors { get; set; } = new List<Color>();
    }
}