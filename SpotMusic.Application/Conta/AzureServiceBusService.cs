using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using SpotMusic.Application.Conta.Dto;
using SpotMusic.Domain.Notificacao.Aggregates;
using System.Text.Json;

namespace SpotMusic.Application.Conta
{
    public class AzureServiceBusService
    {
        private string ConnectionString;

        public AzureServiceBusService(IConfiguration configuration)
        {
            this.ConnectionString = configuration["AzureServiceBus:ConnectionString"] ?? string.Empty;
        }

        public async Task SendMessage(NotificacaoDto notificacao)
        {
            ServiceBusClient client;
            ServiceBusSender sender;

            client = new ServiceBusClient(this.ConnectionString);

            sender = client.CreateSender("notification");

            var body = JsonSerializer.Serialize(notificacao);

            var message = new ServiceBusMessage(body);

            await sender.SendMessageAsync(message);
        }
    }
}
