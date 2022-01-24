﻿using ConstructionLine.CodingChallenge.services;
using System.Collections.Generic;

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

            return new SearchResults(new List<Shirt>(), new List<entities.SizeCount>(), new List<entities.ColorCount>());
        }
    }
}