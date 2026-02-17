using AkademiQMongoDb.DTOs.WhyUsDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.WhyUsServices
{
    public class WhyUsService : IWhyUsService
    {
        private readonly IMongoCollection<WhyUs> _whyUsCollection;

        public WhyUsService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _whyUsCollection = database.GetCollection<WhyUs>(databaseSettings.WhyUsCollectionName);
        }

        public async Task CreateAsync(CreateWhyUsDto whyUsDto)
        {
            var whyUs = whyUsDto.Adapt<WhyUs>();
            await _whyUsCollection.InsertOneAsync(whyUs);
        }

        public async Task DeleteAsync(string id)
        {
            await _whyUsCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultWhyUsDto>> GetAllAsync()
        {
            var whyUsList = await _whyUsCollection.Find(_ => true).ToListAsync();
            return whyUsList.Adapt<List<ResultWhyUsDto>>();
        }

        public async Task<UpdateWhyUsDto> GetByIdAsync(string id)
        {
            var whyUs = await _whyUsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return whyUs.Adapt<UpdateWhyUsDto>();
        }

        public async Task UpdateAsync(UpdateWhyUsDto whyUsDto)
        {
            var whyUs = whyUsDto.Adapt<WhyUs>();
            await _whyUsCollection.FindOneAndReplaceAsync(x => x.Id == whyUs.Id, whyUs);
        }
    }
}
