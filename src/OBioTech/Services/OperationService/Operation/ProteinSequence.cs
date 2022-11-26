using OBioTech.Helpers.CustomErrors;
using OBioTech.Helpers.Data;
using OBioTech.Models.Dtos;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace OBioTech.Services.Analysis.Operation
{
    public class ProteinSequence : OperationBase
    {
        private readonly List<char> _sequence;
        private readonly List<string> _mutations;

        public ProteinSequence(SequenceDto analysisDto)
        {
            _sequence = ExtractData.GetSequenceList(analysisDto.Sequence);
            _mutations = ExtractData.GetMutationList(analysisDto.Mutations);
        }

        public override T ExecuteOperation<T>()
        {
            SequenceResultDto sequenceResultDto = new SequenceResultDto();
            sequenceResultDto.Operation = "Sequence";

            try
            {
                _mutations.ForEach(mutation =>
                {
                    mutation = mutation.Trim();

                    if (mutation.Contains("del"))
                    {
                        Delete(mutation);
                        return;
                    }

                    if (mutation.Contains("ins"))
                    {
                        Insert(mutation);
                        return;
                    }

                    Replace(mutation);
                });
            }
            catch (ValuePositionExeption e)
            {
                sequenceResultDto.IsSuccess = false;
                sequenceResultDto.Message = e.Message;
                sequenceResultDto.Value = "";

                return (T)Convert.ChangeType(sequenceResultDto, typeof(T));
            }
            catch (Exception e)
            {
                sequenceResultDto.IsSuccess = false;
                sequenceResultDto.Message = "Internal Error.";
                sequenceResultDto.Value = "";

                return (T)Convert.ChangeType(sequenceResultDto, typeof(T));
            }

            sequenceResultDto.IsSuccess = true;
            sequenceResultDto.Message = $"Operation performed successfully.";
            sequenceResultDto.Value = JsonSerializer.Serialize<List<Char>>(_sequence);

            return (T)Convert.ChangeType(sequenceResultDto, typeof(T));
        }

        private void Replace(string mutation)
        {
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
        }

        private void Insert(string mutation)
        {
            var dataString = mutation.Remove(0, 3); // ins214EPE  ->  214EPE

            var positionString = Regex.Match(dataString, @"\d+").Value; // 214EPE  ->  214
            var valuesArray = dataString.Remove(0, positionString.Length).ToCharArray(); // 214  -> EPE

            _sequence.InsertRange(Int32.Parse(positionString) - 1, valuesArray);
        }

        private void Delete(string mutation)
        {
            var positionsToDelete = mutation.Remove(0, 3).Split('-').ToList();

            if (positionsToDelete.Count > 1)
            {
                var startRange = Int32.Parse(positionsToDelete[0]);
                var endRange = Int32.Parse(positionsToDelete[1]);

                foreach (int position in Enumerable.Range(startRange, endRange - startRange + 1))
                {
                    _sequence[position - 1] = '-';
                }
            }
        }
    }
}
