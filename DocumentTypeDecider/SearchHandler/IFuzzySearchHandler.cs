using System;
namespace DocumentTypeDecider.SearchHandler
{
	public interface IFuzzySearchHandler
	{
        int SearchResult(string fullText, string searchText);

    }
}

