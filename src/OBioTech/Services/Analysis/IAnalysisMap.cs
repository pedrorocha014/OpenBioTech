using OBioTech.Models;
using OBioTech.Models.Dtos;

namespace OBioTech.Services.Analysis
{
    public interface IAnalysisMap
    {
        public AnalysisResult Map(AnalysisDto analysisDto);
        public AnalysisResult Map(RmsdDto rmsdDto);
    }
}