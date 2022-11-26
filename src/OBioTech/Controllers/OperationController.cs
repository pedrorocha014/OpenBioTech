using Microsoft.AspNetCore.Mvc;
using OBioTech.Models.Dtos;
using OBioTech.Services.Analysis;

namespace OBioTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IAnalysisMap _analysisMap;

        public OperationController(IAnalysisMap analysisMap)
        {
            _analysisMap = analysisMap;
        }

        [HttpPost("sequence")]
        public async Task<IActionResult> SendDataToAnalysis([FromBody] SequenceDto sequenceDto)
        {
            var result = _analysisMap.Map(sequenceDto);

            return Ok(result);
        }

        [HttpPost("rmsd")]
        public async Task<IActionResult> SendDataToRMSDOperation([FromForm] RmsdDto rmsdDto)
        {
            var result = _analysisMap.Map(rmsdDto);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
