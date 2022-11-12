using OBioTech.Models;

namespace OBioTech.Services.Register
{
    public interface IRegisterService
    {
        void RegisterAnalysisResult(AnalysisResult analysisResult);
        List<RegisterResult> GetResults();
    }
}