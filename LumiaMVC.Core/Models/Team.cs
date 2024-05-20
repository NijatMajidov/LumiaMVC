using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumiaMVC.Core.Models
{
    public class Team : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Surname { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Position { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set;}
    }
}
