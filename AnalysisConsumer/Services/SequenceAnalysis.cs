using AnalysisConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnalysisConsumer.Services
{
    public static class SequenceAnalysis
    {
        public static AnalysisResult InitializeOperation(AnalysisDto analysisDto)
        {
            var sequence = GetSequenceList(analysisDto.Sequence);
            var mutations = GetMutationList(analysisDto.Mutations);

            AnalysisResult analysisResult = new AnalysisResult();
            analysisResult.Result = new List<Result>();

            analysisDto.Operations.ForEach(op =>
            {
                try
                {
                    var values = op.Values.Trim().Split(';');

                    switch (op.Operation)
                    {
                        case "REPLACE":
                            var replaceResult = Replace(sequence, values[0].ToCharArray()[0], Int32.Parse(values[1]), values[2].ToCharArray()[0]);
                            analysisResult.Result.Add(replaceResult);
                            break;
                    }
                }
                catch (Exception)
                {
                    var errorResult = new Result {
                        Operation = op.Operation,
                        Value = op.Values,
                        IsSuccess = false,
                        Message = "Operation Error"
                    };
                    analysisResult.Result.Add(errorResult);
                }
            });

            return analysisResult;
        }

        private static Result Replace(List<char> sequence, char valueToReplace, int position, char newValue)
        {
            var result = new Result { Operation = "REPLACE" };

            var indexPosition = position - 1;

            if (sequence[indexPosition] != valueToReplace)
            {
                result.IsSuccess = false;
                result.Message = $"Position {position} does not contain {valueToReplace}.";
                result.Value = "";

                return result;
            }

            sequence[indexPosition] = newValue;

            result.IsSuccess = true;
            result.Message = $"Operation performed successfully.";
            result.Value = JsonSerializer.Serialize<List<Char>>(sequence);

            return result;
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
