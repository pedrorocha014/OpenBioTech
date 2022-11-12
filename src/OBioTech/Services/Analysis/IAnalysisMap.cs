using OBioTech.Models;

namespace OBioTech.Services.Analysis
{
    public interface IAnalysisMap
    {
        public RegisterResult MapAnalysis(AnalysisDto analysisDto);
    }
}