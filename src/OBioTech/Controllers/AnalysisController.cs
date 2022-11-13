using Microsoft.AspNetCore.Mvc;
using OBioTech.Models;
using OBioTech.Services.Analysis;
using OBioTech.Services.Register;

namespace OBioTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisMap _analysisMap;
        private readonly IRegisterService _registerService;

        public AnalysisController(IAnalysisMap analysisMap, IRegisterService registerService)
        {
            _analysisMap = analysisMap;
            _registerService = registerService;
        }

        [HttpPost("proteinSequence")]
        public IActionResult SendProteinSequenceDataToAnalysis([FromBody] AnalysisDto analysisDto)
        {
            var result = _analysisMap.MapAnalysis(analysisDto);
            _registerService.RegisterAnalysisResult(result);

            return Ok();
        }

        [HttpGet]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
