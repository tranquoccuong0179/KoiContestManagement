using System;
using System.Collections.Generic;

namespace KoiManagement-Business;

public partial class Criterion
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double Percent { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public bool Active { get; set; }
}
