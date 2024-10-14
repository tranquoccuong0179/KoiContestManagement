namespace KoiManagement_Business;

public partial class Mark
{
	public Guid Id { get; set; }

	public Guid CompetitionRoudId { get; set; }

	public double Point { get; set; }

	public DateTime? CreateAt { get; set; }

	public DateTime? UpdateAt { get; set; }

	public DateTime? DeleteAt { get; set; }

	public bool Active { get; set; }

	public virtual CompetitionRound CompetitionRoud { get; set; } = null!;

	public virtual ICollection<RefereeMark> RefereeMarks { get; set; } = new List<RefereeMark>();
}
