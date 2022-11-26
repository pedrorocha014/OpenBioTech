using OBioTech.Helpers.CustomErrors;
using OBioTech.Models.Dtos;
using OBioTech.Services.Analysis.Operation;
namespace OBioTech.Services.Analysis
{
    public class OperationService : IOperationService
    {
        public T SelectOperation<U, T>(U operationDto) => operationDto switch
        {
            SequenceDto         => new ProteinSequence((SequenceDto)Convert.ChangeType(operationDto, typeof(SequenceDto))).ExecuteOperation<T>(),
            RmsdDto             => new RMSD((RmsdDto)Convert.ChangeType(operationDto, typeof(RmsdDto))).ExecuteOperation<T>(),
            null                => throw new OperationException("Operation is Null."),
            _                   => throw new OperationException("Operation is Null.")
        };
    }
}
