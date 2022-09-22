using AnalysisDelivery.Validations;
using System.ComponentModel.DataAnnotations;

namespace AnalysisDelivery.Models
{
    public class AnalysisDto
    {
        [Required]
        public string Sequence { get; set; }
        [Required]
        public string Mutations { get; set; }
        [Required]
        public List<Operations> Operations { get; set; }
    }

    public class Operations
    {
        [Required]
        [OperationsType]
        public string Operation { get; set; }
        public string? Values { get; set; }
    }
}
