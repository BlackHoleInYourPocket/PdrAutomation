using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Models
{
    public class LoginModel
    {
        [Required]
        [UIHint("StudentSchoolId")]
        public string StudentSchoolId { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
