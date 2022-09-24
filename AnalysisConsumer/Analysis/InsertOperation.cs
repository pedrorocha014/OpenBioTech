using AnalysisConsumer.Analysis.Interfaces;
using AnalysisConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnalysisConsumer.Analysis
{
    public class InsertOperation: IAnalysisOperation
    {
        public string OperationName { get => _operationName; set => _operationName = value; }
        private string _operationName;

        private readonly List<char> _sequence;
        private readonly List<string> _mutations;

        public InsertOperation(List<char> sequence, List<string> mutations)
        {
            OperationName = "INSERT";

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

                    if (!mutation.Contains("ins"))
                    {
                        return;
                    }

                    var dataString = mutation.Remove(0, 3); // ins214EPE  ->  214EPE

                    var positionString = Regex.Match(dataString, @"\d+").Value; // 214EPE  ->  214
                    var valuesArray = dataString.Remove(0, positionString.Length).ToCharArray(); // 214  -> EPE

                    _sequence.InsertRange(Int32.Parse(positionString) - 1, valuesArray);
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
