using AkademiQMongoDb.DTOs.TeamDtos;

namespace AkademiQMongoDb.Services.TeamServices
{
    public interface ITeamService
    {
        Task<List<ResultTeamDto>> GetAllAsync();
        Task CreateAsync(CreateTeamDto teamDto);
        Task UpdateAsync(UpdateTeamDto teamDto);
        Task DeleteAsync(string id);
        Task<UpdateTeamDto> GetByIdAsync(string id);
    }
}
