using System;
using System.Collections.Generic;

namespace KoiManagement-Business;

public partial class Prediction
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid CompetitionRoundId { get; set; }

    public double Point { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public bool Active { get; set; }

    public virtual CompetitionRound CompetitionRound { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
