﻿using System;
using System.Collections.Generic;

namespace test.DbEntities.Models;

public partial class RequestWiseFile
{
    public int RequestWiseFileId { get; set; }

    public int RequestId { get; set; }

    public string FileName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int? PhysicianId { get; set; }

    public int? AdminId { get; set; }

    public short? DocType { get; set; }

    public bool? IsFrontSide { get; set; }

    public bool? IsCompensation { get; set; }

    public string? Ip { get; set; }

    public bool? IsFinalize { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsPatientRecords { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Physician? Physician { get; set; }

    public virtual Request Request { get; set; } = null!;
}
