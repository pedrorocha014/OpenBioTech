using AnalysisConsumer.Analysis;
using ConsumerTests.Utils;
using System.Text.Json;

namespace ConsumerTests.Analysis
{
    public class DeleteOperationTest
    {
        Models models = new Models();

        [Test]
        public void Execution_Should_Not_Delete_When_Others_Operations()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "2insAD" };
            var deleteOperation = new DeleteOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation().Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(sequence, Is.EqualTo(resultObj));
        }

        [Test]
        public void Execution_Should_Delete_One_Protein()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "del1" };
            var deleteOperation = new DeleteOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation().Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[0], Is.EqualTo('-'));
        }

        [Test]
        public void Execution_Should_Delete_Range_Protein()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "del2-3" };
            var deleteOperation = new DeleteOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation().Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[1], Is.EqualTo('-'));
            Assert.That(resultObj[2], Is.EqualTo('-'));
        }
    }
}
