using System.Text;
using System.Text.Json;
using API_B.Context;
using API_B.Model;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace API_B.Services;


//builder.Services.AddHostedService<RabbitMQService>();

public class RabbitMqService : BackgroundService
{
    private readonly FolhaContext context;

    public RabbitMqService(IDbContextFactory<FolhaContext> itemContextFactory)
    {
        context = itemContextFactory.CreateDbContext();
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        ConnectionFactory factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        var connection = factory.CreateConnection();

        var channel = connection.CreateModel();

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, message) =>
        {
            var body = message.Body.ToArray();
            var mensagem = Encoding.UTF8.GetString(body);
            var folha = JsonSerializer.Deserialize<Folha>(mensagem);
            if (folha != null){
                context.Folhas.Add(folha);
                await context.SaveChangesAsync();
            }
            Console.WriteLine(mensagem);
            Console.WriteLine(folha.nome);
        };
        channel.BasicConsume(
            queue: "FILA_MUCILON",
            autoAck: true,
            consumer: consumer
        );
        return Task.CompletedTask;


    }
}