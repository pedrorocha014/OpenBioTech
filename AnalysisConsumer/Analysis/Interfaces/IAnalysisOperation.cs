using AnalysisConsumer.Models;

namespace AnalysisConsumer.Analysis.Interfaces
{
    public interface IAnalysisOperation
    {
        public string OperationName { get; set; }
        public Result ExecuteOperation(); 
    }
}
