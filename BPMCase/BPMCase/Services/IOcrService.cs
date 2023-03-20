using System;
using BPMCase.Entities;

namespace BPMCase.Services
{
	public interface IOcrService
	{
		OcrResponseDTO GetOcrResponse(OcrRequestDTO requestDTO);
	}
}

