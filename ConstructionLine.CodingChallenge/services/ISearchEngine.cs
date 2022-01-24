using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionLine.CodingChallenge.services
{
    public interface ISearchEngine
    {
        SearchResults Search(SearchOptions options);
    }
}