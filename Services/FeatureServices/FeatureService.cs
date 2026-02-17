using AkademiQMongoDb.DTOs.FeatureDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;

        public FeatureService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
        }

        public async Task CreateAsync(CreateFeatureDto featureDto)
        {
            var feature = featureDto.Adapt<Feature>();
            await _featureCollection.InsertOneAsync(feature);
        }

        public async Task DeleteAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            var features = await _featureCollection.Find(_ => true).ToListAsync();
            return features.Adapt<List<ResultFeatureDto>>();
        }

        public async Task<UpdateFeatureDto> GetByIdAsync(string id)
        {
            var feature = await _featureCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return feature.Adapt<UpdateFeatureDto>();
        }

        public async Task UpdateAsync(UpdateFeatureDto featureDto)
        {
            var feature = featureDto.Adapt<Feature>();
            await _featureCollection.FindOneAndReplaceAsync(x => x.Id == feature.Id, feature);
        }
    }
}
