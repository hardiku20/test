﻿using System;
using System.Collections.Generic;

namespace test.DbEntities.Models;

public partial class HealthProfessionalType
{
    public int HealthProfessionalId { get; set; }

    public string ProfessionName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<HealthProfessional> HealthProfessionals { get; set; } = new List<HealthProfessional>();
}
