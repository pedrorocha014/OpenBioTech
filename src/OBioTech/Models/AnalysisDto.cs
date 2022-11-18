using OBioTech.Helpers.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace OBioTech.Models
{
    public class AnalysisDto
    {
        [Required]
        public IFormFile? File { get; set; }
        [Required]
        public string? Sequence { get; set; }
        [Required]
        public string? Mutations { get; set; }
        [Required]
        [AnalysisTypeValidation]
        public string Type { get; set; }
    }
}
