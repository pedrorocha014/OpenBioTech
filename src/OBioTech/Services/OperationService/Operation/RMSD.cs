using OBioTech.Helpers.Data;
using OBioTech.Models;
using OBioTech.Models.Dtos;

namespace OBioTech.Services.Analysis.Operation
{
    public class RMSD : OperationBase
    {
        private List<string> _lines = new List<string>();
        private List<PdbModel> _pdbModels = new List<PdbModel>();
        private List<RmsdResult> _rmsdList = new List<RmsdResult>();

        public RMSD(RmsdDto rmsdDto)
        {
            _lines = ExtractData.ReadAsList(rmsdDto.File);
            _pdbModels = ExtractData.GetPdbModels(_lines);
        }

        public override T ExecuteOperation<T>()
        {
            RmsdResultDto rmsdResultDto = new RmsdResultDto();

            _pdbModels = _pdbModels.Where(e => e.Atoms.Count > 0).ToList();

            foreach (var model_1 in _pdbModels)
            {
                foreach (var model_2 in _pdbModels.Where(e => model_1.Id != e.Id))
                {
                    CalculateRMSD(model_1, model_2);
                }
            }

            _rmsdList = _rmsdList.OrderBy(x => x.Rmsd).DistinctBy(x => x.Rmsd).ToList();

            rmsdResultDto.IsSuccess = true;
            rmsdResultDto.Message = $"Operation performed successfully.";
            rmsdResultDto.RmsdResult = _rmsdList;

            return ConvertGeneric.GenericToClass<RmsdResultDto, T>(rmsdResultDto);
        }

        private void CalculateRMSD(PdbModel model_1, PdbModel model_2)
        {
            var atoms_1 = model_1.Atoms;
            var atoms_2 = model_2.Atoms;
    
            if (atoms_1.Count != atoms_2.Count)
            {
                throw new Exception("Models with different numbers of atoms.");
            }

            var sum = 0.0;

            foreach (var item1 in atoms_1)
            {
                var i = atoms_1.IndexOf(item1);
                var item2 = atoms_2[i];

                var deltaX = (item1.X - item2.X);
                var deltaY = (item1.Y - item2.Y);
                var deltaZ = (item1.Z - item2.Z);

                sum += Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) + Math.Pow(deltaZ, 2);
            }

            var rmsdResult = Math.Sqrt(sum / atoms_1.Count);
            var models = $"{model_1.Id} - {model_2.Id}"; 

            _rmsdList.Add(new RmsdResult { Rmsd = rmsdResult, Models = models});
        }
    }
}
