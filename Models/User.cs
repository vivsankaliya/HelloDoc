﻿using System;
using System.Collections.Generic;

namespace HelloDoc.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? AspNetUserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? Mobile { get; set; }


    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public int? RegionId { get; set; }

    public string? ZipCode { get; set; }

    public string? StrMonth { get; set; }

    public int? IntYear { get; set; }

    public int? IntDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public byte? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Ip { get; set; }

    public bool? IsRequestWithEmail { get; set; }

    public virtual AspNetUser? AspNetUser { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
