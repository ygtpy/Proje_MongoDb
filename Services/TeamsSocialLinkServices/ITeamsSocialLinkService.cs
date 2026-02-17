using AkademiQMongoDb.DTOs.TeamsSocialLinkDtos;

namespace AkademiQMongoDb.Services.TeamsSocialLinkServices
{
    public interface ITeamsSocialLinkService
    {
        Task<List<ResultTeamsSocialLinkDto>> GetAllAsync();
        Task CreateAsync(CreateTeamsSocialLinkDto teamsSocialLinkDto);
        Task UpdateAsync(UpdateTeamsSocialLinkDto teamsSocialLinkDto);
        Task DeleteAsync(string id);
        Task<UpdateTeamsSocialLinkDto> GetByIdAsync(string id);
        Task<List<ResultTeamsSocialLinkDto>> GetByTeamIdAsync(string teamId);
    }
}
