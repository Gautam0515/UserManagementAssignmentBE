using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementAssignmentBE.Models;

namespace Models.Models.DTOS
{
    public class AddUserDTO
    {
        [Required(ErrorMessage = "Field Required")]
        [MaxLength(30)]
        public string FirstName { get; set; } = null!;

        [MaxLength(20)]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [MaxLength(20)]

        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Field Required")]
        [MaxLength(6)]
        public string Gender { get; set; } = null!;

        public DateTime? DateOfJoining { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Syntax")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Field Required")]
        [MaxLength(20)]
        public string? Password { get; set; }  

        [Required(ErrorMessage = "Field Required")]
        [MaxLength(13)]
        public string Phone { get; set; } = null!;

        [MaxLength(13)]
        public string? AlternatePhone { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [MaxLength(20)]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "Field Required")]
        [MaxLength(44)]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "Field Required")]
        [MaxLength(100)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Field Required")]
        [MaxLength(6)]
        public string ZipCode { get; set; } = null!;
        [Required(ErrorMessage = "Field Required")]
        public bool IsActive { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public IFormFile? PicBytes { get; set; }

        public int? TempAddressId { get; set; }

        public virtual TempAddress TempAddress { get; set; }
    }
}
