using AnalysisDelivery.Controllers;
using AnalysisDelivery.Models;
using AnalysisDelivery.RabbitMq;
using AnalysisTests.Utils;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisTests.Controllers
{
    public class FileControllerTest
    {
        [Test]
        public void DeliverMessage_Should_Return_Ok()
        {
            Models models = new Models();

            var mockRepo = new Mock<IRabitMQProducer>();
            mockRepo.Setup(repo => repo.SendProductMessage(It.IsAny<AnalysisDto>()));
            var controller = new FileController(mockRepo.Object);

            OkResult result = (OkResult)controller.DeliverMessage(models.analysisDto);

            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
    }
}
