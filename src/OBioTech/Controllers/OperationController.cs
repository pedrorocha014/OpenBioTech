using Microsoft.AspNetCore.Mvc;
using OBioTech.Models.Dtos;
using OBioTech.Services.Analysis;

namespace OBioTech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operation;

        public OperationController(IOperationService operationService)
        {
            _operation = operationService;
        }

        [HttpPost("sequence")]
        public async Task<IActionResult> SendDataToAnalysis([FromBody] SequenceDto sequenceDto)
        {
            var result = _operation.SelectOperation<SequenceDto, SequenceResultDto>(sequenceDto);

            return Ok(result);
        }

        [HttpPost("rmsd")]
        public async Task<IActionResult> SendDataToRMSDOperation([FromForm] RmsdDto rmsdDto)
        {
            var result = _operation.SelectOperation<RmsdDto, RmsdResultDto>(rmsdDto);
            return Ok(result);
        }

        [HttpPost("proteinVizualization")]
        public async Task<IActionResult> Test([FromForm] ProteinVisualizationDto rmsdDto)
        {
            var result = _operation.SelectOperation<ProteinVisualizationDto, ProteinVisualizationResultDto>(rmsdDto);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
