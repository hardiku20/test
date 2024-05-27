using System;
using System.Collections.Generic;

namespace test.DbEntities.Models;

public partial class CaseTag
{
    public int CaseTagId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
