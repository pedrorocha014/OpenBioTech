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

        public AnalysisController(IAnalysisMap analysisMap, RegisterService registerService)
        {
            _analysisMap = analysisMap;
        }

        [HttpPost]
        public async Task<IActionResult> SendDataToAnalysis([FromBody] AnalysisDto analysisDto)
        {
            var result = _analysisMap.Map(analysisDto);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
