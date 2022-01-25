using ConstructionLine.CodingChallenge.entities;
using ConstructionLine.CodingChallenge.services;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine : ISearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
        }

        public SearchResults Search(SearchOptions options)
        {
            // TODO: search logic goes here.
            var targetSizeIds = options.Sizes.Select(sz => sz.Id).ToHashSet();
            var targetColorIds = options.Colors.Select(color => color.Id).ToHashSet();

            if (!targetSizeIds.Any() && !targetColorIds.Any())
            {
                var sizeCounts = Size.All.Select(s => new SizeCount(s, 0)).ToList();
                var colorCounts = Color.All.Select(c => new ColorCount(c, 0)).ToList();
                return new SearchResults(new List<Shirt>(), sizeCounts, colorCounts);
            }

            var matchingShirts = _shirts
                .Where(s => (!targetSizeIds.Any() || targetSizeIds.Contains(s.Size.Id)) && (!targetColorIds.Any() || targetColorIds.Contains(s.Color.Id)))
                .ToList();

            var groupBySize = matchingShirts.GroupBy(s => s.Size).ToList();
            var sizeCountsInResults = new List<SizeCount>();
            foreach (var size in Size.All)
            {
                var group = groupBySize.SingleOrDefault(g => g.Key.Id == size.Id);
                var count = (group?.Count() ?? 0);
                sizeCountsInResults.Add(new SizeCount(size, count));
            }

            var groupByColor = matchingShirts.GroupBy(s => s.Color).ToList();
            var colorCountsInResults = new List<ColorCount>();
            foreach (var color in Color.All)
            {
                var group = groupByColor.SingleOrDefault(g => g.Key.Id == color.Id);
                var count = (group?.Count() ?? 0);
                colorCountsInResults.Add(new ColorCount(color, count));
            }

            return new SearchResults(
                matchingShirts,
                sizeCountsInResults,
                colorCountsInResults);
        }
    }
}