﻿using System.ComponentModel.DataAnnotations;

namespace OBioTech.Models.Dtos
{
    public class RmsdDto
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
