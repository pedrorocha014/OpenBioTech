using OBioTech.Helpers.Enums;
using OBioTech.Models;
using OBioTech.Services.Analysis.Operation;
namespace OBioTech.Services.Analysis
{
    public class AnalysisMap : IAnalysisMap
    {
        public AnalysisResult Map(AnalysisDto analysisDto)
        {
            AnalysisType analysisType;
            Enum.TryParse(analysisDto.Type, out analysisType);

            OperationBase operation = null;

            switch (analysisType)
            {
                case AnalysisType.SEQUENCE:
                    var sequence = GetSequenceList(analysisDto.Sequence);
                    var mutations = GetMutationList(analysisDto.Mutations);

                    operation = new ProteinSequence(sequence, mutations);
                    break;
                case AnalysisType.RMSD:
                    operation = new RMSD();
                    break;
                default:
                    break;
            }
            
            return operation.ExecuteOperation();
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
