using AkademiQMongoDb.DTOs.SubscriberDtos;

namespace AkademiQMongoDb.Services.SubscriberServices
{
    public interface ISubscriberService
    {
        Task CreateAsync(CreateSubscriberDto createSubscriberDto);
        Task<List<ResultSubscriberDto>> GetAllAsync();
        Task<UpdateSubscriberDto> GetByIdAsync(string id);
        Task UpdateAsync(UpdateSubscriberDto updateSubscriberDto);
        Task DeleteAsync(string id);
    }
}
