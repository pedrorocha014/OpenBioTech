using AnalysisConsumer.Analysis;
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
                    var values = op.Values?.Trim().Split(';');

                    switch (op.Operation)
                    {
                        case "REPLACE":
                            var replaceOperation = new ReplaceOperation(sequence, mutations);
                            var replaceResult = replaceOperation.ExecuteOperation();
                            analysisResult.Result.Add(replaceResult);
                            break;

                        case "DELETE":
                            var deleteOperation = new DeleteOperation(sequence, mutations);
                            var deleteResult = deleteOperation.ExecuteOperation();
                            analysisResult.Result.Add(deleteResult);
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
