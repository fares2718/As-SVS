using As_SVS.Core.Interfaces;
using As_SVS.Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace As_SVS.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageQueueRepository _queueRepository;

        public ChatHub(IMessageQueueRepository queueRepository)
        {
            _queueRepository = queueRepository;
        }
        public async Task JoinRoomAsync(UserConnection userConnection)
        {
            string roomName = $"Room_{userConnection.RoomId}";
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage","admin",$"{userConnection.Username} has joined");
        }

        public async Task SendMessageToRoom(int roomId, string userId, string messageContent)
        {
            var message = new Message
            {
                RoomId = roomId,
                applicationUserId = userId,
                MessageContent = messageContent,
                CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow)
            };

            await _queueRepository.EnqueueAsync(message);

            string roomName = $"Room_{roomId}";
            await Clients.Group(roomName).SendAsync("ReceiveMessage", userId, messageContent);
        }
    }
}
