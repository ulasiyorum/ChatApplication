namespace ChatApplication_backend.Services.ChatsService
{
    public interface IChatsService
    {
        Task<ServiceResponse<List<GetChatDto>>> GetUsersChat(int userId);
        Task<ServiceResponse<GetChatDto>> GetAChat(int chatId, int userId);
        Task<ServiceResponse<GetChatDto>> SendAMessage(SendMessageDto mess);
        Task<ServiceResponse<GetChatDto>> DeleteAMessage(int id, int userId);
    }
}
