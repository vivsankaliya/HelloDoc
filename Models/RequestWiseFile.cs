using System;
using System.Collections.Generic;

namespace HelloDoc.Models;

public partial class RequestWiseFile
{
    public int RequestWiseFileId { get; set; }

    public int Requestid { get; set; }

    public string FileName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public long? Physicianld { get; set; }

    public int? Adminld { get; set; }

    public byte? DocType { get; set; }

    public bool? IsFrontSide { get; set; }

    public bool? IsCompensation { get; set; }

    public string? Ip { get; set; }

    public bool? IsFinalize { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsPatientRecords { get; set; }

    public virtual Admin? AdminldNavigation { get; set; }

    public virtual Physician? PhysicianldNavigation { get; set; }

    public virtual Request Request { get; set; } = null!;
}
