using AkademiQMongoDb.DTOs.MessageDtos;

namespace AkademiQMongoDb.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllAsync();
        Task CreateAsync(CreateMessageDto messageDto);
        Task UpdateAsync(UpdateMessageDto messageDto);
        Task DeleteAsync(string id);
        Task<UpdateMessageDto> GetByIdAsync(string id);
    }
}
