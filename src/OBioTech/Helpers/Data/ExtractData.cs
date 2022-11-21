using OBioTech.Models;

namespace OBioTech.Helpers.Data
{
    public static class ExtractData
    {
        public static Atom GetDataFromPdbAtomText(string pdbAtomText, string model)
        {
            var serial = pdbAtomText.Substring(6, 5);
            var x = Double.Parse(pdbAtomText.Substring(30, 8).Replace('.',','));
            var y = Double.Parse(pdbAtomText.Substring(38, 8).Replace('.', ','));
            var z = Double.Parse(pdbAtomText.Substring(47, 7).Replace('.', ','));

            return new Atom() { 
                Model = model,
                SerialNumber = serial, 
                X = x, 
                Y = y, 
                Z = z, 
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
