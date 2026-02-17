using AkademiQMongoDb.DTOs.GalleryDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.GalleryServices
{
    public class GalleryService : IGalleryService
    {
        private readonly IMongoCollection<Gallery> _galleryCollection;

        public GalleryService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _galleryCollection = database.GetCollection<Gallery>(databaseSettings.GalleryCollectionName);
        }

        public async Task CreateAsync(CreateGalleryDto galleryDto)
        {
            var gallery = galleryDto.Adapt<Gallery>();
            await _galleryCollection.InsertOneAsync(gallery);
        }

        public async Task DeleteAsync(string id)
        {
            await _galleryCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultGalleryDto>> GetAllAsync()
        {
            var galleries = await _galleryCollection.Find(_ => true).ToListAsync();
            return galleries.Adapt<List<ResultGalleryDto>>();
        }

        public async Task<UpdateGalleryDto> GetByIdAsync(string id)
        {
            var gallery = await _galleryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return gallery.Adapt<UpdateGalleryDto>();
        }

        public async Task UpdateAsync(UpdateGalleryDto galleryDto)
        {
            var gallery = galleryDto.Adapt<Gallery>();
            await _galleryCollection.FindOneAndReplaceAsync(x => x.Id == gallery.Id, gallery);
        }
    }
}
