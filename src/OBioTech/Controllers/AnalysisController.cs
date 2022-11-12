using Microsoft.AspNetCore.Mvc;

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
        public IActionResult SendProteinSequenceDataToAnalysis()
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
