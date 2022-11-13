using Microsoft.AspNetCore.Mvc;
using OBioTech.Services.Analysis;
using OBioTech.Services.Register;

namespace OBioTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController: ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet]
        public IActionResult GetRegisterResults()
        {
            var results = _registerService.GetResults();
            return Ok(results);
        }
    }
}
