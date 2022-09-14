namespace AnalysisDelivery.RabbitMq
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
