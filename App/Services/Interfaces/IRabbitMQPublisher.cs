using System;

namespace App.Services.Interfaces;

public interface IRabbitMQPublisher<T>
{
    Task PublishMessageAsync(T message, string queueName);
}
