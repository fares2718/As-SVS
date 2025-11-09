using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As_SVS.Core.Interfaces
{
    public interface IMessageRepository
    {
        Task SaveMessageBatchAsync(IEnumerable<Message> messages);
        Task<IEnumerable<Message>> GetMessagesByRoomIdAsync(int roomId);
    }
}
