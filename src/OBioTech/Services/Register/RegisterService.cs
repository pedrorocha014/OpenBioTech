using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OBioTech.Models;

namespace OBioTech.Services.Register
{
    public class RegisterService
    {
        private readonly IMongoCollection<RegisterResult> _registerCollection;

        public RegisterService(
            IOptions<DatabaseModel> settings)
        {
            var mongoClient = new MongoClient("mongodb+srv://obiotech:P*0a3lpqa*@cluster0.iofqkcq.mongodb.net/?retryWrites=true&w=majority");

            var mongoDatabase = mongoClient.GetDatabase("OBioTech");

            _registerCollection = mongoDatabase.GetCollection<RegisterResult>("Registers");
        }

        public async Task<List<RegisterResult>> GetAsync() =>
            await _registerCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(AnalysisResult analysisResult)
        {
            var resultDto = new RegisterResult
            {
                IsSuccess = analysisResult.IsSuccess,
                Message = analysisResult.Message,
                Operation = analysisResult.Operation,
                Value = analysisResult.Value
            };

            await _registerCollection.InsertOneAsync(resultDto);
        }
    }
}
