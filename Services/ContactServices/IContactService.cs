using AkademiQMongoDb.DTOs.ContactDtos;

namespace AkademiQMongoDb.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task CreateAsync(CreateContactDto contactDto);
        Task UpdateAsync(UpdateContactDto contactDto);
        Task DeleteAsync(string id);
        Task<UpdateContactDto> GetByIdAsync(string id);
    }
}
