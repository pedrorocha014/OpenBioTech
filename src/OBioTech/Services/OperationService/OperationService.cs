using OBioTech.Helpers.CustomErrors;
using OBioTech.Helpers.Data;
using OBioTech.Models.Dtos;
using OBioTech.Services.Analysis.Operation;
using OBioTech.Services.OperationService.Operation;

namespace OBioTech.Services.Analysis
{
    public class OperationService : IOperationService
    {
        public T SelectOperation<U, T>(U operationDto) => operationDto switch
        {
            SequenceDto             => new ProteinSequence(ConvertGeneric.GenericToClass<U,SequenceDto>(operationDto)).ExecuteOperation<T>(),
            RmsdDto                 => new RMSD(ConvertGeneric.GenericToClass<U,RmsdDto>(operationDto)).ExecuteOperation<T>(),
            ProteinVisualizationDto => new ProteinVisualization(ConvertGeneric.GenericToClass<U, ProteinVisualizationDto>(operationDto)).ExecuteOperation<T>(),
            null                    => throw new OperationException("Operation is Null."),
            _                       => throw new OperationException("Invalid Operation.")
        };
    }
}
