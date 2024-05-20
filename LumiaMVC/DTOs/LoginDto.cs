using System.ComponentModel.DataAnnotations;

namespace LumiaMVC.DTOs
{
    public class LoginDto
    {
        [Required]
        public string EmailOrUser { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRemember {  get; set; }
    }
}
