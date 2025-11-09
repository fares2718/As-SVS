using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface IMessageQueueRepository
    {
        Task EnqueueAsync(Message message);
        Task<IEnumerable<Message>> DequeueBatchAsync(CancellationToken token);
    }
}
