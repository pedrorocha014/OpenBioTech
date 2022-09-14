using AnalysisConsumer.Models;
using AnalysisConsumer.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.QueueDeclare("product", exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) => {
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Product message received: {message}");

    AnalysisDto analysisDto = JsonSerializer.Deserialize<AnalysisDto>(message);

    var analysisResults = SequenceAnalysis.InitializeOperation(analysisDto);
};

channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
Console.ReadKey();