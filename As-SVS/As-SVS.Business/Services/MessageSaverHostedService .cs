using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace As_SVS.Business.Services
{
    public class MessageSaverHostedService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MessageSaverHostedService> _logger;

        public MessageSaverHostedService(IServiceProvider serviceProvider,
                                         ILogger<MessageSaverHostedService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MessageSaverHostedService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                   
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var queueRepo = scope.ServiceProvider.GetRequiredService<IMessageQueueRepository>();
                        var repo = scope.ServiceProvider.GetRequiredService<IMessageRepository>();

                        var batch = await queueRepo.DequeueBatchAsync(stoppingToken);

                        if (batch.Any())
                        {
                            await repo.SaveMessageBatchAsync(batch);
                            _logger.LogInformation($"✅ Saved {batch.Count()} messages to DB.");
                        }
                    }

                    await Task.Delay(1000, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred in MessageSaverHostedService.");
                }
            }

            _logger.LogInformation("MessageSaverHostedService stopped.");
        }
    }
}
