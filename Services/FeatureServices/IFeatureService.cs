using AkademiQMongoDb.DTOs.FeatureDtos;

namespace AkademiQMongoDb.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllAsync();
        Task CreateAsync(CreateFeatureDto featureDto);
        Task UpdateAsync(UpdateFeatureDto featureDto);
        Task DeleteAsync(string id);
        Task<UpdateFeatureDto> GetByIdAsync(string id);
    }
}
