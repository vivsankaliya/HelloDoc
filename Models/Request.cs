using System;
using System.Collections.Generic;

namespace HelloDoc.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public int RequestTypeId { get; set; }

    public int? UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public byte Status { get; set; }

    public long? PhysicianId { get; set; }

    public string? ConfirmationNumber { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public bool? IsDeleted { get; set; }

    public DateTime? ModifiedDate { get; set; } = DateTime.Now;

    public string? DeclinedBy { get; set; }

    public bool IsUrgentEmailSent { get; set; }

    public DateTime? LastWellnessDate { get; set; } = DateTime.Now;

    public bool? IsMobile { get; set; }

    public byte? CallType { get; set; }

    public int? CompletedByPhysician { get; set; }

    public DateTime? LastReservationDate { get; set; } = DateTime.Now;

    public DateTime? AcceptedDate { get; set; } = DateTime.Now;

    public string? RelationName { get; set; }

    public string? CaseNumber { get; set; }

    public string? Ip { get; set; }

    public string? CaseTag { get; set; }

    public string? CaseTagPhysician { get; set; }

    public int? PatientAccountId { get; set; }

    public int? CreatedUserId { get; set; }

    public virtual Physician? Physician { get; set; }

    public virtual ICollection<RequestClient> RequestClients { get; set; } = new List<RequestClient>();

    public virtual ICollection<RequestWiseFile> RequestWiseFiles { get; set; } = new List<RequestWiseFile>();

    public virtual User? User { get; set; }
}
