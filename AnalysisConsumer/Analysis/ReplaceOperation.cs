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
    public class ReplaceOperation : IAnalysisOperation
    {
        public string OperationName { get => _operationName; set => _operationName = value; }
        private string _operationName;

        private readonly List<char> _sequence;
        private readonly char _valueToReplace;
        private readonly int _position;
        private readonly char _newValue;

        public ReplaceOperation(string operationName, List<char> sequence, char valueToReplace, int position, char newValue)
        {
            OperationName = operationName;

            _sequence = sequence;
            _valueToReplace = valueToReplace;
            _position = position;
            _newValue = newValue;
        }

        public Result ExecuteOperation()
        {
            var result = new Result { Operation = "REPLACE" };

            var indexPosition = _position - 1;

            if (_sequence[indexPosition] != _valueToReplace)
            {
                result.IsSuccess = false;
                result.Message = $"Position {_position} does not contain {_valueToReplace}.";
                result.Value = "";

                return result;
            }

            _sequence[indexPosition] = _newValue;

            result.IsSuccess = true;
            result.Message = $"Operation performed successfully.";
            result.Value = JsonSerializer.Serialize<List<Char>>(_sequence);

            return result;
        }
    }
}
