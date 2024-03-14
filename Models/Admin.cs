using System;
using System.Collections.Generic;

namespace HelloDoc.Models;

public partial class Admin
{
    public int Adminld { get; set; }

    public string AspNetUserld { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public int? Regionld { get; set; }

    public string? Zip { get; set; }

    public string? AltPhone { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public byte? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public int? Roleld { get; set; }

    public virtual AspNetUser AspNetUserldNavigation { get; set; } = null!;

    public virtual AspNetUser? ModifiedByNavigation { get; set; }

    public virtual ICollection<RequestWiseFile> RequestWiseFiles { get; set; } = new List<RequestWiseFile>();
}
