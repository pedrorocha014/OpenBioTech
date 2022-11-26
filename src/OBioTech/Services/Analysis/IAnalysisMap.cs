using OBioTech.Models;
using OBioTech.Models.Dtos;

namespace OBioTech.Services.Analysis
{
    public interface IAnalysisMap
    {
        public OperationResultDto Map(SequenceDto analysisDto);
        public OperationResultDto Map(RmsdDto rmsdDto);
    }
}