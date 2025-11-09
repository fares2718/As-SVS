using System.Threading.Channels;

namespace AsSVS.EF.Repositories
{
    internal class MessageQueueRepository : IMessageQueueRepository
{
        private readonly Channel<Message> _queue = Channel.CreateUnbounded<Message>();
        private readonly As_SVSContext _context;

        public MessageQueueRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task EnqueueAsync(Message message)
        {
            await _queue.Writer.WriteAsync(message);
        }

        public async Task<IEnumerable<Message>> DequeueBatchAsync(CancellationToken token)
        {
            var batch = new List<Message>();

            while (await _queue.Reader.WaitToReadAsync(token))
            {
                while (_queue.Reader.TryRead(out var msg))
                {
                    batch.Add(msg);
                    if (batch.Count >= 50)
                        return batch;
                }

               
                if (batch.Any())
                    return batch;
            }

            return batch;
        }
    }
}
