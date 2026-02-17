using AkademiQMongoDb.DTOs.TeamDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly IMongoCollection<Team> _teamCollection;

        public TeamService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }

        public async Task CreateAsync(CreateTeamDto teamDto)
        {
            var team = teamDto.Adapt<Team>();
            await _teamCollection.InsertOneAsync(team);
        }

        public async Task DeleteAsync(string id)
        {
            await _teamCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultTeamDto>> GetAllAsync()
        {
            var teams = await _teamCollection.Find(_ => true).ToListAsync();
            return teams.Adapt<List<ResultTeamDto>>();
        }

        public async Task<UpdateTeamDto> GetByIdAsync(string id)
        {
            var team = await _teamCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return team.Adapt<UpdateTeamDto>();
        }

        public async Task UpdateAsync(UpdateTeamDto teamDto)
        {
            var team = teamDto.Adapt<Team>();
            await _teamCollection.FindOneAndReplaceAsync(x => x.Id == team.Id, team);
        }
    }
}
