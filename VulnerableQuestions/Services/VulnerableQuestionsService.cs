using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VulnerableQuestions.Models;

namespace VulnerableQuestions.Services;

public class VulnerableQuestionsService
{
    private readonly IMongoCollection<VulnerableQuestion> _questionsCollection;

    public VulnerableQuestionsService(
        IOptions<VulnerableQuestionsDatabaseSettings> vulnerableQuestionsDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            vulnerableQuestionsDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            vulnerableQuestionsDatabaseSettings.Value.DatabaseName);

        _questionsCollection = mongoDatabase.GetCollection<VulnerableQuestion>(
            vulnerableQuestionsDatabaseSettings.Value.VulnerableQuestionsCollectionName);
    }

    public async Task<List<VulnerableQuestion>> GetAsync() =>
        await _questionsCollection.Find(_ => true).ToListAsync();

    public async Task<VulnerableQuestion?> GetAsync(string id) =>
        await _questionsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
}