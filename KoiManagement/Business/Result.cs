using System;
using System.Collections.Generic;

namespace KoiManagement-Business;

public partial class Result
{
    public Guid Id { get; set; }

    public Guid RegistrationId { get; set; }

    public Guid KoiId { get; set; }

    public double FinalMark { get; set; }

    public int Ranking { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual Koi Koi { get; set; } = null!;

    public virtual Registration Registration { get; set; } = null!;
}
