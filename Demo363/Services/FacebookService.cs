using Demo363.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Demo363.Services
{
    public class FacebookService
    {
        private readonly IMongoCollection<Post> _postCollection;

        public FacebookService(
            IOptions<FacebookDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _postCollection = mongoDatabase.GetCollection<Post>(
                "PostCollection");
        }

        public async Task<List<Post>> GetAsync() =>
            await _postCollection.Find(_ => true).ToListAsync();

        public async Task<Post?> GetAsync(string id) =>
            await _postCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Post newBook) =>
            await _postCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Post updatedBook) =>
            await _postCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _postCollection.DeleteOneAsync(x => x.Id == id);
    }
}
