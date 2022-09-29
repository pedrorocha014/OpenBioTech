using AnalysisConsumer.Analysis;
using ConsumerTests.Utils;
using System.Text.Json;

namespace ConsumerTests.Analysis
{
    public class InsertOperationTest
    {
        Models models = new Models();

        [Test]
        public void Execution_Should_Not_Insert_When_Others_Operations()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "del1" };
            var deleteOperation = new InsertOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation().Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(sequence, Is.EqualTo(resultObj));
        }

        [Test]
        public void Execution_Should_Insert_One_Protein()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "ins2X" };
            var deleteOperation = new InsertOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation().Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[1], Is.EqualTo('X'));
        }

        [Test]
        public void Execution_Should_Insert_Multiple_Protein()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "ins2EP" };
            var deleteOperation = new InsertOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation().Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[1], Is.EqualTo('E'));
            Assert.That(resultObj[2], Is.EqualTo('P'));
        }
    }
}
