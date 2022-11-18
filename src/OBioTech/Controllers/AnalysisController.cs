using Microsoft.AspNetCore.Mvc;
using OBioTech.Models.Dtos;
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

        [HttpPost("sequence")]
        public async Task<IActionResult> SendDataToAnalysis([FromBody] AnalysisDto analysisDto)
        {
            var result = _analysisMap.Map(analysisDto);

            return Ok(result);
        }

        [HttpPost("rmsd")]
        public async Task<IActionResult> SendDataToRMSDOperation([FromForm] RmsdDto rmsdDto)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
