using System;
using BPMCase.Entities;
using DocumentTypeDecider.Models;
using DocumentTypeDecider.SearchHandler;
using OCRLibrary.Models;
using OCRLibrary.OcrOperation;

namespace BPMCase.Services
{
	public class OcrService : IOcrService
	{
        private readonly ILogger<OcrService> _logger;

        public OcrService(ILogger<OcrService> logger)
		{
            _logger = logger;
		}

        public OcrResponseDTO GetOcrResponse(OcrRequestDTO requestDTO)
        {
            var ocrResult = GetOcrResult(requestDTO);
            var searchResult = GetFuzzySearch(ocrResult.Text, GetDocumentKeyword(requestDTO.DocumentType));
            return new OcrResponseDTO
            {
                SuccessRate = searchResult.SearchResult
            };
        }

        private OcrResult GetOcrResult(OcrRequestDTO requestDTO)
        {
            OcrHandler ocrHandler = new OcrHandler();
            OcrResult result;
            try
            {
                result = ocrHandler.DoOcr(requestDTO.DocumentData);
            } catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception("Couldn't get OCR result");
            }
            return result;
        }

        private FuzzySearchResult GetFuzzySearch(string fullText, string searchText)
        {
            try
            {
                DocumentDecider decider = new DocumentDecider();
                return decider.GetSearchPercentage(fullText, searchText);
            } catch(Exception e) 
            {
                _logger.LogError(e.Message);
                throw new Exception("Couldn't get FuzzySarch result");
            }

        }

        private static string GetDocumentKeyword(DocumentType documentType)
        {
            switch (documentType)
            {
                case DocumentType.Taxi:
                    return "FİŞ";
                case DocumentType.Bill:
                    return "FATURA";
                default:
                    throw new Exception("Unknown document type!");
            }
        }
    }
}

