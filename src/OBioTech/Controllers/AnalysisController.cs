using Microsoft.AspNetCore.Mvc;
using OBioTech.Models;
using OBioTech.Services.Analysis;

namespace OBioTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisMap _analysisMap;

        public AnalysisController(IAnalysisMap analysisMap)
        {
            _analysisMap = analysisMap;
        }

        [HttpPost("proteinSequence")]
        public IActionResult SendProteinSequenceDataToAnalysis([FromBody] AnalysisDto analysisDto)
        {
            _analysisMap.MapAnalysis(analysisDto);

            return Ok();
        }

        [HttpGet]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
