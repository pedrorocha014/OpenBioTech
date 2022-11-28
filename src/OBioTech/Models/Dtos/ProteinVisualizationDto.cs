using System.ComponentModel.DataAnnotations;

namespace OBioTech.Models.Dtos
{
    public class ProteinVisualizationDto
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string ModelNumber { get; set; }
    }
}
