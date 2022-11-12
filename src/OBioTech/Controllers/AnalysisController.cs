using Microsoft.AspNetCore.Mvc;
using OBioTech.Models;

namespace OBioTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalysisController : ControllerBase
    {
        public AnalysisController()
        {

        }

        [HttpPost("proteinSequence")]
        public IActionResult SendProteinSequenceDataToAnalysis([FromBody] AnalysisDto analysisDto)
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
