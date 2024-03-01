using System;
using System.Collections.Generic;

namespace HelloDoc.Models;

public partial class RequestClient
{
    public int RequestClientId { get; set; }

    public int RequestId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Location { get; set; }

    public string? Address { get; set; }

    public int? RegionId { get; set; }

    public string? NotiMobile { get; set; }

    public string? NotiEmail { get; set; }

    public string? Notes { get; set; }

    public string? Email { get; set; }

    public string? StrMonth { get; set; }

    public int? IntYear { get; set; }

    public int? IntDate { get; set; }

    public bool? IsMobile { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public byte? CommunicationType { get; set; }

    public byte? RemindReservationCount { get; set; }

    public byte? RemindHouseCallCount { get; set; }

    public byte? IsSetFollowupSent { get; set; }

    public string? Ip { get; set; }

    public byte? IsReservationReminderSent { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public virtual Region? Region { get; set; }

    public virtual Request Request { get; set; } = null!;
}
