using OBioTech.Helpers.Enums;
using OBioTech.Models;
using OBioTech.Services.Analysis.Operation;

namespace OBioTech.Services.Analysis
{
    public class AnalysisMap : IAnalysisMap
    {
        public RegisterResult MapAnalysis(AnalysisDto analysisDto)
        {
            RegisterResult analysisResult = new RegisterResult();

            AnalysisType analysisType;
            IOperation operation;

            Enum.TryParse(analysisDto.Type, out analysisType);

            switch (analysisType)
            {
                case AnalysisType.PROTEIN_SEQUENCE:
                    var sequence = GetSequenceList(analysisDto.Sequence);
                    var mutations = GetMutationList(analysisDto.Mutations);

                    operation = new ProteinSequence(sequence, mutations);
                    break;
                default:
                    break;
            }

            operation.ExecuteOperation();

            return analysisResult;
        }

        private static List<char> GetSequenceList(string sequenceString)
        {
            return
                sequenceString
                .Trim()
                .ToCharArray()
                .ToList();
        }

        private static List<string> GetMutationList(string mutationString)
        {
            return mutationString
                .Trim()
                .Split(',')
                .ToList();
        }
    }
}
