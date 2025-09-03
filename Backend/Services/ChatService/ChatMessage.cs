namespace CollabApp.Services.ChatService
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Room { get; set; } = "general";
    }
}
