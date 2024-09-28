using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ProcessaNotificacoes
{
    public class ProcessaFilaAzureServiceBus
    {
        private readonly ILogger<ProcessaFilaAzureServiceBus> _logger;

        public ProcessaFilaAzureServiceBus(ILogger<ProcessaFilaAzureServiceBus> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ProcessaFilaAzureServiceBus))]
        public async Task Run(
            [ServiceBusTrigger("notification", Connection = "AzureServiceBus")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
