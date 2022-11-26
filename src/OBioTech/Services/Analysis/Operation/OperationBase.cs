using OBioTech.Models;

namespace OBioTech.Services.Analysis.Operation
{
    public abstract class OperationBase
    {
        public OperationResultDto analysisResult = new OperationResultDto();
        public abstract OperationResultDto ExecuteOperation();
    }
}
