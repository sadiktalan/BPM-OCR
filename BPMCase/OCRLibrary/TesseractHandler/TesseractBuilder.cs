using System;
using Microsoft.Extensions.Logging;
using OCRLibrary.Models;
using Tesseract;

namespace OCRLibrary.TesseractHandler
{
	public class TesseractBuilder : ITesseractBuilder
	{
		ILogger<TesseractBuilder> _logger;

        public TesseractBuilder(ILogger<TesseractBuilder> logger)
		{
			_logger = logger;
		}

		public OcrResult DoOcr(string fileString)
		{
            var st = Environment.CurrentDirectory;
            DirectoryInfo currentDirectory = new DirectoryInfo(st);
            using (var engine = new TesseractEngine(
                //getting tur.tessdata file
                currentDirectory.Parent.FullName + @"/OcrLibrary/tessdata", "tur", EngineMode.Default))
            {
                using (var img = Pix.LoadFromMemory(System.Convert.FromBase64String(fileString)))
                {
                    using (var page = engine.Process(img))
                    {
                        var successRate = page.GetMeanConfidence();
                        var txt = page.GetText();
                        return new OcrResult
                        {
                            SuccessRate = successRate,
                            Text = txt
                        };
                    }
                }
            }
        }
	}
}

