using AkademiQMongoDb.DTOs.TeamsSocialLinkDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.TeamsSocialLinkServices
{
    public class TeamsSocialLinkService : ITeamsSocialLinkService
    {
        private readonly IMongoCollection<TeamsSocialLink> _teamsSocialLinkCollection;

        public TeamsSocialLinkService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamsSocialLinkCollection = database.GetCollection<TeamsSocialLink>(databaseSettings.TeamsSocialLinkCollectionName);
        }

        public async Task CreateAsync(CreateTeamsSocialLinkDto teamsSocialLinkDto)
        {
            var teamsSocialLink = teamsSocialLinkDto.Adapt<TeamsSocialLink>();
            await _teamsSocialLinkCollection.InsertOneAsync(teamsSocialLink);
        }

        public async Task DeleteAsync(string id)
        {
            await _teamsSocialLinkCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultTeamsSocialLinkDto>> GetAllAsync()
        {
            var teamsSocialLinks = await _teamsSocialLinkCollection.Find(_ => true).ToListAsync();
            return teamsSocialLinks.Adapt<List<ResultTeamsSocialLinkDto>>();
        }

        public async Task<UpdateTeamsSocialLinkDto> GetByIdAsync(string id)
        {
            var teamsSocialLink = await _teamsSocialLinkCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return teamsSocialLink.Adapt<UpdateTeamsSocialLinkDto>();
        }

        public async Task<List<ResultTeamsSocialLinkDto>> GetByTeamIdAsync(string teamId)
        {
            var teamsSocialLinks = await _teamsSocialLinkCollection.Find(x => x.TeamId == teamId).ToListAsync();
            return teamsSocialLinks.Adapt<List<ResultTeamsSocialLinkDto>>();
        }

        public async Task UpdateAsync(UpdateTeamsSocialLinkDto teamsSocialLinkDto)
        {
            var teamsSocialLink = teamsSocialLinkDto.Adapt<TeamsSocialLink>();
            await _teamsSocialLinkCollection.FindOneAndReplaceAsync(x => x.Id == teamsSocialLink.Id, teamsSocialLink);
        }
    }
}
