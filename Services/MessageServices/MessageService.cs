using AkademiQMongoDb.DTOs.MessageDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly IMongoCollection<Message> _messageCollection;

        public MessageService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _messageCollection = database.GetCollection<Message>(databaseSettings.MessageCollectionName);
        }

        public async Task CreateAsync(CreateMessageDto messageDto)
        {
            var message = messageDto.Adapt<Message>();
            await _messageCollection.InsertOneAsync(message);
        }

        public async Task DeleteAsync(string id)
        {
            await _messageCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultMessageDto>> GetAllAsync()
        {
            var messages = await _messageCollection.Find(_ => true).ToListAsync();
            return messages.Adapt<List<ResultMessageDto>>();
        }

        public async Task<UpdateMessageDto> GetByIdAsync(string id)
        {
            var message = await _messageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return message.Adapt<UpdateMessageDto>();
        }

        public async Task UpdateAsync(UpdateMessageDto messageDto)
        {
            var message = messageDto.Adapt<Message>();
            await _messageCollection.FindOneAndReplaceAsync(x => x.Id == message.Id, message);
        }
    }
}
