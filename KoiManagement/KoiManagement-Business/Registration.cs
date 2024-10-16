using System;
using System.Collections.Generic;

namespace KoiManagement_Business;

public partial class Registration
{
    public Guid Id { get; set; }

    public Guid KoiId { get; set; }

    public Guid CompetitionCategoryId { get; set; }

    public bool IsCheckIn { get; set; }

    public DateTime? CheckInTime { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public bool Active { get; set; }

    public virtual CompetitionCategory CompetitionCategory { get; set; } = null!;

    public virtual Koi Koi { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
