using ConstructionLine.CodingChallenge.entities;
using ConstructionLine.CodingChallenge.services;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class FasterSearchEngine : ISearchEngine
    {
        private readonly List<Shirt> _shirts;
        private readonly List<IGrouping<System.Guid, Shirt>> _shirtsGroupedByColor;
        private readonly List<IGrouping<System.Guid, Shirt>> _shirtsGroupedBySize;

        public FasterSearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.
            _shirtsGroupedByColor = _shirts.GroupBy(s => s.Color.Id).ToList();
            _shirtsGroupedBySize = _shirts.GroupBy(s => s.Size.Id).ToList();
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

            var matchingShirts = new List<Shirt>();

            if (!targetSizeIds.Any() && targetColorIds.Any())
            {
                foreach (var colorOption in options.Colors)
                {
                    var shirtsWithSpecifiedColors = _shirtsGroupedByColor.Single(g => g.Key == colorOption.Id).ToList();
                    matchingShirts.AddRange(shirtsWithSpecifiedColors);
                }
            }
            else if (targetSizeIds.Any() && !targetColorIds.Any())
            {
                foreach (var sizeOption in options.Sizes)
                {
                    var shirtsWithSpecifiedSizes = _shirtsGroupedBySize.Single(g => g.Key == sizeOption.Id).ToList();
                    matchingShirts.AddRange(shirtsWithSpecifiedSizes);
                }
            }
            else
            {
                var shirtsWithSpecifiedColors = _shirtsGroupedByColor.Where(g => targetColorIds.Contains(g.Key)).SelectMany(g => g).ToList();
                var shirtsWithSpecifiedSizes = _shirtsGroupedBySize.Where(g => targetSizeIds.Contains(g.Key)).SelectMany(g => g).ToList();
                var unionHashset = new HashSet<Shirt>();
                shirtsWithSpecifiedColors.ForEach(s => unionHashset.Add(s));
                shirtsWithSpecifiedSizes.ForEach(s => unionHashset.Add(s));

                var intersectionOfUnion = unionHashset.Where(s => targetSizeIds.Contains(s.Size.Id) && targetColorIds.Contains(s.Color.Id)).ToList();
                matchingShirts.AddRange(intersectionOfUnion);
            }

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
                matchingShirts.ToList(),
                sizeCountsInResults,
                colorCountsInResults);
        }
    }
}