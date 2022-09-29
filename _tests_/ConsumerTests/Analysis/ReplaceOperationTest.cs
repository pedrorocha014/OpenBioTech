using AnalysisConsumer.Analysis;
using ConsumerTests.Utils;
using System.Text.Json;

namespace ConsumerTests.Analysis
{
    public class ReplaceOperationTest
    {
        Models models = new Models();

        [Test]
        public void Execution_Should_Not_Replace_When_Others_Operations()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "del1", "ins" };
            var deleteOperation = new ReplaceOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation().Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(sequence, Is.EqualTo(resultObj));
        }

        [Test]
        public void Execution_IsNot_Success_When_ProteinPosition_Is_Wrong()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "A1A" };
            var deleteOperation = new ReplaceOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation();

            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void Execution_Should_Replace_Protein()
        {
            var sequence = models.sequence;
            var mutations = new List<string> { "M1A" };
            var deleteOperation = new ReplaceOperation(sequence, mutations);

            var result = deleteOperation.ExecuteOperation().Value;
            var resultObj = JsonSerializer.Deserialize<List<char>>(result);

            Assert.That(resultObj[0], Is.EqualTo('A'));
        }
    }
}
