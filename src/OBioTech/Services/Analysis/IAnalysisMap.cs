using OBioTech.Models;

namespace OBioTech.Services.Analysis
{
    public interface IAnalysisMap
    {
        public AnalysisResult Map(AnalysisDto analysisDto);
    }
}