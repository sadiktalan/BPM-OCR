using System;
using DocumentTypeDecider.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DocumentTypeDecider.SearchHandler
{
	public class DocumentDecider
	{
        private ServiceProvider? _serviceProvider = Utils.GetServiceProvider();

        public FuzzySearchResult GetSearchPercentage(string fullText, string searchText)
        {
            IFuzzySearchHandler? fuzzySearch = _serviceProvider?.GetService<IFuzzySearchHandler>();
            var result = fuzzySearch?.SearchResult(fullText, searchText);
            return new FuzzySearchResult
            {
                SearchResult = Convert.ToSingle(result)
            };
        }
    }
}

