﻿using System;
using System.Collections.Generic;

namespace test.DbEntities.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public short AccountType { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Ip { get; set; }

    public virtual ICollection<RoleMenu> RoleMenus { get; set; } = new List<RoleMenu>();
}
