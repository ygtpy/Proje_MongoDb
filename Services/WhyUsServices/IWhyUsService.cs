using AkademiQMongoDb.DTOs.WhyUsDtos;

namespace AkademiQMongoDb.Services.WhyUsServices
{
    public interface IWhyUsService
    {
        Task<List<ResultWhyUsDto>> GetAllAsync();
        Task CreateAsync(CreateWhyUsDto whyUsDto);
        Task UpdateAsync(UpdateWhyUsDto whyUsDto);
        Task DeleteAsync(string id);
        Task<UpdateWhyUsDto> GetByIdAsync(string id);
    }
}
