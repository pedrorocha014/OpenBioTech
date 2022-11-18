using OBioTech.Helpers.CustomErrors;
using OBioTech.Helpers.Enums;
using OBioTech.Models;
using OBioTech.Services.Analysis.Operation;
namespace OBioTech.Services.Analysis
{
    public class AnalysisMap : IAnalysisMap
    {
        public AnalysisResult Map(AnalysisDto analysisDto)
        {
            _ = Enum.TryParse(analysisDto.Type, out AnalysisType analysisType);

            OperationBase? operation = null;

            switch (analysisType)
            {
                case AnalysisType.SEQUENCE:
                    operation = new ProteinSequence(analysisDto);
                    break;

                case AnalysisType.RMSD:
                    operation = new RMSD(analysisDto);
                    break;
                default:
                    break;
            }

            var result = operation?.ExecuteOperation();

            if (result is null)
            {
                throw new OperationException("Operation is Null.");
            }

            return result;
        }
    }
}
