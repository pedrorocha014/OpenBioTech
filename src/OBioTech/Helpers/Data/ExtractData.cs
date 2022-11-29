using OBioTech.Models;
using System.Numerics;

namespace OBioTech.Helpers.Data
{
    public static class ExtractData
    {
        public static List<PdbModel> GetPdbModels(List<string> lines)
        {
            var modelList = new List<PdbModel>();
            var pdbModel = new PdbModel();
            pdbModel.Atoms = new List<Atom>();

            var firstModel = true;

            lines.ForEach(x => {
                if (x.StartsWith("MODEL"))
                {
                    if (firstModel)
                    {
                        modelList.Add(pdbModel);
                        pdbModel = new PdbModel();
                        pdbModel.Atoms = new List<Atom>();
                        pdbModel.Id = Int32.Parse(x.Substring(10, 4));
                    }
                    else
                    {
                        pdbModel.Id = Int32.Parse(x.Substring(10, 4));
                        firstModel = false;
                    }
                }

                if (x.StartsWith("ATOM"))
                {
                    var atomData = GetDataFromPdbAtomText(x);
                    pdbModel.Atoms.Add(atomData);

                    return;
                }
            });

            if (pdbModel.Atoms.Count > 0)
            {
                modelList.Add(pdbModel);
            }

            return modelList;
        }


        public static Atom GetDataFromPdbAtomText(string pdbAtomText)
        {
            var type = pdbAtomText.Substring(76, 2).Trim();
            var x = float.Parse(pdbAtomText.Substring(30, 8).Replace('.',','));
            var y = float.Parse(pdbAtomText.Substring(38, 8).Replace('.', ','));
            var z = float.Parse(pdbAtomText.Substring(47, 7).Replace('.', ','));


            return new Atom() { 
                X = x,
                Y = y,
                Z = z, 
                Type = type
            };
        }

        public static List<string> ReadAsList(IFormFile file)
        {
            List<string> lines = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    lines.Add(reader.ReadLine());
            }

            return lines;
        }

        public static List<char> GetSequenceList(string sequenceString)
        {
            return
                sequenceString
                .Trim()
                .ToCharArray()
                .ToList();
        }

        public static List<string> GetMutationList(string mutationString)
        {
            return mutationString
                .Trim()
                .Split(',')
                .ToList();
        }
    }
}
