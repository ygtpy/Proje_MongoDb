using AkademiQMongoDb.DTOs.ServiceDtos;

namespace AkademiQMongoDb.Services.ServiceServices
{
    public interface IServiceService
    {
        Task<List<ResultServiceDto>> GetAllAsync();
        Task CreateAsync(CreateServiceDto serviceDto);
        Task UpdateAsync(UpdateServiceDto serviceDto);
        Task DeleteAsync(string id);
        Task<UpdateServiceDto> GetByIdAsync(string id);
    }
}
