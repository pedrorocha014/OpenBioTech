using AnalysisConsumer.Analysis.Interfaces;
using AnalysisConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnalysisConsumer.Analysis
{
    public class DeleteOperation : IAnalysisOperation
    {
        public string OperationName { get => _operationName; set => _operationName = value; }
        private string _operationName;

        private readonly List<char> _sequence;
        private readonly List<string> _mutations;

        public DeleteOperation(List<char> sequence, List<string> mutations)
        {
            OperationName = "DELETE";

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

                    if (!mutation.Contains("del"))
                    {
                        return;
                    }

                    var positionsToDelete = mutation.Remove(0, 3).Split('-').ToList();

                    if (positionsToDelete.Count > 1)
                    {
                        var startRange = Int32.Parse(positionsToDelete[0]);
                        var endRange = Int32.Parse(positionsToDelete[1]);

                        foreach (int position in Enumerable.Range(startRange, endRange - startRange + 1))
                        {
                            _sequence[position + 1] = '-';
                        }
                    }
                    else
                    {
                        _sequence[Int32.Parse(positionsToDelete[0]) + 1] = '-';
                    }

                    
                });
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
