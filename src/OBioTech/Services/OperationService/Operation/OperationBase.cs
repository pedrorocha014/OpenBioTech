using OBioTech.Models;

namespace OBioTech.Services.Analysis.Operation
{
    public abstract class OperationBase
    {
        public abstract T ExecuteOperation<T>();
    }
}
