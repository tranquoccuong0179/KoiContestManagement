﻿using System;
using System.Collections.Generic;

namespace KoiManagement-Business;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
