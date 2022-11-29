using OBioTech.Helpers.Data;
using OBioTech.Models;
using OBioTech.Models.Dtos;
using OBioTech.Services.Analysis.Operation;
using System.Numerics;

namespace OBioTech.Services.OperationService.Operation
{
    public class ProteinVisualization: OperationBase
    {
        private List<string> _lines = new List<string>();
        public List<PdbModel> _pdbModels = new List<PdbModel>();

        private readonly string _modelNumber;


        public ProteinVisualization(ProteinVisualizationDto proteinVisualizationDto)
        {
            _modelNumber = proteinVisualizationDto.ModelNumber;
            _lines = ExtractData.ReadAsList(proteinVisualizationDto.File);
            _pdbModels = ExtractData.GetPdbModels(_lines);
        }

        public override T ExecuteOperation<T>()
        {
            ProteinVisualizationResultDto resultDto = new ProteinVisualizationResultDto();

            _pdbModels = _pdbModels.Where(e => e.Id == Int32.Parse(_modelNumber)).ToList();

            resultDto.IsSuccess = true;
            resultDto.Message = $"Operation performed successfully.";
            resultDto.NormalizedModel = _pdbModels[0];

            return ConvertGeneric.GenericToClass<ProteinVisualizationResultDto, T>(resultDto);
        }
    }
}
