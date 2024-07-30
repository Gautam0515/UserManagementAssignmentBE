using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagementAssignmentBE.Models;

public partial class TempAddress
{
    public int Id { get; set; }

    [MaxLength(20)]
    public string Country { get; set; } = "null";

    [MaxLength(44)]
    public string State { get; set; } = "null";

    [MaxLength(100)]
    public string City { get; set; } = "null";

    [MaxLength(6)]
    public string ZipCode { get; set; } = "null";

    public virtual ICollection<GautamUser> GautamUsers { get; set; } = new List<GautamUser>();
}
