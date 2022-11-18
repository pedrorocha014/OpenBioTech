﻿using OBioTech.Helpers.Data;
using OBioTech.Models;
using System.Text.Json;

namespace OBioTech.Services.Analysis.Operation
{
    public class RMSD : OperationBase
    {
        private List<string> _lines = new List<string>();
        private List<List<Atom>> _atoms = new List<List<Atom>>();
        private List<RmsdResult> _rmsdList = new List<RmsdResult>();

        public RMSD(AnalysisDto analysisDto)
        {
            _lines = ExtractData.ReadAsList(analysisDto.File);
        }

        public override AnalysisResult ExecuteOperation()
        {
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
                            atom.Clear();

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
                analysisResult.IsSuccess = false;
                analysisResult.Message = "Internal Error.";
                analysisResult.Value = "";

                return analysisResult;
            }

            //Model number ta vindo errado
            CalculateRMSD(_atoms[0], _atoms[1]);

            analysisResult.IsSuccess = true;
            analysisResult.Message = $"Operation performed successfully.";
            analysisResult.Value = JsonSerializer.Serialize<List<RmsdResult>>(_rmsdList);

            return analysisResult;
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
