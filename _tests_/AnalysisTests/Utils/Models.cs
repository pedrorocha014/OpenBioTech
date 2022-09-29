using AnalysisDelivery.Models;

namespace AnalysisTests.Utils
{
    public class Models
    {
        public AnalysisDto analysisDto { get => GetAnalysisDto(); }

        private AnalysisDto GetAnalysisDto()
        {
            AnalysisDto obj = new AnalysisDto
            {
                Mutations = "F2G ,M1B ,A67V, del1",
                Sequence = "MFVFLVLLPLVSS",
                Operations = new List<Operations> { new Operations { Operation = "Replace" } }
            };
            return obj;
        }
    }
}
