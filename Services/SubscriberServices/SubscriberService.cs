using AkademiQMongoDb.DTOs.SubscriberDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.SubscriberServices
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IMongoCollection<Subscriber> _subscriberCollection;

        public SubscriberService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _subscriberCollection = database.GetCollection<Subscriber>(databaseSettings.SubscriberCollectionName);
        }

        public async Task CreateAsync(CreateSubscriberDto createSubscriberDto)
        {
            var subscriber = new Subscriber
            {
                Email = createSubscriberDto.Email,
                CreatedDate = DateTime.Now
            };
            await _subscriberCollection.InsertOneAsync(subscriber);
        }

        public async Task<List<ResultSubscriberDto>> GetAllAsync()
        {
            var subscribers = await _subscriberCollection.Find(_ => true).ToListAsync();
            return subscribers.Select(x => new ResultSubscriberDto
            {
                Id = x.Id,
                Email = x.Email
            }).ToList();
        }

        public async Task<UpdateSubscriberDto> GetByIdAsync(string id)
        {
             var subscriber = await _subscriberCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
             if (subscriber == null) return null;
             return new UpdateSubscriberDto
             {
                 Id = subscriber.Id,
                 Email = subscriber.Email
             };
        }

        public async Task UpdateAsync(UpdateSubscriberDto updateSubscriberDto)
        {
            var subscriber = await _subscriberCollection.Find(x => x.Id == updateSubscriberDto.Id).FirstOrDefaultAsync();
            if (subscriber != null)
            {
                subscriber.Email = updateSubscriberDto.Email;
                subscriber.UpdatedDate = DateTime.Now;
                await _subscriberCollection.FindOneAndReplaceAsync(x => x.Id == updateSubscriberDto.Id, subscriber);
            }
        }

        public async Task DeleteAsync(string id)
        {
            await _subscriberCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
