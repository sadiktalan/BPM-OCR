
using System;
using FuzzySharp;

namespace DocumentTypeDecider.SearchHandler
{
	public class FuzzySearchHandler : IFuzzySearchHandler
    {
		public FuzzySearchHandler()
		{
		}

		public int SearchResult(string fullText, string searchText)
		{
			return Fuzz.PartialTokenSetRatio(searchText, fullText);
		}
	}
}

