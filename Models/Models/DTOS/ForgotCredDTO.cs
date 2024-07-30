using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.DTOS
{
    public class ForgotCredDTO
    {
        [Required(ErrorMessage = "Field Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Syntax")]
        public string Email { get; set; } = null!;

    }
}
