using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsSVS.EF.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly As_SVSContext _context;

        public MessageRepository(As_SVSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessagesByRoomIdAsync(int roomId)
        {
            return await _context.Messages
            .Where(m => m.RoomId == roomId)
            .OrderBy(m => m.Id)
            .ToListAsync();
        }

        public async Task SaveMessageBatchAsync(IEnumerable<Message> messages)
        {
            await _context.Messages.AddRangeAsync(messages);
            await _context.SaveChangesAsync();
        }
    }
}
