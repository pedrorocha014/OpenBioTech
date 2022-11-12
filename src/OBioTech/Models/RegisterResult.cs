using System.ComponentModel.DataAnnotations;

namespace OBioTech.Models
{
    public class RegisterResult
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Operation { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public bool IsSuccess { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
