using OBioTech.Helpers.Enums;
using OBioTech.Models;

namespace OBioTech.Services.Analysis
{
    public class AnalysisMap : IAnalysisMap
    {
        public RegisterResult MapAnalysis(AnalysisDto analysisDto)
        {
            RegisterResult analysisResult = new RegisterResult();

            AnalysisType analysisType;
            Enum.TryParse(analysisDto.Type, out analysisType);

            switch (analysisType)
            {
                case AnalysisType.PROTEIN_SEQUENCE:
                    break;
                default:
                    break;
            }

            return analysisResult;
        }
    }
}
