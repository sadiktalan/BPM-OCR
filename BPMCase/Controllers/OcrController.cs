using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BPMCase.Entities;
using BPMCase.Services;
using Microsoft.AspNetCore.Mvc;


namespace BPMCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcrController : ControllerBase
    {
        private readonly ILogger<OcrController> _logger;
        private readonly IOcrService _ocrService;

        public OcrController(ILogger<OcrController> logger, IOcrService ocrService)
        {
            _logger = logger;
            _ocrService = ocrService;
        }

        [HttpPost]
        [Route("SuccessRate")]
        public ActionResult<OcrResponseDTO> GetOcrResponse(OcrRequestDTO ocrRequest)
        {
            try
            {
                var response = _ocrService.GetOcrResponse(ocrRequest);
                return Ok(response);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

