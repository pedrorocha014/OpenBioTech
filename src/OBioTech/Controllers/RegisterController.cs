using Microsoft.AspNetCore.Mvc;
using OBioTech.Services.Analysis;
using OBioTech.Services.Register;

namespace OBioTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController: ControllerBase
    {
        private readonly RegisterService _registerService;

        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegisterResults()
        {
            var results = await _registerService.GetAsync();
            return Ok(results);
        }
    }
}
