using AkademiQMongoDb.DTOs.ContactDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public ContactService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
        }

        public async Task CreateAsync(CreateContactDto contactDto)
        {
            var contact = contactDto.Adapt<Contact>();
            await _contactCollection.InsertOneAsync(contact);
        }

        public async Task DeleteAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var contacts = await _contactCollection.Find(_ => true).ToListAsync();
            return contacts.Adapt<List<ResultContactDto>>();
        }

        public async Task<UpdateContactDto> GetByIdAsync(string id)
        {
            var contact = await _contactCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return contact.Adapt<UpdateContactDto>();
        }

        public async Task UpdateAsync(UpdateContactDto contactDto)
        {
            var contact = contactDto.Adapt<Contact>();
            await _contactCollection.FindOneAndReplaceAsync(x => x.Id == contact.Id, contact);
        }
    }
}
