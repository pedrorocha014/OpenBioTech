using AnalysisConsumer.Analysis.Interfaces;
using AnalysisConsumer.Helpers.Errors;
using AnalysisConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnalysisConsumer.Analysis
{
    public class ReplaceOperation : IAnalysisOperation
    {
        public string OperationName { get => _operationName; set => _operationName = value; }
        private string _operationName;

        private readonly List<char> _sequence;
        private readonly List<string> _mutations;

        public ReplaceOperation(List<char> sequence, List<string> mutations)
        {
            OperationName = "REPLACE";

            _sequence = sequence;
            _mutations = mutations;
        }

        public Result ExecuteOperation()
        {
            var result = new Result { Operation = OperationName };

            try
            {
                _mutations.ForEach(mutation =>
                {
                    mutation = mutation.Trim();

                    if (mutation.Contains("del") || mutation.Contains("ins"))
                    {
                        return;
                    }

                    char protainToReplace = mutation[0];
                    char protainNewValue = mutation[mutation.Length - 1];

                    var indexFrom = mutation.IndexOf(protainToReplace) + 1;
                    var indexTo = mutation.LastIndexOf(protainNewValue);

                    var position = Int32.Parse(mutation.Substring(indexFrom, indexTo - indexFrom));

                    if (_sequence[position - 1] != protainToReplace)
                    {
                        throw new ValuePositionExeption($"Position {position - 1} does not contain {protainToReplace}.");
                    }

                    _sequence[position - 1] = protainNewValue;
                });
            }
            catch (ValuePositionExeption e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
                result.Value = "";

                return result;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "Internal Error.";
                result.Value = "";

                return result;
            }

            result.IsSuccess = true;
            result.Message = $"Operation performed successfully.";
            result.Value = JsonSerializer.Serialize<List<Char>>(_sequence);

            return result;
        }
    }
}
