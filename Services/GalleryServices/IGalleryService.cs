using AkademiQMongoDb.DTOs.GalleryDtos;

namespace AkademiQMongoDb.Services.GalleryServices
{
    public interface IGalleryService
    {
        Task<List<ResultGalleryDto>> GetAllAsync();
        Task CreateAsync(CreateGalleryDto galleryDto);
        Task UpdateAsync(UpdateGalleryDto galleryDto);
        Task DeleteAsync(string id);
        Task<UpdateGalleryDto> GetByIdAsync(string id);
    }
}
