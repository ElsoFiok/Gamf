using DSTSITBemutatobeadando.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace DSTSITBemutatobeadando.Services
{
    public class HallgatokService
    {
        private readonly IMongoCollection<Hallgato> _hallgatokCollection;
        public HallgatokService(
        IOptions<GamfDatabaseSettings> GamfDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                GamfDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                GamfDatabaseSettings.Value.DatabaseName);

            _hallgatokCollection = mongoDatabase.GetCollection<Hallgato>(
                GamfDatabaseSettings.Value.HallgatokCollectionName);
        }
        public async Task<List<Hallgato>> GetAsync() =>
        await _hallgatokCollection.Find(_ => true).ToListAsync();

        public async Task<Hallgato?> GetAsync(string id) =>
            await _hallgatokCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Hallgato newHallgato) =>
            await _hallgatokCollection.InsertOneAsync(newHallgato);

        public async Task UpdateAsync(string id, Hallgato updatedBook) =>
            await _hallgatokCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _hallgatokCollection.DeleteOneAsync(x => x.Id == id);
    }
}
