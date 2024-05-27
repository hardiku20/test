using System;
using System.Collections.Generic;

namespace test.DbEntities.Models;

public partial class PhysicianNotification
{
    public int Id { get; set; }

    public int PhysicianId { get; set; }

    public bool IsNotificationStopped { get; set; }

    public virtual Physician Physician { get; set; } = null!;
}
