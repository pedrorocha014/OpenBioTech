using AnalysisConsumer.Models;
using AnalysisConsumer.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Net.Http;

var factory = new ConnectionFactory
{
    HostName = "protein-sequence-service_queue_1"
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
    var analysisResultJson = JsonSerializer.Serialize(analysisResults);

    var client = new HttpClient();

    HttpContent httpContent = new StringContent(analysisResultJson, Encoding.UTF8, "application/json");
    client.PostAsync("http://protein-sequence-service_analysis-register_1:80/Register", httpContent);
};

channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
Console.Read();