global using Microsoft.AspNetCore.Mvc;
using ChatApplication_backend.Services.ChatsService;

namespace ChatApplication_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ChatsController : ControllerBase
    {
        public readonly IChatsService service;
        public ChatsController(IChatsService serv)
        {
            service = serv;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetChatDto>>>> GetChats(int id)
        {
            return Ok(await service.GetUsersChat(id));
        }

        [HttpGet("{userId}/{chatId}")]
        public async Task<ActionResult<ServiceResponse<GetChatDto>>> GetChat(int chatId, int userId)
        {
            return Ok(await service.GetAChat(chatId, userId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetChatDto>>> Send(SendMessageDto dto)
        {
            return Ok(await service.SendAMessage(dto));
        }

        [HttpDelete("{userId}/{id}")]
        public async Task<ActionResult<ServiceResponse<GetChatDto>>> DeleteMessage(int id, int userId)
        {
            return Ok(await service.DeleteAMessage(id, userId));
        }
    }
}
