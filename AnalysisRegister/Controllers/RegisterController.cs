using AnalysisRegister.Models;
using AnalysisRegister.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisRegister.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegister _service;

        public RegisterController(IRegister service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAnalysisResult([FromBody] Result analysisResults)
        {
            _service.RegisterAnalysisResult(analysisResults);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var results = _service.GetResults();
            return Ok(results);
        }
    }
}