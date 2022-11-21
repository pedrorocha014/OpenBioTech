using Newtonsoft.Json;
using OBioTech.Helpers.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace OBioTech.Models.Dtos
{
    public class AnalysisDto
    {
        [Required]
        public string Sequence { get; set; }

        [Required]
        public string Mutations { get; set; }

        [Required]
        [AnalysisTypeValidation]
        public string Type { get; set; }
    }
}
