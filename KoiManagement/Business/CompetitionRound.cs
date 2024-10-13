using System;
using System.Collections.Generic;

namespace KoiManagement-Business;

public partial class CompetitionRound
{
    public Guid Id { get; set; }

    public Guid KoiId { get; set; }

    public Guid CompetitionId { get; set; }

    public Guid RoundId { get; set; }

    public bool Active { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual Competition Competition { get; set; } = null!;

    public virtual Koi Koi { get; set; } = null!;

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    public virtual ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();

    public virtual ICollection<RefereeMark> RefereeMarks { get; set; } = new List<RefereeMark>();

    public virtual Round Round { get; set; } = null!;
}
