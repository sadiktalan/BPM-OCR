using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using OCRLibrary.TesseractHandler;
using Tesseract;
using OCRLibrary.Models;

namespace OCRLibrary.OcrOperation
{
	public class OcrHandler
	{
        private ServiceProvider? _serviceProvider = Utils.GetServiceProvider();

        public OcrResult DoOcr(string fileString)
        {
            ITesseractBuilder? builder =  _serviceProvider?.GetService<ITesseractBuilder>();
            var result = builder?.DoOcr(fileString);
            
            return result;
        }
	}
}

