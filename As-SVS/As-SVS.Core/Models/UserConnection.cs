namespace As_SVS.Core.Models
{
    public class UserConnection
    {
        public string Username { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public Room ChatRoom = new Room();
    }
}
