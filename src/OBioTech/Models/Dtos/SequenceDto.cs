using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace OBioTech.Models.Dtos
{
    public class SequenceDto
    {
        [Required]
        public string Sequence { get; set; }

        [Required]
        public string Mutations { get; set; }
    }
}
