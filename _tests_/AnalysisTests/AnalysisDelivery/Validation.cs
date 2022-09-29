using AnalysisDelivery.Validations;

namespace AnalysisTests.AnalysisDelivery
{
    public class Validation
    {
        [Test]
        public void When_Operation_Is_Invalid_Should_Return_Error()
        {
            var validation = new OperationsType();
            var operation = "RandomInvalidOperation";

            var result = validation.IsValid(operation);

            Assert.IsFalse(result);
        }

        [Test]
        public void When_Operation_Is_Replace_Should_Return_Success()
        {
            var validation = new OperationsType();
            var operation = "Replace";

            var result = validation.IsValid(operation);

            Assert.IsTrue(result);
        }

        [Test]
        public void When_Operation_Is_Insert_Should_Return_Success()
        {
            var validation = new OperationsType();
            var operation = "Insert";

            var result = validation.IsValid(operation);

            Assert.IsTrue(result);
        }

        [Test]
        public void When_Operation_Is_Delete_Should_Return_Success()
        {
            var validation = new OperationsType();
            var operation = "Delete";

            var result = validation.IsValid(operation);

            Assert.IsTrue(result);
        }
    }
}
