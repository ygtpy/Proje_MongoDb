using AkademiQMongoDb.DTOs.ServiceDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.ServiceServices
{
    public class ServiceService : IServiceService
    {
        private readonly IMongoCollection<Service> _serviceCollection;

        public ServiceService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }

        public async Task CreateAsync(CreateServiceDto serviceDto)
        {
            var service = serviceDto.Adapt<Service>();
            await _serviceCollection.InsertOneAsync(service);
        }

        public async Task DeleteAsync(string id)
        {
            await _serviceCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultServiceDto>> GetAllAsync()
        {
            var services = await _serviceCollection.Find(_ => true).ToListAsync();
            return services.Adapt<List<ResultServiceDto>>();
        }

        public async Task<UpdateServiceDto> GetByIdAsync(string id)
        {
            var service = await _serviceCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return service.Adapt<UpdateServiceDto>();
        }

        public async Task UpdateAsync(UpdateServiceDto serviceDto)
        {
            var service = serviceDto.Adapt<Service>();
            await _serviceCollection.FindOneAndReplaceAsync(x => x.Id == service.Id, service);
        }
    }
}
