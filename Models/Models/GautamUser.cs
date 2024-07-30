using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagementAssignmentBE.Models;

public partial class GautamUser
{
    public int UserId { get; set; }

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
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Field Required")]
    public string Password { get; set; }= null!;

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

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public byte[]? PicBytes { get; set; }

    public string? EmailKey { get; set; }

    public string? PassKey { get; set; }

    public int? TempAddressId { get; set; }

    public virtual TempAddress? TempAddress { get; set; }
}
