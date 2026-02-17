using AkademiQMongoDb.DTOs.AboutDtos;

namespace AkademiQMongoDb.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task CreateAsync(CreateAboutDto aboutDto);
        Task UpdateAsync(UpdateAboutDto aboutDto);
        Task DeleteAsync(string id);
        Task<UpdateAboutDto> GetByIdAsync(string id);
    }
}
