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
        private readonly RegisterService _registerService;

        public AnalysisController(IAnalysisMap analysisMap, RegisterService registerService)
        {
            _analysisMap = analysisMap;
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> SendDataToAnalysis([FromBody] AnalysisDto analysisDto)
        {
            var result = _analysisMap.MapAnalysis(analysisDto);
            await _registerService.CreateAsync(result);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
