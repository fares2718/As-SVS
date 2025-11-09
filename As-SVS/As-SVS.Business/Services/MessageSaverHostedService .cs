using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace As_SVS.Business.Services
{
    public class MessageSaverHostedService : BackgroundService
    {
        private readonly IMessageQueueRepository _queueRepository;
        private readonly IMessageRepository _repository;
        private readonly ILogger<MessageSaverHostedService> _logger;

        public MessageSaverHostedService(IMessageQueueRepository queueRepository,
                                         IMessageRepository repository,
                                         ILogger<MessageSaverHostedService> logger)
        {
            _queueRepository = queueRepository;
            _repository = repository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MessageSaverHostedService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                var batch = await _queueRepository.DequeueBatchAsync(stoppingToken);

                if (batch.Any())
                {
                    await _repository.SaveMessageBatchAsync(batch);
                    _logger.LogInformation($"Saved {batch.Count()} messages to DB.");
                }

                await Task.Delay(1000, stoppingToken); 
            }
        }
    }
}
