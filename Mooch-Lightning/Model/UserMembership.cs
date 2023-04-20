﻿namespace Mooch_Lightning.Model;

public class UserMembership
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MembershipId { get; set; }
    public bool IsMooched { get; set; }
    public DateTime AvailabiltyStartDate { get; set; }
    public DateTime AvailabiltyEndDate { get; set; }
}