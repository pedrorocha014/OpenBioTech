using OBioTech.Models;

namespace OBioTech.Services.Analysis
{
    public interface IAnalysisMap
    {
        public AnalysisResult MapAnalysis(AnalysisDto analysisDto);
    }
}