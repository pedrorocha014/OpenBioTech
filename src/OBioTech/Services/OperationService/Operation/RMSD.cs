using OBioTech.Helpers.Data;
using OBioTech.Models;
using OBioTech.Models.Dtos;
using System.Text.Json;

namespace OBioTech.Services.Analysis.Operation
{
    public class RMSD : OperationBase
    {
        private List<string> _lines = new List<string>();
        private List<List<Atom>> _atoms = new List<List<Atom>>();
        private List<RmsdResult> _rmsdList = new List<RmsdResult>();

        public RMSD(RmsdDto rmsdDto)
        {
            _lines = ExtractData.ReadAsList(rmsdDto.File);
        }

        public override T ExecuteOperation<T>()
        {
            RmsdResultDto rmsdResultDto = new RmsdResultDto();
            var atom = new List<Atom>();
            var modelNumber = 0;

            try
            {
                _lines.ForEach(e =>
                {
                    if (e.StartsWith("MODEL"))
                    {
                        if (modelNumber != 0)
                        {
                            _atoms.Add(atom);
                            atom = new List<Atom>();

                            modelNumber++;
                        }
                        else
                        {
                            modelNumber++;
                        }

                        return;
                    }

                    if (e.StartsWith("ATOM"))
                    {
                        var atomData = ExtractData.GetDataFromPdbAtomText(e, modelNumber.ToString());
                        atom.Add(atomData);

                        return;
                    }

                });

                if (atom.Count > 0)
                {
                    _atoms.Add(atom);
                }
            }
            catch (Exception e)
            {
                rmsdResultDto.IsSuccess = false;
                rmsdResultDto.Message = "Internal Error.";
                rmsdResultDto.RmsdResult = _rmsdList;

                return ConvertGeneric.GenericToClass<RmsdResultDto, T>(rmsdResultDto);
            }

            foreach (var item_1 in _atoms)
            {
                foreach (var item_2 in _atoms.Where(e => item_1[0].Model != e[0].Model))
                {
                    CalculateRMSD(item_1, item_2);
                }
            }

            _rmsdList = _rmsdList.OrderBy(x => x.Rmsd).ToList();

            rmsdResultDto.IsSuccess = true;
            rmsdResultDto.Message = $"Operation performed successfully.";
            rmsdResultDto.RmsdResult = _rmsdList;

            return ConvertGeneric.GenericToClass<RmsdResultDto, T>(rmsdResultDto);
        }

        private void CalculateRMSD(List<Atom> model_1, List<Atom> model_2)
        {
            if (model_1.Count != model_2.Count)
            {
                throw new Exception("Models with different numbers of atoms.");
            }

            var sum = 0.0;

            foreach (var item1 in model_1)
            {
                var i = model_1.IndexOf(item1);
                var item2 = model_2[i];

                var deltaX = (item1.X - item2.X);
                var deltaY = (item1.Y - item2.Y);
                var deltaZ = (item1.Z - item2.Z);

                sum += Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) + Math.Pow(deltaZ, 2);
            }

            var rmsdResult = Math.Sqrt(sum / model_1.Count);
            var models = $"{model_1[0].Model} - {model_2[0].Model}"; 

            _rmsdList.Add(new RmsdResult { Rmsd = rmsdResult, Models = models});
        }
    }
}
