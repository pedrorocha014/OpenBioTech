using AnalysisDelivery.Models;
using AnalysisDelivery.RabbitMq;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisDelivery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IRabitMQProducer _rabitMQProducer;

        public FileController(IRabitMQProducer rabitMQProducer)
        {
            _rabitMQProducer = rabitMQProducer;
        }

        [HttpPost]
        public IActionResult DeliverMessage([FromBody] AnalysisDto analysisDto)
        {
            _rabitMQProducer.SendProductMessage(analysisDto);
            return Ok();
        }
    }
}