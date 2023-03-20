using System;
using OCRLibrary.Models;

namespace OCRLibrary.TesseractHandler
{
	public interface ITesseractBuilder
	{
        OcrResult DoOcr(string fileString);

    }
}

