using OBioTech.Models;

namespace OBioTech.Services.Analysis.Operation
{
    public abstract class OperationBase
    {
        public AnalysisResult analysisResult = new AnalysisResult();
        public abstract AnalysisResult ExecuteOperation();
    }
}
