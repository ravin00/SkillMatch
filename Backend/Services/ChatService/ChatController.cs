using Microsoft.AspNetCore.Mvc;
using CollabApp.Services.ChatService;

namespace CollabApp.Services.ChatService
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Chat service is alive");
        }
    }
}
