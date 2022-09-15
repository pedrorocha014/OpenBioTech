using AnalysisRegister.Models;

namespace AnalysisRegister.Services
{
    public interface IRegister
    {
        void RegisterAnalysisResult(Result analysisResult);
        List<RegisterResult> GetResults();
    }
}
